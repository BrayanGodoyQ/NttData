using System.Text.Json.Serialization;

namespace RetoTecnico.src.Models.Dtos
{
    public class RandomUserApiResponse
    {
        [JsonPropertyName("results")]
        public List<UserResultResponse> Results { get; set; } = [];
    }

    public class UserResultResponse
    {
        [JsonPropertyName("gender")]
        public string Gender { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public NameDataResponse Name { get; set; } = new();

        [JsonPropertyName("location")]
        public LocationDataResponse Location { get; set; } = new();

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("dob")]
        public DobDataResponse Dob { get; set; } = new();

        [JsonPropertyName("picture")]
        public PictureDataResponse Picture { get; set; } = new();
    }

    public class NameDataResponse
    {
        [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;
        [JsonPropertyName("first")] public string First { get; set; } = string.Empty;
        [JsonPropertyName("last")] public string Last { get; set; } = string.Empty;
    }

    public class LocationDataResponse
    {
        [JsonPropertyName("city")] public string City { get; set; } = string.Empty;
        [JsonPropertyName("country")] public string Country { get; set; } = string.Empty;
    }

    public class DobDataResponse
    {
        [JsonPropertyName("date")] public DateTime Date { get; set; }
    }

    public class PictureDataResponse
    {
        [JsonPropertyName("large")] public string Large { get; set; } = string.Empty;
    }
}