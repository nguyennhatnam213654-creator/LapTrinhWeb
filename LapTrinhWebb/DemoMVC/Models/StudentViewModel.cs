namespace DemoMVC.Models;

public class StudentViewModel
{
    public string? MSSV { get; set; }
    public string? Name { get; set; }
    public double DiemTB { get; set; }
    public string? Major { get; set; }
    
    // Số lượng SV đã đăng ký cùng ngành
    public int CountSameMinor { get; set; }
    
    // Danh sách SV đã đăng ký (lưu trong memory)
    public static List<StudentViewModel> RegisteredStudents = new();
    
    public static readonly List<string> MajorOptions = new()
    {
        "CNPM",
        "HTTT",
        "ANM",
        "TTNT",
        "MMT"
    };
    
    // Hàm đếm số SV cùng ngành
    public int GetCountByMajor()
    {
        return RegisteredStudents.Count(s => s.Major == this.Major);
    }
}
