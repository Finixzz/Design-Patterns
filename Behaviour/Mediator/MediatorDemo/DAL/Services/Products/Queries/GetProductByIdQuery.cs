using DAL.DataContext;
using DAL.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace DAL.Services.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; }

        public GetProductByIdQuery(int Id)
        {
            this.Id = Id;
        }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly ApplicationDbContext _context;

        public GetProductByIdQueryHandler(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var productInDb = await _context.Products.Include(c => c.Reviews).SingleOrDefaultAsync(c => c.Id == request.Id);
            return productInDb;

        }
    }
}
