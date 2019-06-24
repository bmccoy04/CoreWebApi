using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebApi.Api.Dtos;
using CoreWebApi.Core.Handlers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApi.Api.Controllers
{
    public class BlogsController : BaseApiV1Controller 
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/v1/Blogs
        [HttpGet]
        public async Task<IEnumerable<BlogDto>> Get()
        {
            throw new Exception("Need to add auto mapper now!");
            //return await _mediator.Send(new GetBlogsQuery());
        }

        // GET: api/Blogs/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Blogs
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Blogs/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
