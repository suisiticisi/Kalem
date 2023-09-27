using Kalem.Api.Application.Features.Queries.SalesInvoice.GetSalesInvices;
using Kalem.Api.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalem.Api.Application.Features.Queries.SalesInvoice
{
    public class GetSalesInvoiceQueryHandler : IRequestHandler<GetSalesInvoiceQuery, Response<GetSalesInvoiceViewModel>>
    {
        private readonly ISalesInvoiceRepository _salesInvoiceRepository;
        private readonly ISalesInvoiceItemRepository _salesInvoiceItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public GetSalesInvoiceQueryHandler(ISalesInvoiceRepository salesInvoiceRepository, ISalesInvoiceItemRepository salesInvoiceItemRepository, IProductRepository productRepository, IUserRepository userRepository = null, IRoleRepository roleRepository = null)
        {
            _salesInvoiceRepository = salesInvoiceRepository;
            _salesInvoiceItemRepository = salesInvoiceItemRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        public async Task<Response<GetSalesInvoiceViewModel>> Handle(GetSalesInvoiceQuery request, CancellationToken cancellationToken)
        {

            var query = _salesInvoiceRepository.AsQueryable().Where(x => x.Status)
                .Include(_ => _.SalesInvoiceItems).ThenInclude(_ => _.Product)
                .Include(_ => _.User).ThenInclude(_=>_.Role);

            var salesInvoice = query.Where(x => x.InvoiceNo == request.InvoiceNo).FirstOrDefault() ;
            if (salesInvoice==null)
            {
                return Response<GetSalesInvoiceViewModel>.Fail("SalesInvoice not found", 404);
            }
            var user = await _userRepository.GetSingleAsync(x => x.Id == salesInvoice.UserId);

            var itemss = query.Where(x => x.InvoiceNo == request.InvoiceNo).Select(x => x.SalesInvoiceItems).FirstOrDefault().ToList();

          

            var items = itemss.Select(x => new ItemViewModel()
            {
                Name=x.Product.Name,
                UnitPrice=x.Product.UnitPrice,
                ItemNo=x.ItemNo,
                Amount=x.Amount,
                TotalAmount=x.TotalAmount,
                
                
                
            });
            var getSalesInvoiceViewModelshort = new GetSalesInvoiceViewModel()
            {  
                InvoiceNo = request.InvoiceNo,
                User=user.FirstName+user.LastName,
              

            };
            var getSalesInvoiceViewModellong = new GetSalesInvoiceViewModel()
            {
                InvoiceNo = request.InvoiceNo,
                User = user.FirstName +" " +user.LastName,
                ItemViewModels= items.ToList(),
             
            };

            return request.IsInvoiceRow ? Response<GetSalesInvoiceViewModel>.Success(getSalesInvoiceViewModellong, 200) :
                  Response<GetSalesInvoiceViewModel>.Success(getSalesInvoiceViewModelshort, 200);
        }
    }
}
