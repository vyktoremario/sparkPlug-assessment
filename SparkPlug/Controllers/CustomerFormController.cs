/*
 * This file contains a CustomerformController class with a method that handles api route that is exposed to the client App.
*/

using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Services.Interface;
using System.Threading.Tasks;

namespace SparkPlug.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerFormController : ControllerBase
    {
        private readonly IMessageService _iMessageService;

        public CustomerFormController(IMessageService iMessageService)
        {
            _iMessageService = iMessageService;
        }

        [HttpPost("send-message/{companyName}")]
        public async Task<ActionResult<object>> SendMessage([FromForm] MessageToAddDto model, [FromRoute] string companyName)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Not found", "");
                return BadRequest(ModelState);
            }
            //Pass the message to the service to handle adding it to the db and returning a response 
            var response = await _iMessageService.SendMessage(model, companyName);

            if (!response.Item1) return BadRequest(new Response 
            { 
                success = response.Item1, 
                message = response.Item2 
            });

            return Ok(new Response 
            { 
                success = response.Item1, 
                message = response.Item2 
            });
        }
    }
}
