using DAL.DataContext;
using DAL.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Services.Products.Queries
{
    public class GetAllProductsQuery : IRequest<List<Product>>
    {
    }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly ApplicationDbContext _context;
        public GetAllProductsQueryHandler(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.Include(c=>c.Reviews).ToListAsync();
            return products;
        }
    }
}
