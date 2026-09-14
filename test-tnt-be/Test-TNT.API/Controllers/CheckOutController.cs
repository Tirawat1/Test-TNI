using Microsoft.AspNetCore.Mvc;
using Test_TNT.Domain.Dto;
using Test_TNT.Service.Contract;

namespace Test_TNT.API.Controllers;

[ApiController]
[Route("api/checkout")]
public class CheckOutController : ControllerBase
{
    private readonly ICheckoutService _service;

    public CheckOutController(ICheckoutService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Checkout([FromBody] CheckoutRequestDto request)
    {
        var result = await _service.Checkout(request);

        if (result.Success)
            return Ok(result.Data);

        var status = result.ErrorCode switch
        {
            "PRODUCT_NOT_FOUND" => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status400BadRequest,
        };

        return StatusCode(status, new { code = result.ErrorCode, message = result.ErrorMessage });
    }
}
