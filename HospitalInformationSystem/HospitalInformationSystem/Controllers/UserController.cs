using HospitalInformationSystem.DBContext;
using HospitalInformationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog.Fluent;

namespace HospitalInformationSystem.Controllers
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private MysqlDbContext _context;

        public UserController(MysqlDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] UserInfo userInfo)
        {
            if (userInfo == null)
            {
                return BadRequest();
            }

            userInfo.CreateTime = DateTime.Now;
            userInfo.UpdaterTime = DateTime.Now;

            _context.UserInfo.Add(userInfo);
            _context.SaveChanges();

            return Ok(userInfo);
        }
        [HttpGet("GetUsers")]
        public List<UserInfo> GetUsers()
        {
            // 使用 EF Core 查询用户信息表
            List<UserInfo> users = _context.UserInfo.ToList();

            return users;
        }

        [HttpPost("GetLogin")]
        public bool GetLogin(string Username, string Password)
        {
            // 使用 EF Core 查询用户信息表
            return (_context.Login.Where(t => t.Username == Username && t.Password == Password).Count() > 0);
        }
    }
}
