using AutoMapper;
using DAL.DataContext;
using DAL.Dtos.ProductDtos;
using DAL.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Services.Products.Commands
{
    public class CreateProductCommand : IRequest<ProductDto>
    {
        public Product NewProduct { get; set; }

        public CreateProductCommand(Product NewProduct)
        {
            this.NewProduct = NewProduct;
        }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        public CreateProductCommandHandler(ApplicationDbContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }
        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _context.Products.Add(request.NewProduct);
            await _context.SaveChangesAsync();
            return _mapper.Map<Product,ProductDto>(request.NewProduct);
        }
    }
}
