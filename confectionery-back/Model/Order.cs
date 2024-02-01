using confectionery_back.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace confectionery_back.Model
{
	public class Order
	{
		[Key]
		public Guid Id { get; set; }
		public bool IsCompleted { get; set; } = false;
		public ProductEnum Product { get; set; }
		public byte[]? Image { get; set; }
		public Guid? Filling { get; set; }
		public Guid? SecondFilling { get; set; } = Guid.Empty;
		public Guid Dough { get; set; }
		public Guid SecondDough { get; set; } = Guid.Empty;
		public int Weight { get; set; }
		public int SecondWeight { get; set; } = 0;
		public DateTime IssuedDateTime { get; set; }
		public DeliveryMethodEnum DeliveryMethod { get; set; }
		public Guid ClientId { get; set; }
		public int Price { get; set; }
		public bool IsPrepayment { get; set; } = false;
		public int PrepaymentAmout { get; set; }
		public string? Comment { get; set; }
	}
}
