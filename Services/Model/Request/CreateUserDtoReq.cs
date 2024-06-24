using System.Security.Cryptography;
using Newtonsoft.Json;

namespace Practice.Services.Model.Request;

public class CreateUserDtoReq
{
    [JsonProperty("name")] 
    public string Name { get; set; }
    [JsonProperty("email")] 
    public string Email { get; set; }
    [JsonProperty("gender")] 
    public string Gender { get; set; }
    [JsonProperty("status")] 
    public string Status { get; set; }
}   