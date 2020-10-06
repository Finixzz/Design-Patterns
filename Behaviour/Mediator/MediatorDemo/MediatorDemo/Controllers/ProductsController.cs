using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Dtos.ProductDtos;
using DAL.Entities;
using DAL.Services.Products.Commands;
using DAL.Services.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private IMapper _mapper;

        public ProductsController(IMediator _mediator, IMapper _mapper)
        {
            this._mediator = _mediator;
            this._mapper = _mapper;
        }


        /*
             <summary>
                    Returns all products
             </summary>
             <remarks>
             Sample request:
            
                 GET /api/products

            </remarks>
            <response code="200">Returns product info if okay</response>
         */

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var query = new GetAllProductsQuery();
            var result= await _mediator.Send(query);
            return Ok(result);
        }


        /*
             <summary>
                    Returns single product
             </summary>
             <remarks>
             Sample request:
            
                 GET /api/products/1
                 

            </remarks>
            <response code="200">Returns product info if found</response>
            <response code="404">If something goes wrong</response> 

         */

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        /*
             <summary>
                    Creates product from raw JSON
             </summary>
             <remarks>
                 Sample request:
            
                 POST /api/products
                 {
                    "name": "Sample item",
                    "unitPrice": 1.55,
                    "unitsInStock": 20
                  }

            </remarks>
            <response code="201">Returns product info if okay</response>
            <response code="400">If something goes wrong</response> 

         */
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDto productDto)
        {
            ModelState.Remove("productDto.Id");
            if (!ModelState.IsValid)
                return BadRequest();

            var command = new CreateProductCommand(_mapper.Map<ProductDto, Product>(productDto));
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(result), new { id = result.Id }, result);
        }



        /*
             <summary>
                    Edits existing product data from raw JSON
             </summary>
             <remarks>

                 Sample request:
            
                 PUT /api/products/1
                 {
                    "name": "Sample item name edit",
                    "unitPrice": 1.55,
                    "unitsInStock": 20
                  }

            </remarks>
            <response code="200">Returns updated product info if okay</response>
            <response code="400">If model state is not valid</response> 
            <response code="404">If product doesen't exist in database</response>

         */
        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct(ProductDto productDto,int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var command = new UpdateProductCommand(_mapper.Map<ProductDto, Product>(productDto), id);
            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();
            
            return Ok(result);
        }





        /*
             <summary>
                    Deletes existing product in database
             </summary>
             <remarks>
             Sample request:
            
                 DELETE /api/products/1
                 

            </remarks>
            <response code="200">Returns deleted product</response>
            <response code="400">If product doesen't exist in database</response>

         */
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand(id);
            var result = await _mediator.Send(command);
            if (result == null)
                return BadRequest();

            return Ok(result);
        }
        
    }
}
