using Domain.Enums;

namespace Application.Price.Queries.GetPrice;

public class PriceDto
{
    public int Price { get; set; }
    public int Discount { get; set; }
}