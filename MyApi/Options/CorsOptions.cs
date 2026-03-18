namespace MyApi.Options;
public class CorsOptions
{
    public static readonly string SectionName = "Cors";

    public string[] AllowedOrigins { get; set; } = Array.Empty<string>();
}
