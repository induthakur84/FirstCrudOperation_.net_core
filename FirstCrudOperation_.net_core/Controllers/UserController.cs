using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstCrudOperation_.net_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var users = _context.Users.ToList();
            return Ok(users);
            //200
        }

        //api/User/GetById/2

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
                //404
            }
            return Ok(user);
            //200
        }

        [HttpPost("Create")]

        public IActionResult Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
            //200
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, User user)
        {
            var existingUser = _context.Users.Find(id);
            if (existingUser == null)
            {
                return NotFound();
                //404
            }
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            _context.SaveChanges();
            return Ok(existingUser);
            //200
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
                //404
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok();
            //200

        }
    }
    }
