using InstaResume.GenAI.WebApi.Configuration.Interface;

namespace InstaResume.GenAI.WebApi.Configuration;

public class ConfigHelper : IConfigHelper
{
    private readonly IConfiguration _configuration;

    public ConfigHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public OpenAiConfig GetOpenAiConfig()
    {
        var openAiConfig = new OpenAiConfig();
        _configuration.GetSection(openAiConfig.ConfigKey).Bind(openAiConfig);
        return openAiConfig;
    }
}