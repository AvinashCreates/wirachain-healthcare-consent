using wirachain_backend.Shared.Extensions.String;

namespace wirachain_backend.Shared.Extensions.Enumerations;

public static class EnumExtensions
{
    public static string ToDbUpperCaseString<TEnum>(this TEnum value) where TEnum : Enum => value.ToString().ToUpper();
    public static string ToDbSeparatedUpperCaseString<TEnum>(this TEnum value) where TEnum : Enum => value.ToString().ToSeparateByUpperCase();

    public static string ToDbSnakeCaseString<TEnum>(this TEnum value) where TEnum : Enum => value.ToString().ToSnakeCase();
    
    public static TEnum? ToEnum<TEnum>(this string value) where TEnum : struct, Enum =>
        string.IsNullOrWhiteSpace(value) ? null : Enum.TryParse(value, true, out TEnum result) ? result : null;
}