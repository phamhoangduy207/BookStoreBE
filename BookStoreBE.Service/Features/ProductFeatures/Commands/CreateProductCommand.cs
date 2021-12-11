using BookStoreBE.Domain.Entities;
using BookStoreBE.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BookStoreBE.Service.Features.ProductFeatures.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Productname { get; set; }
        public decimal UnitPrice { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = new Product
                {
                    ProductName = request.Productname,
                    UnitPrice = request.UnitPrice
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}
