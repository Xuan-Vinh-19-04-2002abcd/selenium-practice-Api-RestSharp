﻿using Newtonsoft.Json;

namespace Practice.Services.Model.Response;

public class UserRes
{
    [JsonProperty("id")] 
    public int Id { get; set; }

    [JsonProperty("name")] 
    public string Name { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("gender")]
    public string Gender { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }
}