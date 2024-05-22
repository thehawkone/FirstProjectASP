using FirstProjectASP.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstProjectASP.Controllers;

public class UserActionsController : Controller
{
    private readonly ActionHistoryService _actionHistoryService;

    public UserActionsController(ActionHistoryService actionHistoryService)
    {
        _actionHistoryService = actionHistoryService;
    }

    public IActionResult Index()
    {
        var actions = _actionHistoryService.GetAction();
        return View(actions);
    }
}