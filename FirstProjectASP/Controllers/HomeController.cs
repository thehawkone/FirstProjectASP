using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstProjectASP.Models;

namespace FirstProjectASP.Controllers;

public class HomeController(IConfiguration configuration, ILogger<HomeController> logger)
    : Controller
{
    [HttpGet]
    public IActionResult PrintValue()
    {
        var age = 18;
        var name = "Noname";
        var user = new User(name, age);
        return View(user);
    }

    public IActionResult ShowDetails()
    {
        logger.LogInformation("Controller: Home | View: ShowDetails");
        ViewBag.Message = "Details button clicked!";
        return View();
    }
    public IActionResult Index()
    {
        logger.LogInformation("Controller: Home | View: Index");
        var adminName = configuration.GetSection("Admin:name");
        return View();
    }

    public IActionResult Privacy()
    {
        logger.LogInformation("Controller: Home | View: Privacy");
        return View();
    }
    public IActionResult Error()
    {
        logger.LogError("Controller: Home | View: Error");
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}