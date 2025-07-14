using Microsoft.AspNetCore.Mvc;
using Mission.Entity.Models.EmailModels;
using Mission.Service.IServices;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController(IEmailService emailService) : ControllerBase
    {
        private readonly IEmailService _emailService = emailService;

        [HttpPost]
        public IActionResult SendEmail(EmailRequestModel request)
        {
            _emailService.SendEmail(request);
            return Ok();
        }
    }
}
