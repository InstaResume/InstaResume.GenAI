using InstaResume.GenAI.WebApi.Connections.Interface;
using StackExchange.Redis;

namespace InstaResume.GenAI.WebApi.Connections;

public class CacheConnectionProvider : ICacheConnectionProvider
{
    public CacheConnectionProvider()
    {
        var redis = ConnectionMultiplexer.Connect("localhost");
        var db = redis.GetDatabase();
    }
}