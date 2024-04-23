using TiendaIMark.Models.Dto;

namespace TiendaIMark.Models.DataTransferObjects
{
    public class PrincipalProductDto
    {
        public  int Id { get; set; }
        public ProductDto? Product { get; set; }
        public int? QuantitySold { get; set; }
        public SellerDto? Seller { get; set; }
        public PrincipalImageDto? Image { get; set; }

        // public ProductoPrincipalDto(int id)
        // {
        //     Id = id++;
        // }
    }
}