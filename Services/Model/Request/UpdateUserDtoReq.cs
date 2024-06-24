using Newtonsoft.Json;

namespace Practice.Services.Model.Request;

public class UpdateUserDtoReq 
{
    [JsonProperty("gender")]
    public string Gender { get; set; }
    [JsonProperty("email")]
    public string Email { get; set; }
    [JsonProperty("status")]
    public string Status { get; set; }
}