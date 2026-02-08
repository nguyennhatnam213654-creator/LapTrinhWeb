using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;

namespace DemoMVC.Controllers;

public class TodolistController : Controller
{
    // Lưu trữ danh sách công việc (static)
    private static List<JobViewModel> congViecList = new()
    {
        new JobViewModel { MaCongViec = 1, TenCongViec = "Làm bài tập", TrangThai = true },
        new JobViewModel { MaCongViec = 2, TenCongViec = "Viết báo cáo", TrangThai = false },
        new JobViewModel { MaCongViec = 3, TenCongViec = "Ôn tập", TrangThai = true }
    };

    [HttpGet("/XemList")]
    public IActionResult XemList()
    {
        return View(congViecList);
    }

    [HttpGet]
    public IActionResult Them()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Them(JobViewModel model)
    {
        if (ModelState.IsValid && !string.IsNullOrEmpty(model.TenCongViec))
        {
            // Tạo mã công việc mới
            model.MaCongViec = congViecList.Count > 0 ? congViecList.Max(x => x.MaCongViec) + 1 : 1;
            
            // Thêm vào danh sách
            congViecList.Add(model);
            
            // Quay lại danh sách
            return RedirectToAction("XemList");
        }
        return View(model);
    }
    [HttpGet("/XemList/Xoa/{MaCongViec}")]
    public IActionResult Xoa(int MaCongViec) // Nhận mã công việc cần xóa
    {
        var congViec = congViecList.FirstOrDefault(x => x.MaCongViec == MaCongViec);
        if (congViec == null)
        {
            return RedirectToAction("XemList");
        }
        return View(congViec);
    }

    [HttpPost("/XemList/Xoa/{MaCongViec}")]
    public IActionResult Xoa(JobViewModel model)    // Nhận dữ liệu từ form
    {
        var congViec = congViecList.FirstOrDefault(x => x.MaCongViec == model.MaCongViec);
        if (congViec != null)
        {
            congViecList.Remove(congViec);
            int ma = 1;
            foreach (var n in congViecList){
                n.MaCongViec = ma++;
            }
        }
        return RedirectToAction("XemList");
    }
    [HttpGet("/XemList/Sua/{MaCongViec}")] 
    public IActionResult Sua(int MaCongViec)
    {
        var congViec = congViecList.FirstOrDefault(x => x.MaCongViec == MaCongViec);
        if (congViec == null)
        {
            return RedirectToAction("XemList");
        }
        return View(congViec);
    }

    [HttpPost("/XemList/Sua/{MaCongViec}")]
    public IActionResult Sua(JobViewModel model)
    {
        var congViec = congViecList.FirstOrDefault(x => x.MaCongViec == model.MaCongViec);
        if (congViec != null)
        {
            // Cập nhật thông tin công việc
            congViec.TenCongViec = model.TenCongViec;
            congViec.TrangThai = model.TrangThai;
        }
        return RedirectToAction("XemList");
    }
    [HttpGet("/XemList/ChiTiet/{MaCongViec}")]
    public IActionResult ChiTiet(int MaCongViec)
    {
        var congViec = congViecList.FirstOrDefault(x => x.MaCongViec == MaCongViec);
        if (congViec == null)
        {
            return RedirectToAction("XemList");
        }
        return View(congViec);
    }
}