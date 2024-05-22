using FirstProjectASP.Models;
using FirstProjectASP.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FirstProjectASP.Filters;

public class ActionLoggingFilter : IAsyncActionFilter
{
    private readonly ActionHistoryService _actionHistoryService;
    private IAsyncActionFilter _asyncActionFilterImplementation;

    public ActionLoggingFilter(ActionHistoryService actionHistoryService)
    {
        _actionHistoryService = actionHistoryService;
    }
    
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var resultContext = await next(); //call the action

        var actionName = context.ActionDescriptor.RouteValues["action"];
        var controllerName = context.ActionDescriptor.RouteValues["controller"];
        var user = context.HttpContext.User;
        var userId = user.Identity!.IsAuthenticated ? user.Identity.Name : "Anonymous";
        
        var userAction = new RouteResponse
        {
            ActionName = actionName,
            ControllerName = controllerName,
            Timestamp = DateTime.Now,
            UserId = userId
        };
        
        _actionHistoryService.AddAction(userAction);
    }
}