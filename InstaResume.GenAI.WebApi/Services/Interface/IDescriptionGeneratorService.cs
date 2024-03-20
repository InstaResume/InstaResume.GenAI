using System.Threading.Tasks;
using InstaResume.GenAI.WebApi.Models;
using InstaResume.GenAI.WebApi.Models.Request;

namespace InstaResume.GenAI.WebApi.Services.Interface;

public interface IDescriptionGeneratorService
{
    public Task<GeneratedDescription> GenerateDescription(GetGenDescriptionRequest descRequest);
}