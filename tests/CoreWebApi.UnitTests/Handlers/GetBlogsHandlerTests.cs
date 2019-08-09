using System;
using CoreWebApi.Core.Handlers;
using Xunit;
using Moq;
using CoreWebApi.Core.Interfaces;
using CoreWebApi.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreWebApi.UnitTests.Handlers
{
    public class GetBlogsHandlerTests 
    {
        [Fact]
        public async Task HandlesReturnListSuccess()
        {
            var repo = new Mock<IRepository>();
            var handler = new GetBlogsHandler(repo.Object);
            var request = new GetBlogsQuery();
            var cancellationToken = new System.Threading.CancellationToken();

            var expected = new List<Blog>() {new Blog {Id = 1, Name="My Test Blog"}};

            repo.Setup(x => x.List<Blog>()).Returns(expected);

            var actual = await handler.Handle(request, cancellationToken);

            Assert.Equal(expected, actual);
        }
    }
}
