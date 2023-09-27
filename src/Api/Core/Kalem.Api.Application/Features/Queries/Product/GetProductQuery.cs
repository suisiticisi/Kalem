using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalem.Api.Application.Features.Queries.Product
{
    public class GetProductQuery:IRequest<Response<List<GetProductQueryViewModel>>>
    {

    }
}
