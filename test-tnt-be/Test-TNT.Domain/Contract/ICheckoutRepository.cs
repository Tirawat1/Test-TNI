using Test_TNT.Domain.Dto;
using Test_TNT.Domain.Models;

namespace Test_TNT.Domain.Contract;

// Repository = ที่เก็บของเท่านั้น ไม่มีกฎธุรกิจ รับ-ส่งเป็น Domain model ล้วน (ไม่รับ DTO)
public interface ICheckoutRepository
{
    Task<List<CheckoutResponseDto>> Checkout();

}
