using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Learning_management_system.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning_management_system.Services
{
    public class Courseservices:ICourseService
    {
        private readonly Appdbcontext _context;

        public Courseservices(Appdbcontext context)
        {
            _context = context;
        }

        public async Task<Message<string>> Createcourseasync(CreateCourseDTO course)
        {
            try
            {
                var newcourse = new Courses
                {
                    Course_Description = course.Course_Description,
                    Course_Name = course.Course_Name,
                    User_Id = course.User_Id,

                };
                await _context.Courses.AddAsync(newcourse);
                await _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status = "S",
                    Text = "Course created successfully",
                    Code = "200"
                };


            }catch(Exception ex)
            {
                return new Message<string>
                {
                    Status = "E",
                    Text = ex.Message,
                    Code = "500"
                };
            }

        }




        public async Task<Message<string>> Updatecourseasync(UpdateCourseDTO course, int id)
        {
            try
            {
                var existingcourse = await _context.Courses.FindAsync(id);
                if (existingcourse == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Text = "Course not found",
                        Code = "404"
                    };
                }
                existingcourse.Course_Description = course.Course_Description;
                existingcourse.Course_Name = course.Course_Name;
                existingcourse.Modifieddate = DateTime.UtcNow;
                _context.SaveChanges();
                return new Message<string>
                {
                    Status = "S",
                    Text = "Course updated successfully",
                    Code = "200"
                };
            }
            catch (Exception ex)
            {
                return new Message<string>
                {
                    Status = "E",
                    Text = ex.Message,
                    Code = "500"
                };

            }
        } 

        public async Task<Message<string>> Deletecourseasync(int id)
        {
                try
                {
                    var course = await _context.Courses.FindAsync(id);
                    if (course == null)
                    {
                        return new Message<string>
                        {
                            Status = "E",
                            Text = "Course not found",
                            Code = "404"
                        };
                    }
                    _context.Courses.Remove(course);
                    await _context.SaveChangesAsync();
                    return new Message<string>
                    {
                        Status = "S",
                        Text = "Course deleted successfully",
                        Code = "200"
                    };

                }
                catch(Exception ex)
                {
                 return new Message<string>
                    {
                        Status = "E",
                        Text = ex.Message,
                        Code = "500"
                    };
                }

        }

       public  async Task<IEnumerable<ViewCourseDTO>> Getviewcourseasync(int id)
        {
            try
            {
                var user =await (from c in _context.Courses
                                 where c.Course_Id == id
                                 select new ViewCourseDTO
                                 {
                                     Course_Description = c.Course_Description,
                                     Course_Name = c.Course_Name,
                                     Createddate = c.Createddate,
                                     Modifieddate = c.Modifieddate
                                 }).ToListAsync();
                return user;

            }catch(Exception ex)
            {
                throw ex;

            }

        }

     public async   Task<(IEnumerable<ViewCourseDTO>, int totalcount)> Getallasync(int page = 1, int pagesize = 5, string searchterm = "", string filterBy = "", string filterValue = "")
        {
            try
            {
                var query = _context.Courses.AsQueryable();

                if (!string.IsNullOrEmpty(searchterm))
                {
                    query = query.Where(c => c.Course_Name.Contains(searchterm) || c.Course_Description.Contains(searchterm));
                }

                if (!string.IsNullOrEmpty(filterBy) && !string.IsNullOrEmpty(filterValue))
                {
                    query = filterBy.ToLower() switch
                    {
                        "coursename" => query.Where(c => c.Course_Name.Contains(filterValue)),
                        "coursedescription" => query.Where(c => c.Course_Description.Contains(filterValue)),
                        _ => query
                    };
                }
                var totalcount = query.Count();
                var courses = query.Skip((page - 1) * pagesize).Take(pagesize).Select(c => new ViewCourseDTO
                {
                    Course_Description = c.Course_Description,
                    User_Id = c.User_Id,
                    Course_Id = c.Course_Id,
                    Course_Name = c.Course_Name,
                    Createddate = c.Createddate,
                    Modifieddate = c.Modifieddate
                }).ToList();

                return (courses, totalcount);

            }
            catch (Exception ex)
            {
                throw new Exception("No courses found");



            }
        }
    }
}
