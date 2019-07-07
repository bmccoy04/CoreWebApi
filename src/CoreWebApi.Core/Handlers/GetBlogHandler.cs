using CoreWebApi.Core.Entities;
using CoreWebApi.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreWebApi.Core.Handlers
{
    public class GetBlogQuery : IRequest<Blog>
    {
        public GetBlogQuery(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }

    public class GetBlogHandler : IRequestHandler<GetBlogQuery, Blog>
    {
        private readonly IRepository _repository;

        public GetBlogHandler(IRepository repository)
        {
            _repository = repository;
        }

        public Task<Blog> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetById<Blog>(request.Id));
        }
    }
}
