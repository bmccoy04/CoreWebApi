using System.Threading;
using System.Threading.Tasks;
using CoreWebApi.Core.Entities;
using CoreWebApi.Core.Interfaces;
using MediatR;

namespace CoreWebApi.Core.Handlers
{
    public class SaveBlogQuery : IRequest<Blog>
    {
        public Blog Blog { get; set; }

        public SaveBlogQuery(Blog blog)
        {
            this.Blog = blog;
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
            var blog = request.Blog;

            if (blog.Id > 0)
                _repository.Update(blog);
            else
                blog = _repository.Add(blog);

            return Task.FromResult(blog);
        }
    }

}
