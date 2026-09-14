using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Test_TNT.Infrastructure.Models;

public class UtcDateTimeConverter : ValueConverter<DateTime, DateTime>
{
    public UtcDateTimeConverter() : base(
        v => DateTime.SpecifyKind(v, DateTimeKind.Unspecified),
        v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
    {
    }
}
