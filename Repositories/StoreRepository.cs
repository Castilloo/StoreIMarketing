using System.Globalization;
using System.Text.RegularExpressions;
using IMarketing.Interfaces;
using Microsoft.EntityFrameworkCore;
using TiendaIMark.Models;
using TiendaIMark.Models.DataTransferObjects;
using TiendaIMark.Models.Dto;

namespace IMarketing.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly IMarketingContext _dbcontext;

        public StoreRepository(IMarketingContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        // public async Task<IList<ProductDetalleDto>> GetProductsGeneral()
        public async Task<IList<PrincipalProductDto>> GetGeneralProducts()
        {
            try
            {
                List<PrincipalProductDto> products = await _dbcontext.Sales
                    .Select(
                        p => new PrincipalProductDto 
                        {
                            Id = p.IdSale,
                            Product = new ProductDto 
                            { 
                                IdProduct = p.IdProductNavigation!.IdProduct,
                                Name = p.IdProductNavigation.Name,
                                Brand = p.IdProductNavigation.Brand,
                                Descripcion = p.IdProductNavigation.Descripcion,
                                IsNew = p.IdProductNavigation.IsNew,
                                Quantity = p.IdProductNavigation.Quantity,
                                Price = p.IdProductNavigation.Price,
                                Category = new CategoryDto
                                {
                                    IdCategory = p.IdProductNavigation.IdCategoryNavigation!.IdCategory,
                                    Name = p.IdProductNavigation.IdCategoryNavigation.Name
                                }
                            },

                            QuantitySold = p.QuantitySold,

                            Seller = new SellerDto 
                            {
                                IdSeller = p.IdSellerNavigation!.IdSeller,
                                Name = p.IdSellerNavigation.Name,
                                IsGoodAssessment = p.IdSellerNavigation.IsGoodAssessment,
                                City = p.IdSellerNavigation.City
                            },

                            Image = new PrincipalImageDto 
                            {
                                IdImages = p.IdProductNavigation.IdImagesNavigation!.IdImages,
                                Url = p.IdProductNavigation.IdImagesNavigation!.Url1
                            }
                        })
                        .OrderBy(p => p.Id)
                        .ToListAsync();

                return products;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al conectarse a la base de datos: " + ex.Message);
            }
        }

        public async Task<IList<PrincipalProductDto>> GetGeneralProductsByInputText(string text)
        {
            try
            {
                IList<PrincipalProductDto> productsFiltered = await GetGeneralProducts();
                string textWithoutAccent = ReplaceAccent(text.Trim());

                return productsFiltered.Where(p => 
                    ReplaceAccent(p.Product!.Name!).Contains(textWithoutAccent, StringComparison.CurrentCultureIgnoreCase) || 
                    ReplaceAccent(p.Product!.Category!.Name!).Contains(textWithoutAccent, StringComparison.CurrentCultureIgnoreCase) ||
                    ReplaceAccent(p.Product.Brand!).Contains(textWithoutAccent, StringComparison.CurrentCultureIgnoreCase)
                    ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectarse a la base de datos: " + ex.Message);
            }
        }

        public async Task<IList<ProductDetailDto>> GetProductDetailById(int id)
        {
            try
            {
                List<ProductDetailDto> productDetailById = await _dbcontext.Sales
                .Select(p => 
                    new ProductDetailDto 
                    {
                        Id = p.IdProductNavigation!.IdProduct,
                        Product = new ProductDto
                        {
                            IdProduct = p.IdProductNavigation!.IdProduct,
                            Name = p.IdProductNavigation!.Name,
                            Brand = p.IdProductNavigation!.Brand,
                            Descripcion = p.IdProductNavigation!.Descripcion,
                            IsNew = p.IdProductNavigation!.IsNew,
                            Quantity = p.IdProductNavigation!.Quantity,
                            Price = p.IdProductNavigation!.Price,
                            Category = new CategoryDto 
                            {
                                IdCategory = p.IdProductNavigation!.IdCategoryNavigation!.IdCategory,
                                Name = p.IdProductNavigation!.IdCategoryNavigation!.Name
                            }
                        },

                        QuantitySold = p.QuantitySold,

                        Image = new ImageDto
                        {
                            IdImages = p.IdProductNavigation!.IdImagesNavigation!.IdImages,
                            Url1 = p.IdProductNavigation!.IdImagesNavigation!.Url1,
                            Url2 = p.IdProductNavigation!.IdImagesNavigation!.Url2,
                            Url3 = p.IdProductNavigation!.IdImagesNavigation!.Url3,
                            Url4 = p.IdProductNavigation!.IdImagesNavigation!.Url4,
                            Url5 = p.IdProductNavigation!.IdImagesNavigation!.Url5
                        }
                    })
                    .Where(p => p.Product!.IdProduct == id)
                    .ToListAsync();

                return productDetailById;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error en la base de datos " + ex.Message, ex);
            }
        }
        
        public async Task<IList<PrincipalProductDto>> GetGeneralProductsByCategories(CategoryRequest categories)
        {
            var productByCategories = new List<PrincipalProductDto>();
            foreach (var category in categories.Categories!)
            {
                var productsFiltered = await GetGeneralProductsByInputText(category);
                
                foreach (var product in productsFiltered)
                {
                    productByCategories.Add(product);
                }
            }

            return productByCategories;
        }
        private string ReplaceAccent(string text)
        {
            Regex regex = new Regex("[áéíóúü]");

            string textWithoutAccent = regex.Replace(text, t => t.Value.ToLower() switch 
            {
                "á" => "a",
                "é" => "e",
                "í" => "i",
                "ó" => "o",
                "ú" => "u",
                "ü" => "u",
                _ => t.Value
            });

            return textWithoutAccent;
        }

    }
}