using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Controllers;

public class NameController : Controller
{
    public IActionResult ShowName()
    {
        
        return View();
    }
}