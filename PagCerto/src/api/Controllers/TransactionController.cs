using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagCerto.src.api.Extensions;
using PagCerto.src.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagCerto.src.api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTransaction()
        {
            try
            {
                //Retornando o resultado (Lista de todos os clientes) 
                TransactionRepository transactionRepository = new TransactionRepository();
                return Ok(transactionRepository.GetTransactions());
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("{idTransaction}")]        
        public IActionResult GetTransactionById(int idTransaction)
        {
            try
            {
                //Retornando o resultado (Lista de todos os clientes) 
                TransactionRepository transactionRepository = new TransactionRepository();
                return Ok(transactionRepository.GetTransactionById(idTransaction));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost]
        public IActionResult PostTransaction(TbTransaction transaction)
        {
            try
            {
                TransactionRepository transactionRepository = new TransactionRepository();
                transactionRepository.PostTransaction(transaction);
                return Ok("Transação cadastrada!");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut]
        public IActionResult PutTransaction(TransactionApproval transactionApproval)
        {
            try
            {                
                TransactionRepository transactionRepository = new TransactionRepository();
                transactionRepository.UpdateConfirmationTransaction(transactionApproval.idTransaction,transactionApproval.idDecision);
                return Ok("Transação cadastrada!");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
