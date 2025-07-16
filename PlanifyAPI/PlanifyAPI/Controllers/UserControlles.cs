using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanifyAPI.Data.Context;
using PlanifyAPI.Models;
using PlanifyAPI.Models.Commands.Users;
using System;
using System.Data;
using System.Net.Mail;
using System.Security.Claims;

namespace PlanifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly PlanifyDbContext _context;
       // private IUsersService _usersService;
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        private IConfiguration _configuration;

        public UsersController(/*IUsersService usersService,*/
            PlanifyDbContext context,
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
           // _usersService = usersService;
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            return user;
        }

        //// POST: api/users
        //[HttpPost]
        //public async Task<ActionResult<User>> CreateUser(User user)
        //{
        //    user.CreatedAt = DateTime.UtcNow;
        //    _context.Users.Add(user);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
        //}

        [HttpPost]
        public async Task<IActionResult> RegisterUser(CreateUserCommand registerVM)
        {
            //Check if the user exists
            var user = await _userManager.FindByEmailAsync(registerVM.Email);
            if (user != null)
            {
              //  ModelState.AddModelError("", "Email address is already in use.");
            }

            var newUser = new User()
            {
                Email = registerVM.Email,
                UserName = registerVM.Email,
                LockoutEnabled = true
            };

            var userCreated = await _userManager.CreateAsync(newUser, registerVM.Password);
            if (userCreated.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, Role.User);

                //Login the user
                await _signInManager.PasswordSignInAsync(newUser, registerVM.Password, false, false);
            } else
            {
                foreach (var error in userCreated.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return CreatedAtAction(nameof(GetUser), false);
            }

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }
    }
}
