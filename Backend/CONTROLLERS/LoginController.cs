﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using KoiFishManager.Api.Entities;
using KoiFishManager.Models;

namespace KoiFishManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public LoginController(IConfiguration configuration,
                               UserManager<User> userManager,
                               SignInManager<User> signInManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            // find in DB
            var user = await _userManager.FindByNameAsync(login.UserName);
            if(user == null) return BadRequest(new LoginResponse { Successful = false, Error = "Username and password are invalid." });

            var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, false, false);

            if (!result.Succeeded) return BadRequest(new LoginResponse { Successful = false, Error = "Username and password are invalid." });

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, login.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            return Ok(new LoginResponse { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
        }


        // API Đăng ký
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest register)
        {
            // Kiểm tra xem người dùng đã tồn tại chưa
            var existingUser = await _userManager.FindByNameAsync(register.UserName);
            if (existingUser != null)
                return BadRequest(new RegisterResponse { Successful = false, Error = "Username already exists." });

            // Tạo người dùng mới
            var user = new User
            {
                UserName = register.UserName,
                Email = register.Email
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
                return BadRequest(new RegisterResponse { Successful = false, Error = string.Join(", ", result.Errors.Select(e => e.Description)) });

            return Ok(new RegisterResponse { Successful = true, Message = "User created successfully." });
        }
    }
}
