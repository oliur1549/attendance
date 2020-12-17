using AttendanceApi.Context;
using AttendanceApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AttendanceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected DatabaseContext _db;
        public UserController(DatabaseContext db)
        {
            _db = db;
        }
        // GET: api/<UserController>
        [HttpGet("{username}/{password}")]
        public IActionResult Get(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _db.Logins.SingleOrDefault(x => x.Username == username && x.Password==password);

            // check if username exists
            if (user == null)
            {
                return Ok("False");
            }
                
            else
            {
                return Ok("True" + user.Id);
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var redult = _db.Logins.Find(id);
            return Ok(redult);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
