using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebApi.Core.Handlers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CoreWebApi.Core.Entities;
using CoreWebApi.Core.Interfaces;
using CoreWebApi.Core.Dtos;

namespace CoreWebApi.Api.Controllers
{
    [Route("api/v1/blogs")]
    public class BlogsController : BaseApiV1Controller 
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/v1/blogs
        [HttpGet]
        [Produces(typeof(IEnumerable<BlogDto>))]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetBlogsQuery()));
        }

        // GET: api/v1/blogs/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetBlogQuery(id)));
        }

        // POST: api/v1/blogs
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SaveBlogQuery blogQuery)
        {
            return Ok(await _mediator.Send(blogQuery));
        }

        // PUT: api/v1/blogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateBlogQuery blogQuery)
        {
            return Ok(await _mediator.Send(blogQuery));
        }

        // DELETE: api/v1/blogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteBlogQuery(id)));
        }

        [HttpGet("{id}/entries")]
        public async Task<IActionResult> GetEntries(int id)
        {
            return Ok(await _mediator.Send(new GetBlogEntriesQuery(id)));
        }
    }
}
