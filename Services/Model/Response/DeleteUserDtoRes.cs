using Newtonsoft.Json;

namespace Practice.Services.Model.Response;

public class DeleteUserDtoRes
{
    [JsonProperty("code")] 
    public int Code { get; set; }

    [JsonProperty("meta")] 
    public object Meta { get; set; }  

    [JsonProperty("data")] 
    public object Data { get; set; }
}