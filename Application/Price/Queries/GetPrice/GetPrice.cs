using AutoMapper;
using Domain.Enums;
using MediatR;

namespace Application.Price.Queries.GetPrice;

public class GetPriceQuery : IRequest<PriceDto>
{
    public int ShelfCount { get; set; }
    public int WeeksCount { get; set; }
    public ShelfType ShelfType { get; set; }
}

public class GetPriceQueryHandler : IRequestHandler<GetPriceQuery, PriceDto>
{
    private readonly IMapper _mapper;

    public GetPriceQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<PriceDto> Handle(GetPriceQuery request, CancellationToken cancellationToken)
    {
        var shelfWeekPrice = 100;
        var priceBeforeDiscount = shelfWeekPrice * request.ShelfCount * request.WeeksCount;
        int price = shelfWeekPrice * request.ShelfCount * request.WeeksCount;;
        int discount = priceBeforeDiscount > price ? priceBeforeDiscount- price : 0;
        

        if (request.WeeksCount is > 3 and < 8)
        {
            shelfWeekPrice = 350 / 4;
            price = shelfWeekPrice * request.ShelfCount * request.WeeksCount;
            discount = priceBeforeDiscount > price ? priceBeforeDiscount- price : 0;
        }
        else if(request.WeeksCount > 7)
        {
            shelfWeekPrice = 600 / 8;
            price = shelfWeekPrice * request.ShelfCount * request.WeeksCount;
            discount = priceBeforeDiscount > price ? priceBeforeDiscount- price : 0;
            
        }
        
        var data = new PriceDto
        {
            Price = price,
            Discount = discount,
        };
        
        return data;
    }
}
