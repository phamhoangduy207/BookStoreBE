using BookStoreBE.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookStoreBE.Service.Features.CategoryFeatures.Commands
{
    public class DeleteCategoryByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteCategoryByIdCommadHandler : IRequestHandler<DeleteCategoryByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteCategoryByIdCommadHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteCategoryByIdCommand request, CancellationToken cancellationToken)
            {
                var category = await _context.Categories.Where(c => c.Id == request.Id).FirstOrDefaultAsync();
                if (category == null) return default;
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return category.Id;
            }
        }
    }
}
