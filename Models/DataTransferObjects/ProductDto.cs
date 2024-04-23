using TiendaIMark.Models.DataTransferObjects;

namespace TiendaIMark.Models.Dto
{
    public class ProductDto
    {
        public int IdProduct { get; set; }
        public string? Name { get; set; }
        
        public string? Brand { get; set; }

        public string? Descripcion { get; set; }

        public bool? IsNew { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }
        public CategoryDto? Category { get; set; }
    }
}