using Newtonsoft.Json;

namespace Practice.Services.Model.Response;

public class MetaDtoRes
{
    [JsonProperty("pagination")] 
    public Pagination Pagination { get; set; }
}

public class Pagination()
{
    [JsonProperty("total")] 
    public int Total { get; set; }
    [JsonProperty("pages")] 
    public int Pages { get; set; }
    [JsonProperty("page")] 
    public int Page { get; set; }
    [JsonProperty("limit")] 
    public int Limit { get; set; }
}