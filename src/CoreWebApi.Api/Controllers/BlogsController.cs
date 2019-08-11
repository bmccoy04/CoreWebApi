using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebApi.Api.Dtos;
using CoreWebApi.Core.Handlers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CoreWebApi.Core.Entities;
using CoreWebApi.Core.Interfaces;

namespace CoreWebApi.Api.Controllers
{
    public class BlogsController : BaseApiV1Controller 
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BlogsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // GET: api/v1/Blogs
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<IEnumerable<BlogDto>>(await _mediator.Send(new GetBlogsQuery())));
        }

        // GET: api/Blogs/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_mapper.Map<BlogDto>(await _mediator.Send(new GetBlogQuery(id))));
        }

        // POST: api/Blogs
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SaveBlogQuery blog)
        {
            return Ok(await _mediator.Send(blog));
        }

        // PUT: api/Blogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] SaveBlogQuery blog)
        {
            return Ok(_mapper.Map<BlogDto>(await _mediator.Send(blog)));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteBlogQuery(id)));
        }

        [HttpGet("{id}/Entries")]
        public async Task<IActionResult> GetEntries(int id)
        {
            return Ok(_mapper.Map<IEnumerable<EntryDto>>(await _mediator.Send(new GetBlogEntriesQuery(id))));
        }
    }
}
