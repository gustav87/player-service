namespace W3ChampionsPlayerService.Models;

public class WebSocketUser(string battleTag)
{
    public string BattleTag { get; set; } = battleTag;
    public string? ConnectionId {get; set; }
}
