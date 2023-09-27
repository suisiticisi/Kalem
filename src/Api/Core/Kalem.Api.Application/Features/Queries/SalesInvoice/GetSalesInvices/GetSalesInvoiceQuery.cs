using MediatR;

namespace Kalem.Api.Application.Features.Queries.SalesInvoice.GetSalesInvices
{
    public class GetSalesInvoiceQuery : IRequest<Response<GetSalesInvoiceViewModel>>
    {
        public GetSalesInvoiceQuery(Guid invoiceNo, bool isInvoiceRow)
        {
            InvoiceNo = invoiceNo;
            IsInvoiceRow = isInvoiceRow;
        }

        public Guid InvoiceNo { get; set; }

        public bool IsInvoiceRow { get; set; }
    }
}
