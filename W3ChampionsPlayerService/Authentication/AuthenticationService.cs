using MongoDB.Driver;
using W3ChampionsPlayerService.Models;
using W3ChampionsPlayerService.Services;

namespace W3ChampionsPlayerService.Authentication;

public class AuthenticationService(
    MongoClient mongoClient,
    W3CAuthenticationService authenticationService,
    WebsiteBackendService websiteBackendService
        ) : MongoDbRepositoryBase(mongoClient)
{
    private readonly W3CAuthenticationService _authenticationService = authenticationService;
    private readonly WebsiteBackendService _websiteBackendService = websiteBackendService;

    public async Task<WebSocketUser?> GetUser(string? token)
    {
        try
        {
            var w3cUserAuthentication = _authenticationService.GetUserByToken(token);
            if (w3cUserAuthentication == null) return null;
            var user = await _websiteBackendService.GetUser(w3cUserAuthentication.BattleTag);
            if (user == null) return null;
            return new WebSocketUser(user.BattleTag);
        }
        catch (Exception)
        {
            return null;
        }
    }
}
