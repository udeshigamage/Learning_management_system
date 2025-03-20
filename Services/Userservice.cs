using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Learning_management_system.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Learning_management_system.Services
{
    public class Userservice:IUserService
    {
        private readonly Appdbcontext _context;

        public Userservice(Appdbcontext context)
        {
            _context = context;
        }

        public async Task<Message<string>> Createuserasync(CreateUserDTO User)
        {
            try
            {

                if (User == null)
                {

                    return new Message<string>
                    {
                        Status = "E",
                        Text = "Data is empty"
                    };

                }

                bool existemail = await _context.Users.AnyAsync(u => u.Email == User.Email);

                if (existemail)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Text = $"{User.Email} already exist"
                    };
                }

                var user = new User
                {
                    Email = User.Email,
                    FirstName = User.FirstName,
                    LastName = User.LastName,
                    User_Type = User.User_Type,
                    Createddate = DateTime.UtcNow,
                    PasswordHash = User.PasswordHash,

                };
                
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status = "S",
                    Text = "User created successfully",
                };
                

            }
            catch(Exception ex)
            {
                return new Message<string>
                {
                    Status = "E",
                    Text = ex.Message,
                };
            }

        }

        public async Task<Message<string>> Updateuserasync(UpdateUserDTO user, int id) {

            try
            {
                if (user == null) {
                    return new Message<string>
                    {
                        Status = "E",
                        Text = "user field is empty nothing to update"
                    };
                };

                if (id == null)
                    return new Message<string>
                    {
                        Status = "E",
                        Text = "Id is required"
                    };
                var existinguser = await _context.FindAsync<User>(id);

                if (existinguser == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Text = "user not found"
                    };
                }
                existinguser.Email = user.Email;
                existinguser.FirstName = user.FirstName;
                existinguser.LastName = user.LastName;
                existinguser.User_Type = user.User_Type;

                await _context.SaveChangesAsync();

                return new Message<string>
                {
                    Status = "S",
                    Text = "successfully updated"
                };
                
            }

           

                
            catch (Exception ex)
            {
                return new Message<string>
                {
                    Status = "E",
                    Text = ex.Message,
                };

            }


        
        }

        public async Task<Message<string>> Deleteuserasync(int id) {

            try
            {
                var user = await _context.FindAsync<User>(id);
                if(user == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Text = "user doesn't exist"
                    };
                }
                 _context.Remove(user);
                _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status = "S",
                    Text = "Deleted succcessfully"
                };

            }catch(Exception ex)
            {
                return new Message<string>
                {
                    Status = "E",
                    Text = "error in deleting user"
                };

            }
        
        }

        public async Task<IEnumerable<ViewUserDTO>> Getviewuserasync(int id) {

            var users = await (from u in _context.Users
                               where u.User_Id == id
                               select new ViewUserDTO
                               {
                                   Email = u.Email,
                                   FirstName = u.FirstName,
                                   LastName = u.LastName,
                                   User_Type = u.User_Type
                               }).ToListAsync();

            return users;

        }

        public async Task<(IEnumerable<ViewUserDTO>,int Totalpages)> GetAllviewusersasync(int page = 1, int pagesize = 5,string searchterm ="", string filterBy = "",string filterValue = "")
        { 

            var query=_context.Users.AsQueryable();

            if(!string.IsNullOrWhiteSpace(searchterm))
            {
                query = query.Where(u => u.FirstName.Contains(searchterm) || u.LastName.Contains(searchterm) || u.Email.Contains(searchterm));
            }
            if (!string.IsNullOrWhiteSpace(filterBy) && !string.IsNullOrWhiteSpace(filterValue))
            {
                query = filterBy.ToLower() switch
                {
                    "email" => query.Where(u => u.Email.Contains(filterValue)),
                    "firstname" => query.Where(u => u.FirstName.Contains(filterValue)),
                    "lastname" => query.Where(u => u.LastName.Contains(filterValue)),
                   
                    _ => query 
                };
            }

            var totalcount= await query.CountAsync();

            var users = await (from u in query select new ViewUserDTO
            {
                Email=u.Email,
                FirstName=u.FirstName,
                LastName=u.LastName,
                User_Type = u.User_Type
            }).Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();

            return  (users,totalcount);

        
        }
    }
}
