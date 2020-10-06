using AutoMapper;
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

namespace DAL.Services.Products.Commands
{
    public class UpdateProductCommand : IRequest<ProductDto>
    {
        public int ProductId { get; }

        public Product UpdatedProduct { get; }

        public UpdateProductCommand(Product UpdatedProduct,int ProductId)
        {
            this.UpdatedProduct = UpdatedProduct;
            this.ProductId = ProductId;
        }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public UpdateProductCommandHandler(ApplicationDbContext _contex,
                                           IMapper _mapper)
        {
            this._context = _contex;
            this._mapper = _mapper;
        }
        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product productInDb = await _context.Products.SingleOrDefaultAsync(c => c.Id == request.ProductId);
            if (productInDb == null)
                return null;

            productInDb.Name = request.UpdatedProduct.Name;
            productInDb.UnitPrice = request.UpdatedProduct.UnitPrice;
            productInDb.UnitsInStock = request.UpdatedProduct.UnitsInStock;

            var result=await _context.SaveChangesAsync();

            return _mapper.Map<Product, ProductDto>(productInDb);
        }
    }
}
