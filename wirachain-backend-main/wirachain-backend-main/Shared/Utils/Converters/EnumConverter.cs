using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wirachain_backend.Shared.Extensions.Enumerations;
using wirachain_backend.Shared.Extensions.String;

namespace wirachain_backend.Shared.Utils.Converters;

public class EnumConverter<TEnum> : ValueConverter<TEnum, string>
    where TEnum : struct, Enum
{
    public EnumConverter() : base(
        enumT => enumT.ToDbSnakeCaseString(), // For DB.
        str => (TEnum)str.FromSnakeCaseToUpperCamelCase().ToEnum<TEnum>()! // For Application.
    ) {}
}