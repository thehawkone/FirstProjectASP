using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstProjectASP.Models;

namespace FirstProjectASP.Controllers;

public class HomeController(IConfiguration configuration, ILogger<HomeController> logger)
    : Controller
{
    private readonly ILogger<HomeController> _logger = logger;
    private readonly IConfiguration _configuration = configuration;

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
        ViewBag.Message = "Details button clicked!";
        return View();
    }
    public IActionResult Index()
    {
        var adminName = _configuration.GetSection("Admin:name");
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}