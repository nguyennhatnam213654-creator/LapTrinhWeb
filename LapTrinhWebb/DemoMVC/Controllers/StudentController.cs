using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;

namespace DemoMVC.Controllers;

public class StudentController : Controller
{
    [HttpGet] // Hiển thị form
    public IActionResult Index()
    {
        return View(new StudentViewModel());
    }

    [HttpPost] // Nhận dữ liệu từ form
    public IActionResult Index(StudentViewModel model) 
    {
        if (ModelState.IsValid && !string.IsNullOrEmpty(model.MSSV))
        {
            // Thêm vào danh sách sinh viên đã đăng ký
            StudentViewModel.RegisteredStudents.Add(new StudentViewModel
            {
                MSSV = model.MSSV,
                Name = model.Name,
                DiemTB = model.DiemTB,
                Major = model.Major
            });
            
            // Đếm số SV cùng ngành
            model.CountSameMinor = StudentViewModel.RegisteredStudents.Count(s => s.Major == model.Major);
            
            return View(model); // Hiển thị lại dữ liệu đã nhập + số lượng
        }
        return View(model);
    }
}