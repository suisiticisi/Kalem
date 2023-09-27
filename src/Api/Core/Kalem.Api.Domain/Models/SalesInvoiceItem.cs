namespace Kalem.Api.Domain.Models
{
    public class SalesInvoiceItem:BaseEntity
    {
        public Guid ItemNo { get; set; }
        public Guid SalesInvoiceId { get; set; }
        public SalesInvoice SalesInvoice { get; set; }  

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
       
        public decimal Amount { get; set; } 
        public decimal TotalAmount { get; set; }
    }
}
