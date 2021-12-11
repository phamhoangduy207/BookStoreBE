using BookStoreBE.Domain.Entities;
using BookStoreBE.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BookStoreBE.Service.Features.CategoryFeatures.Commands
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string CategoryName { get; set; }
        public string Description{ get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateCategoryCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = new Category
                {
                    CategoryName = request.CategoryName,
                    Description = request.Description
                };

                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return category.Id;
            }
        }
    }
}
