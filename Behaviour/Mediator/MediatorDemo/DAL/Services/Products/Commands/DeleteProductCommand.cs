using AutoMapper;
using DAL.DataContext;
using DAL.Dtos.ProductDtos;
using DAL.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Services.Products.Commands
{
    public class DeleteProductCommand : IRequest<ProductDto>
    {
        public int ProductId { get; }

        public DeleteProductCommand(int ProductId)
        {
            this.ProductId = ProductId;
        }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ProductDto>
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public DeleteProductCommandHandler(ApplicationDbContext _context,
                                           IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }
        public async Task<ProductDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Product productInDb = await  _context.Products.SingleOrDefaultAsync(c=>c.Id==request.ProductId);
            if (productInDb == null)
                return null;

            _context.Products.Remove(productInDb);

            await _context.SaveChangesAsync();

            return _mapper.Map<Product, ProductDto>(productInDb);
        }
    }
}
