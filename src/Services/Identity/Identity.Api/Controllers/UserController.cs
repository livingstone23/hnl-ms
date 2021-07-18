﻿using Identity.Service.Queries;
using Identity.Service.Queries.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserQueryService _userQueryService;
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger, IMediator mediator, IUserQueryService userQueryService)
        {
            _logger = logger;
            _mediator = mediator;
            _userQueryService = userQueryService;
        }

        [HttpGet]
        public async Task<DataCollection<UserDto>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<string> users = ids?.Split(',');
            return await _userQueryService.GetAllAsync(page, take, users);
        }

        [HttpGet("{id}")]
        public async Task<UserDto> Get(string id)
        {
            return await _userQueryService.GetAsync(id);
        }
    }
}
