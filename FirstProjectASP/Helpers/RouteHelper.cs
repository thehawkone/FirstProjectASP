using FirstProjectASP.Models;

namespace FirstProjectASP.Helpers;

public class RouteHelper
{
    public void CurrentRoute(RouteData routeData)
    {
        var route = RouteResponse.Routes
            .FirstOrDefault(x => x.Controller == routeData.Values["Controller"]
            && x.Action == routeData.Values["Action"]);

        if (route == null)
        {
            var routeResponse = new RouteResponse()
            {
                Controller = routeData.Values["Controller"]?.ToString(),
                Action = routeData.Values["Action"]?.ToString(),
            };
            RouteResponse.Routes.Add(routeResponse);
        }
    }
}