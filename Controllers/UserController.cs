using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Context;
using CRUD.Entities;
using Microsoft.AspNetCore.Mvc;


namespace CRUD.Controllers
{
    [ApiController]
    [Route("(User)")]
    public class UserController : ControllerBase
    {

        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }
        [HttpPost()]
        public IActionResult Create(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = user.Id}, user);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
            var users = _context.Users.Where(x => x.Name.Contains(name));
            return Ok (users);
        }

        [HttpPatch("{id}")]
        public IActionResult Refresh(int id, User user)
        {
            var userBanco = _context.Users.Find(id);

            if (userBanco == null)
                return NotFound();

            userBanco.Name = user.Name;
            userBanco.Age = user.Age;
            userBanco.Work = user.Work;

            _context.Users.Update(userBanco);
            _context.SaveChanges();
            return Ok(userBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var userBanco = _context.Users.Find(id);

            if (userBanco == null)
                return NotFound();

            _context.Users.Remove(userBanco);
            _context.SaveChanges();
            return NoContent();

        }

    }
}