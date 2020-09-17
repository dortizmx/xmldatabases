using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using cnxAPI.DAL.BusinessLogic;
using cnxAPI.DAL.Domain;


namespace cnxAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private LoansBL loanbl;
        public LoansController()
        {
            loanbl = new LoansBL();
        }

        [HttpGet]
        [Produces(typeof(List<Loans>))]
        public ActionResult<List<Loans>> get()
        {
            try
            {  
                var retvalue = loanbl.getLoans();
                return Ok(retvalue);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(List<Loans>))]
        public ActionResult<List<Loans>> get(string id)
        {
            try
            {
                var retvalue = loanbl.getLoanById(id);
                return Ok(retvalue);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Produces(typeof(Loans))]
        public ActionResult<Loans> post([FromBody] Loans item)
        {
            try
            {
                if (item.TransactionType.ToUpper() == "LOAN" && item.Id.Trim() == "0")
                    item.Id = cnxAPI.DAL.KeyCreator.getKey();


                item.LoanDate = DateTime.Now;
                loanbl.Add(item);

                return Ok(item);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
        
    }
}