﻿using Identity.Domain;
using Identity.Service.EH.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Controllers
{
    [ApiController]
    [Route("v1/identity")]

    public class IdentityController : ControllerBase
    {
        private readonly ILogger<IdentityController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMediator _mediator;

        public IdentityController(ILogger<IdentityController> logger, SignInManager<ApplicationUser> signInManager, IMediator mediator)
        {
            _logger = logger;
            _signInManager = signInManager;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(command);

                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("authentication")]
        public async Task<IActionResult> Authentication(UserLoginCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(command);

                if (!result.Succeeded)
                {
                    return BadRequest("Access denied");
                }

                return Ok(result);
            }

            return BadRequest();
        }
    }
}
