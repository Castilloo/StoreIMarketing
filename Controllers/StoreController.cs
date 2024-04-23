using System.Net;
using IMarketing.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TiendaIMark.Models.DataTransferObjects;
using TiendaIMark.Models.Dto;

namespace IMarketing.Controllers;

[ApiController]
[Route("api/store")]
public class StoreController : ControllerBase
{
    private readonly IStoreRepository _storeRepository;
    private readonly ILogger<StoreController> _logger;

    public StoreController(ILogger<StoreController> logger, IStoreRepository storeRepository)
    {
        _logger = logger;
        _storeRepository = storeRepository;
    }

    [HttpGet]
    [Route("products")]
    public async Task<IActionResult> GetAllGeneralProducts()
    {
        try
        {
            string? queryString = HttpContext.Request.Query["name"];

            dynamic response;

            if (queryString == null)
            {
                response = await _storeRepository.GetGeneralProducts();
            }
            else
            {
                response = await _storeRepository.GetGeneralProductsByInputText(queryString);
            }

            return Ok(new
            {
                Message = StatusCode(StatusCodes.Status200OK).StatusCode,
                Data = response
            });
        }
        catch (Exception ex)
        {
            throw new Exception("Error de respuesta" + ex.Message);
        }
    }

    [HttpGet]
    [Route("products/{id}")]
    public async Task<IActionResult> GetAllProductsById(int id)
    {
        try
        {
            var response = await _storeRepository.GetProductDetailById(id);

            return Ok(new
            {
                Message = StatusCode(StatusCodes.Status200OK).StatusCode,
                Data = response
            });

        }
        catch (Exception ex)
        {
            throw new Exception("Error de conexión" + ex.Message);
        }
    }

    [HttpPost]
    [Route("products")]
    public async Task<IActionResult> GetAllProductsByCategory([FromBody] CategoryRequest categories)
    {
        dynamic response;
        try
        {
            if (categories.Categories == null || categories.Categories.Count == 0)
            {
                return BadRequest("El cuerpo de la solicitud debe contener una lista de categorías");
            }
            else
            {
                response = await _storeRepository.GetGeneralProductsByCategories(categories);
            }

            return Ok(new
            {
                Message = StatusCode(StatusCodes.Status200OK).StatusCode,
                Data = response
            });
        }
        catch (Exception ex)
        {
            throw new Exception("Error de respuesta" + ex.Message);
        }
    }
}
