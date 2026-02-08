using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;

namespace DemoMVC.Controllers;

public class SanPhamController : Controller
{
    public IActionResult BaiTap2()
    {
        var sanPham = new SanPhamViewModel
        {
            TenSanPham = "Laptop Dell XPS 13",
            Gia = 25000000,
            AnhSanPham = "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcTmCWuMwWFHE1o0Mt5oJcSCDiEpOimei0zSMXGXN7w2JCLmPOI5918kyVbmXaSIE3lMsaugJ-qJ92Xyn-qTnloA4vekJrkOPK8GG4ltFpLGKqD1LKCJIWFX&usqp=CAc"
        };
        return View(sanPham);
    }
}
