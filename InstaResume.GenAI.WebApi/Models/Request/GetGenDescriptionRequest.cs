using Newtonsoft.Json;

namespace InstaResume.GenAI.WebApi.Models.Request;

public class GetGenDescriptionRequest
{
    [JsonProperty("keywords")]
    public List<string> Keywords { get; set; }
    
    [JsonProperty("draftDescription")]
    public string DraftDescription { get; set; }
    
    [JsonProperty("company")]
    public string Company { get; set; }
    
    [JsonProperty("jobPosition")]
    public string JobPosition { get; set; }
}