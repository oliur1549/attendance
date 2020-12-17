﻿using AttendanceApi.Context;
using AttendanceApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AttendanceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        protected DatabaseContext _db;
        public AttendanceController(DatabaseContext db)
        {
            _db = db;
        }
        // GET: api/<AttendanceController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _db.Attendances.ToList();
            return Ok(result);
        }

        // GET api/<AttendanceController>/5
        [HttpGet("{id}/{date}")]
        public IActionResult Get(int id, DateTime date)
        {
            var result = _db.Attendances.Where(p=>p.UserId==id && p.DateTime.Date==date.Date).ToList();
            return Ok(result);
        }

        // POST api/<AttendanceController>
        [HttpPost("{id}")]
        public IActionResult Post([FromBody] Attendance models, int id)
        {
            var userid = _db.Logins.Find(id);
            if (userid.Id==id)
            {
                byte[] array = Encoding.ASCII.GetBytes(models.PicBack);
                byte[] newarray = Encoding.ASCII.GetBytes(models.PicFront);

                string BackimgResized = Convert.ToBase64String(array);
                string frontimgResized = Convert.ToBase64String(newarray);
                models.PicBack = BackimgResized;
                models.PicFront = frontimgResized;
                models.UserId = id;
                var result = _db.Attendances.Add(models);
                _db.SaveChangesAsync();
                return Ok(result);
            }
            else
            {
                return Ok();
            }
            
        }

        // PUT api/<AttendanceController>/5
        [HttpPut("{id}")]
        public IActionResult Put( int id, Attendance model)
        {
            var result = _db.Attendances.Find(id);
            if (ModelState.IsValid)
            {
                // var result = _db.Attendances.Find(id);
                model.OutTime = result.OutTime;
                var update = _db.Attendances.Add(model);

                _db.SaveChanges();
                return Ok(update);
            }
            
            return Ok();
        }

        // DELETE api/<AttendanceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
