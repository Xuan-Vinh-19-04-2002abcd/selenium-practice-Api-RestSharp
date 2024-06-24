using Newtonsoft.Json;

namespace Practice.Services.Model.Response;

public class CreateUserDtoRes
{
    [JsonProperty("code")] 
    public int Code { get; set; }

    [JsonProperty("meta")] 
    public object Meta { get; set; }  

    [JsonProperty("data")] 
    public UserRes Data { get; set; }
}
