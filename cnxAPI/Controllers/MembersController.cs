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
    public class MembersController : ControllerBase
    {
        private MembersBL membl;
        public MembersController()
        {
            membl = new MembersBL();
        }

        [HttpGet]
        [Produces(typeof(List<Member>))]
        public ActionResult<List<Member>> get()
        {
            try
            {
                //MembersBL membl = new MembersBL();
                var retvalue = membl.getMembers();
                return Ok(retvalue);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(Member))]
        public ActionResult<Member> get(int id)
        {
            try
            {
                var retvalue = membl.getMemberById(id);
                return Ok(retvalue);

            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Produces(typeof(Member))]
        public ActionResult Post(Member item)
        {
            if(item != null)
            {
                MembersBL membl = new MembersBL();
                item.SuscriptionDate = DateTime.Now;
                membl.Add(item);
            }
            return Ok(item);
        }



    }
}
