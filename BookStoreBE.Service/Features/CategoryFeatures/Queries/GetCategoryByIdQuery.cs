using BookStoreBE.Domain.Entities;
using BookStoreBE.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookStoreBE.Service.Features.CategoryFeatures.Queries
{
    public class GetCategoryByIdQuery : IRequest<Category>
    {
        public int Id { get; set; }
        public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
        {
            private readonly IApplicationDbContext _context;
            public GetCategoryByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
            {
                var product = await _context.Categories.Where(p => p.Id == request.Id).FirstOrDefaultAsync();
                if (product == null) return null;
                return product;
            }
        }
    }
}
