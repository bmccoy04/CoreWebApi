using System.Threading;
using System.Threading.Tasks;
using CoreWebApi.Core.Entities;
using CoreWebApi.Core.Interfaces;
using FluentValidation;
using MediatR;

namespace CoreWebApi.Core.Handlers
{
    public class SaveBlogQuery : IRequest<Blog>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class SaveBlogQueryValidator : AbstractValidator<SaveBlogQuery>
    {
        public SaveBlogQueryValidator() {
            RuleFor(x => x.Name).Length(0, 1);
        }
    }


    public class SaveBlogHandler : IRequestHandler<SaveBlogQuery, Blog>
    {
        private readonly IRepository _repository;

        public SaveBlogHandler(IRepository repository)
        {
            _repository = repository;
        }

        public Task<Blog> Handle(SaveBlogQuery request, CancellationToken cancellationToken)
        {
            var blog = new Blog() {Id  = request.Id, Name = request.Name};

            if (blog.Id > 0)
                _repository.Update(blog);
            else
                blog = _repository.Add(blog);

            return Task.FromResult(blog);
        }
    }

}
