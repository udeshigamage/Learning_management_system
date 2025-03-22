using Learning_management_system.dbcontext;
using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Learning_management_system.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning_management_system.Services
{
    public class Certificationservice : ICertification
    {
        private readonly Appdbcontext _context;
        public Certificationservice(Appdbcontext context)
        {
            _context = context;
        }

       public async Task<Message<string>> Createcertificationsasync(CreateCertificationsDTO certifications)
        {
            try
            {
                var newcertificate = new Certifications
                {
                    issue_date = DateTime.UtcNow,
                    expiry_date = certifications.expiry_date,
                    certificate_code = certifications.certificate_code,
                    User_Id = certifications.User_Id,
                    Course_Id = certifications.Course_Id
                   

                };

                _context.Certifications.Add(newcertificate);
                await _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status = "S",
                    Result = "Successfully created certification"
                };

            }
            catch (Exception ex)
            {
                return new Message<string>
                {
                    Status = "E",
                    Result = ex.Message
                };
            }
        }

        public async Task<Message<string>> Updatecertificationsasync(UpdateCertificationsDTO certifications, int id)
        {
            try
            {
                var existingcertificate = await _context.Certifications.FindAsync(id);

                if (existingcertificate == null)
                {


                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Error"
                    };

                }

                

                return new Message<string>
                {
                    Status = "S",
                    Result = "Successfully updated"
                };
            }
            catch (Exception ex)
            {
                return new Message<string>
                {
                    Status = "E",
                    Result = ex.Message
                };
            }
        }

        public async Task<Message<string>> Deletecertificationsasync(int id)
        {
            try
            {
                var certificate = await _context.Certifications.FindAsync(id);
                if(certificate == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Error"
                    };
                }
                 _context.Certifications.Remove(certificate);
                _context.SaveChangesAsync();

                return new Message<string>
                {
                    Status = "S",
                    Result = "Successfully deleted"
                };

            }
            catch (Exception ex)
            {
                return new Message<string>
                {
                    Status = "E",
                    Result = ex.Message
                };
            }
        }

        public async Task<IEnumerable<ViewCertificationsDTO>> Getviewcertificationsasync(int id)
        {
            try
            {
                var certification = await _context.Certifications.Where(c => c.Certification_Id == id).Select(c => new ViewCertificationsDTO
                {
                    Course_Id= c.Course_Id,
                    User_Id= c.User_Id,
                    certificate_code= c.certificate_code,
                    expiry_date = c.expiry_date,
                    issue_date = c.issue_date,
                    Certification_Id = c.Certification_Id,




                }).ToListAsync();

                return certification;

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<(IEnumerable<ViewCertificationsDTO>, int totalcount)> Getallcertificationsasync(int page = 1, int pagesize = 5, string searchterm = "")
        {
            try
            {
                var query =  _context.Certifications.AsQueryable();

                if(!string.IsNullOrEmpty(searchterm))
                {
                    query = query.Where(c => c.certificate_code.Contains(searchterm) || c.Certification_Id.ToString().Contains(searchterm));
                }

                var totalcount = query.Count();
                var response = await query.Skip((page-1)* pagesize).Take(pagesize).Select(c => new ViewCertificationsDTO
                {
                    Course_Id = c.Course_Id,
                    User_Id = c.User_Id,
                    certificate_code = c.certificate_code,
                    expiry_date = c.expiry_date,
                    issue_date = c.issue_date,
                    Certification_Id = c.Certification_Id,

                }).ToListAsync();
               return(response, totalcount);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




















        

    }
}
