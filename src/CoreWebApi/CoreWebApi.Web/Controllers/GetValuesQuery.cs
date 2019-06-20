using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CoreWebApi.Api.Controllers
{
    public class GetValuesQuery : IRequest<IEnumerable<string>>
    {
    }

    public class GetValuesHandler : IRequestHandler<GetValuesQuery, IEnumerable<string>>
    {
        public Task<IEnumerable<string>> Handle(GetValuesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult((new string[] { "value 1", "value 2" }).AsEnumerable()); 
        }

    }
}