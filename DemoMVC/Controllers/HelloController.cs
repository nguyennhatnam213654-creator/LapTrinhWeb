using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;

namespace DemoMVC.Controllers;

public class HelloController : Controller
{
    public IActionResult Hello()
    {
        return View();
    }
}   