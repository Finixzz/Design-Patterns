using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Dtos.ProductDtos
{
    public class ProductListDto
    {
        public int Id { get; set; }

        [Required]
        [DataType("varchar(100)")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public int UnitsInStock { get; set; }

        public int ReviewsCount { get; set; }

        public double? ReviewsAverageVotes { get; set; }
    }
}
