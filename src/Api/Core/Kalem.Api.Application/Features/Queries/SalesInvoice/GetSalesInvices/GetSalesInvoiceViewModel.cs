namespace Kalem.Api.Application.Features.Queries.SalesInvoice.GetSalesInvices
{
    public class GetSalesInvoiceViewModel
    {
        public Guid InvoiceNo { get; set; }

        public DateTime InvoiceTime { get; set; }=DateTime.Now;
       
        public string User { get; set; }
        public List<ItemViewModel> ItemViewModels { get; set; }


    }

    public class ItemViewModel
    {

        public Guid ItemNo { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
