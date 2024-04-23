using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaIMark.Models.Dto;

namespace TiendaIMark.Models.DataTransferObjects
{
    public class ProductDetailDto
    {
        public int Id { get; set;}
        public ProductDto? Product{ get; set; }
        public int? QuantitySold { get; set; }
        public ImageDto? Image { get; set; }
    }
}