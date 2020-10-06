using DAL.DataContext;
using DAL.Dtos.ProductDtos;
using DAL.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Services.Products.Queries
{
    public class GetAllProductsQuery : IRequest<List<ProductListDto>>
    {
    }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductListDto>>
    {
        private readonly ApplicationDbContext _context;
        public GetAllProductsQueryHandler(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public async Task<List<ProductListDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.Select(p => new ProductListDto
            {
                Id=p.Id,
                Name = p.Name,
                UnitPrice = p.UnitPrice,
                UnitsInStock = p.UnitsInStock,
                ReviewsCount = p.Reviews.Count(),
                ReviewsAverageVotes = p.Reviews.Select(y => (double?)y.Mark).Average()
            }).ToListAsync();
        }
    }
}
