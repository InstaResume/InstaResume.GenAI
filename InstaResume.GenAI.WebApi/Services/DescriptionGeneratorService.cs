using InstaResume.GenAI.WebApi.Configuration.Interface;
using InstaResume.GenAI.WebApi.Models;
using InstaResume.GenAI.WebApi.Models.Request;
using InstaResume.GenAI.WebApi.Services.Interface;
using OpenAI_API;
using OpenAI_API.Models;

namespace InstaResume.GenAI.WebApi.Services;

public class DescriptionGeneratorService : IDescriptionGeneratorService
{
    private IConfigHelper _configHelper;

    public DescriptionGeneratorService(IConfigHelper configHelper)
    {
        _configHelper = configHelper;
    }

    public async Task<GeneratedDescription> GenerateDescription(GetGenDescriptionRequest descRequest)
    {
        var openAiApi = new OpenAIAPI(_configHelper.GetOpenAiConfig().ApiKey);
        var chat = openAiApi.Chat.CreateConversation();
        chat.Model = Model.ChatGPTTurbo;
        chat.RequestParameters.Temperature = 0.8;
        chat.AppendSystemMessage(
            "You are a job seeker looking for a job. You want to generate a description for your resume.");
        chat.AppendUserInput(
            "Create a work experience description in short for software engineer position at Agoda containing the keywords Agoda Homes, improve host experiences, help Agoda's engineers");
        chat.AppendExampleChatbotOutput("""
                                        • Continuously improving Agoda Homes’ host experiences. Making their property management easier.
                                        • Helped on product decision evaluation as Agoda’s engineers are not limited to development work.
                                        """);
        chat.AppendUserInput(
            $"Create a work experience description in short for {descRequest.JobPosition} position at {descRequest.Company} containing the keywords {string.Join(", ", descRequest.Keywords)}. And this is my draft description; {descRequest.DraftDescription}");
        var response = await chat.GetResponseFromChatbotAsync();
        return new GeneratedDescription
        {
            Keywords = descRequest.Keywords,
            Description = response
        };
    }
}