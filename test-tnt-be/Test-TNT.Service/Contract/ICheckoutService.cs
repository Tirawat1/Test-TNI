using Test_TNT.Domain.Dto;

namespace Test_TNT.Service.Contract;

public interface ICheckoutService
{
    Task<CheckoutResult> Checkout(CheckoutRequestDto request);
}

// ผลลัพธ์เฉพาะของ checkout เท่านั้น (ไม่ใช่ error scheme กลางของระบบ)
public class CheckoutResult
{
    public bool Success { get; init; }
    public string? ErrorCode { get; init; }
    public string? ErrorMessage { get; init; }
    public CheckoutResponseDto? Data { get; init; }

    public static CheckoutResult Ok(CheckoutResponseDto data) => new() { Success = true, Data = data };

    public static CheckoutResult Fail(string errorCode, string errorMessage) =>
        new() { Success = false, ErrorCode = errorCode, ErrorMessage = errorMessage };
}
