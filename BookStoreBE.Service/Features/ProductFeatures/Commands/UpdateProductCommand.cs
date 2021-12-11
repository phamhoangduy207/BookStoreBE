using BookStoreBE.Persistence;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookStoreBE.Service.Features.ProductFeatures.Commands
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var prod = _context.Products.Where(p => p.Id == request.Id).FirstOrDefault();
                if (prod == null) return default;
                else
                {
                    prod.ProductName = request.ProductName;
                    prod.UnitPrice = request.UnitPrice;
                    _context.Products.Update(prod);
                    await _context.SaveChangesAsync();
                    return prod.Id;
                }
            }
        }
    }
}
