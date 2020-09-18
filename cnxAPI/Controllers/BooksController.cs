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
    public class BooksController : ControllerBase
    {
        public BooksController()
        {
        }

        [HttpGet]
        [Produces(typeof(List<Books>))]
        public ActionResult<List<Books>> get()
        {
            try
            {
                LibrosBL libr = new LibrosBL();
                var retvalue = libr.getLibros();
                return Ok(retvalue);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        [Produces(typeof(Books))]
        public ActionResult<Books> get(int id)
        {
            try
            {
                LibrosBL libr = new LibrosBL();
                var retvalue = libr.getLibros(id);
                return Ok(retvalue);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Produces(typeof(Books))]
        public ActionResult Post(Books item)
        {
            if (item != null)
            {
                LibrosBL membl = new LibrosBL();
                membl.Add(item);
            }
            return Ok(item);
        }
    }
}
