using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalem.Api.Application.Features.Commands.SalesInvoice.Delete
{
    public class DeleteSalesInvoiceCommand:IRequest<bool>
    {
        public DeleteSalesInvoiceCommand(Guid invoiceNo)
        {
            InvoiceNo = invoiceNo;
        }

        public Guid InvoiceNo { get; set; }
    }
}
