using AutoMapper;
using DAL.DataContext;
using DAL.Dtos.ReviewDtos;
using DAL.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Services.Reviews.Commands
{
    public class AddProductReviewCommand : IRequest<ReviewDto>
    {
        public Review NewProductReview { get; set; }

        public AddProductReviewCommand(Review NewProductReview)
        {
            this.NewProductReview = NewProductReview;
        }
    }

    public class AddProductReviewCommandHandler : IRequestHandler<AddProductReviewCommand, ReviewDto>
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public AddProductReviewCommandHandler(ApplicationDbContext _context,
                                             IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }
        public async Task<ReviewDto> Handle(AddProductReviewCommand request, CancellationToken cancellationToken)
        {
            _context.ProductReviews.Add(request.NewProductReview);
            await _context.SaveChangesAsync();
            return _mapper.Map<Review, ReviewDto>(request.NewProductReview);
            
        }
    }
}
