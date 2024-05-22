using FirstProjectASP.Models;

namespace FirstProjectASP.Services;

public class ActionHistoryService
{
    private readonly List<RouteResponse> _actions = new List<RouteResponse>();

    public void AddAction(RouteResponse action)
    {
        _actions.Add(action);
    }

    public List<RouteResponse> GetAction()
    {
        return _actions.OrderByDescending(x => x.Timestamp).ToList();
    }
}