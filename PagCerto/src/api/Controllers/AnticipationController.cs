using Microsoft.AspNetCore.Mvc;
using PagCerto.src.api.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagCerto.src.api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AnticipationController : Controller
    {
        [HttpGet]
        public IActionResult GetTransaction()
        {
            try
            {                
                AnticipationRepository anticipationRepository = new AnticipationRepository();
                return Ok(anticipationRepository.GetAnticipations());
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("{idAnticipation}")]
        public IActionResult GetTransactionById(int idAnticipation)
        {
            try
            {                
                AnticipationRepository anticipationRepository = new AnticipationRepository();
                return Ok(anticipationRepository.GetAnticipationById(idAnticipation));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

    }
}
