using Learning_management_system.DTO;
using Learning_management_system.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly ICertification _certificateservice;

        public CertificateController(ICertification certificateservice)
        {
            _certificateservice = certificateservice;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCertificates(int page = 1, int pagesize = 5, string searchterm = "")
        {
            try
            {
                var (certificates, totalcount) = await _certificateservice.Getallcertificationsasync(page, pagesize, searchterm);
                var response = new
                {
                    data = certificates,
                    totalItems = totalcount,
                    totalPages = (int)Math.Ceiling((double)totalcount / pagesize),
                    currentPage = page

                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound("No certificates found");
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCertificate(int id)
        {
            try
            {
                var certificate = await _certificateservice.Getviewcertificationsasync(id);
                return Ok(certificate);
            }
            catch (Exception ex)
            {
                return NotFound("No certificate found");
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateCertificate(CreateCertificationsDTO certificate)
        {
            try
            {
                var message = await _certificateservice.Createcertificationsasync(certificate);

                if (message.Status == "E")
                {
                    return BadRequest(message.Result);
                }
                return Ok(message.Result);

            }
            catch (Exception ex)
            {
                return NotFound("No certificates created");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCertificate(UpdateCertificationsDTO certificate, int id)
        {
            try
            {
                var message = await _certificateservice.Updatecertificationsasync(certificate, id);

                if (message.Status == "E")
                {
                    return BadRequest(message.Result);
                }
                return Ok(message.Result);
            }
            catch (Exception ex)
            {
                return NotFound("No certificates updated");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificate(int id)
        {
            try
            {
                var message = await _certificateservice.Deletecertificationsasync(id);
                if (message.Status == "E")
                {
                    return BadRequest(message.Result);
                }
                return Ok(message.Result);
            }
            catch (Exception ex)
            {
                return NotFound("No certificates deleted");
            }
        }

    }
}
