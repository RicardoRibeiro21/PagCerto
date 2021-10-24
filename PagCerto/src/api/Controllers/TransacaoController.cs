//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using PagCerto.src.api.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace PagCerto.src.api.Controllers
//{
//    [Produces("application/json")]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TransacaoController : ControllerBase
//    {
//        public IActionResult GetTransacao()
//        {
//            try
//            {
//                //Retornando o resultado (Lista de todos os clientes) 
//                //return Ok(FilmeRepository.GetFilmes());
//                return Ok();
//            }
//            catch (Exception ex) { return BadRequest(ex.Message); }
//        }
        
//        [HttpPost]
//        public IActionResult PostTransacao(TbTransacao transacao)
//        {
//            try
//            {
//                //FilmeRepository.Post(filme);
//                return Ok("Transação cadastrada!");
//            }
//            catch (Exception ex) { return BadRequest(ex.Message); }
//        }
//    }
//}
