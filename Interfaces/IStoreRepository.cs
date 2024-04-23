using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaIMark.Models;
using TiendaIMark.Models.DataTransferObjects;
using TiendaIMark.Models.Dto;

namespace IMarketing.Interfaces
{
    public interface IStoreRepository
    {
        Task<IList<PrincipalProductDto>> GetGeneralProducts();
        Task<IList<PrincipalProductDto>> GetGeneralProductsByInputText(string inputText);
        Task<IList<ProductDetailDto>> GetProductDetailById(int id);
        Task<IList<PrincipalProductDto>> GetGeneralProductsByCategories(CategoryRequest categories);
    }

}