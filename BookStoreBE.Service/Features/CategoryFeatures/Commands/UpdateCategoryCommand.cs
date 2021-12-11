using BookStoreBE.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookStoreBE.Service.Features.CategoryFeatures.Commands
{
    public class UpdateCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateCategoryCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                var cate = _context.Categories.Where(p => p.Id == request.Id).FirstOrDefault();
                if (cate == null) return default;
                else
                {
                    cate.CategoryName = request.CategoryName;
                    cate.Description = request.Description;
                    _context.Categories.Update(cate);
                    await _context.SaveChangesAsync();
                    return cate.Id;
                }
            }
        }
    }
}
