using AutoMapper;
using CoreWebApi.Core.Dtos;
using CoreWebApi.Core.Entities;
using CoreWebApi.Core.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreWebApi.Core.Handlers
{
    public class GetBlogQuery : IRequest<BlogDto>
    {
        public GetBlogQuery(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }

    public class GetBlogValidator : AbstractValidator<GetBlogQuery>
    {
        public GetBlogValidator() {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public class GetBlogHandler : IRequestHandler<GetBlogQuery, BlogDto>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetBlogHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<BlogDto> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                    _mapper.Map<BlogDto>(
                        _repository.GetById<Blog>(request.Id)));
        }
    }
}
