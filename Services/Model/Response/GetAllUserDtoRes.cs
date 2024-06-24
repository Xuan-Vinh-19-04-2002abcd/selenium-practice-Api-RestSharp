using Newtonsoft.Json;

namespace Practice.Services.Model.Response;

public class GetAllUserDtoRes
{
    [JsonProperty("code")] 
    public int Code { get; set; }
    [JsonProperty("Meta")] 
    public MetaDtoRes Meta { get; set; }
    [JsonProperty("data")] 
    public List<UserRes> Data { get; set; }
}