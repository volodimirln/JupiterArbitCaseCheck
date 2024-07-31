using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace JupiterWebAPI.Models;

public partial class FavorieCase
{
    [JsonProperty("Id")]
    public int Id { get; set; }
    [JsonProperty("Date")]
    public string Date { get; set; } = null!;
    [JsonProperty("Judge")]
    public string Judge { get; set; } = null!;
    [JsonProperty("Court")]
    public string? Court { get; set; }
    [JsonProperty("CaseNumber")]
    public string? CaseNumber { get; set; }
    [JsonProperty("Plaintiff")]
    public string? Plaintiff { get; set; }
    [JsonProperty("СaseLink")]
    public string? СaseLink { get; set; }
    [JsonProperty("Respondent")]
    public string? Respondent { get; set; }
    [JsonProperty("UserId")]
    public string? UserId { get; set; }
    //UserId
}
