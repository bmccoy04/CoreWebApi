using CoreWebApi.Core.Entities;
using CoreWebApi.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreWebApi.Core.Handlers
{
    public class GetBlogsQuery : IRequest<IEnumerable<Blog>>
    {

    }

    public class GetBlogsHandler : IRequestHandler<GetBlogsQuery, IEnumerable<Blog>>
    {
        private readonly IRepository _repository;

        public GetBlogsHandler(IRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Blog>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.List<Blog>());
        }

    }
}
