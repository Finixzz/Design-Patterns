using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Dtos.ReviewDtos;
using DAL.Entities;
using DAL.Services.Reviews.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public ReviewsController(IMediator _mediator,IMapper _mapper)
        {
            this._mediator = _mediator;
            this._mapper = _mapper;
        }


        /*
             <summary>
                    Creates product review from raw JSON
             </summary>
             <remarks>

                 Sample request:
            
                 POST /api/reviews
                 {
                    "mark": 3,
                    "productId": 1
                }

            </remarks>
            <response code="201">Returns product review info if okay</response>
            <response code="400">If model state is not valid</response> 
            <response code="500">
                If referential integrity is violated eg: Adding product review
                for product that doesent exist in database
            </response> 

         */
        [HttpPost]
        public async Task<IActionResult> AddProductReview(ReviewDto reviewDto)
        {
            ModelState.Remove("reviewDto.Id");
            if (!ModelState.IsValid)
                return BadRequest();

            var command = new AddProductReviewCommand(_mapper.Map<ReviewDto,Review>(reviewDto));
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(result), new { id = result.Id }, result);

        }
    }
}
