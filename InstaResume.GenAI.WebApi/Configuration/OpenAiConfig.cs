using InstaResume.GenAI.WebApi.Configuration.Interface;

namespace InstaResume.GenAI.WebApi.Configuration;

public class OpenAiConfig : IConfig
{
    public string ConfigKey { get; init; } = "OpenAi";
    public string ApiKey { get; init; }
}