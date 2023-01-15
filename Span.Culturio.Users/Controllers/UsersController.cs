﻿using Microsoft.AspNetCore.Mvc;
using Span.Culturio.Core.Models.Users;
using Span.Culturio.Users.Services;
using System.ComponentModel.DataAnnotations;

namespace Span.Culturio.Users.Controllers
{
        [Route("api/users")]
        [ApiController]
        public class UsersController : ControllerBase
        {
            private readonly IUserService _userService;

            public UsersController(IUserService userService)
            {
                _userService = userService;
            }

            [HttpGet]
            public async Task<ActionResult<UserDto>> GetUsersAsync([Required][FromQuery] int pageSize, [FromQuery] int pageIndex)
            {
                var users = await _userService.GetUsersAsync(pageSize, pageIndex);
                return Ok(users);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<UserDto>> GetUserByIdAsync(int id)
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user is null)
                    return NotFound();
                return Ok(user);
            }
        }
}
