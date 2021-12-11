using BookStoreBE.Domain.Entities;
using BookStoreBE.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookStoreBE.Service.Features.CategoryFeatures.Queries
{
    public class GetAllCategoryQuery : IRequest<IEnumerable<Category>>
    {
        public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, IEnumerable<Category>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllCategoryQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
            {
                var categories = await _context.Categories.Include(c => c.Products).ToListAsync();
                if (categories == null)
                {
                    return null;
                }
                return categories.AsReadOnly();
            }
        }
    }
}
