using Microsoft.AspNetCore.Mvc;
using ptEdiTest.Data;
using ptEdiTest.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace ptEdiTest.Controllers
{

    [ApiController]

    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserAppDbContext _context;

        public UserController(UserAppDbContext context)
        {
            _context = context;
        }


        [HttpGet("getDataUser")]
        public IActionResult getDataUser(string userId)
        {
            if (userId.ToLower() == "all")
            {
                var allUsers = _context.Users.ToList();
                return Ok(allUsers);
            }
            else
            {
                if (int.TryParse(userId, out int userIdValue))
                {
                    var user = _context.Users.FirstOrDefault(u => u.userid == userIdValue);

                    if (user == null)
                    {
                        return NotFound($"User dengan ID {userId} tidak ditemukan");
                    }

                    return Ok(user);
                }
                else
                {
                    return BadRequest("Format ID tidak valid");
                }
            }
        }
        [HttpPost("setDataUser")]
        public IActionResult setDataUser([FromBody] User newUser)
        {
            try
            {
                if (newUser == null)
                {
                    return BadRequest("Data  tidak valid");
                }

                _context.Users.Add(newUser);
                _context.SaveChanges();

                return Ok("Data berhasil disimpan");
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, etc.
                Console.WriteLine($"Error saving user data: {ex.Message}");
                return StatusCode(500, "Terjadi kesalahan server");
            }
        }

        [HttpPost("delDataUser")]
        public IActionResult delDataUser([FromBody] int userId)
        {
            try
            {
                var userToDelete = _context.Users.FirstOrDefault(u => u.userid == userId);

                if (userToDelete == null)
                {
                    return NotFound($"User dengan ID {userId} tidak ditemukan");
                }

                _context.Users.Remove(userToDelete);
                _context.SaveChanges();

                return Ok($"User dengan ID {userId} berhasil dihapus");
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, etc.
                Console.WriteLine($"Error deleting user: {ex.Message}");
                return StatusCode(500, "Terjadi kesalahan server");
            }
        }




    }

}
