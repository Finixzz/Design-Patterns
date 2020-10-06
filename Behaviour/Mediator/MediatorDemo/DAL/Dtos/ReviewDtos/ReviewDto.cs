using DAL.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Dtos.ReviewDtos
{
    public class ReviewDto
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 5)]
        public int Mark { get; set; }

        [Required]
        public int ProductId { get; set; }

    }
}
