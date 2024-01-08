using confectionery_back.Enums;

namespace confectionery_back.ViewModels
{
	public class OrderViewModel
	{
		public Guid Id { get; set; }
		public ProductEnum Product { get; set; }
		public byte[]? Image { get; set; }
		public Guid? Filling { get; set; }
		public Guid Dough { get; set; }
		public int Weight { get; set; }
		public DateTime IssuedDateTime { get; set; }
		public DeliveryMethodEnum DeliveryMethod { get; set; }
		public Guid ClientId { get; set; }
		public bool IsPrepayment { get; set; } = false;
		public int PrepaymentAmout { get; set; }
		public string? Comment { get; set; }
	}
}
