using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Monolith.Repository.Contracts;
using Monolith.Web.Models;

namespace Monolith.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IManagerRepository _managerRepository;

    public HomeController(ILogger<HomeController> logger, IManagerRepository managerRepository)
    {
        _logger = logger;
        _managerRepository = managerRepository;
    }

    public async Task<IActionResult> Index()
    {
        var managers = await _managerRepository.GetManagersAsync(10, 0);
        return View(managers);
    }

    public async Task< IActionResult> CreateManager()
    {
        await _managerRepository.CreateManagerAsync();

        return RedirectToAction("Index");
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