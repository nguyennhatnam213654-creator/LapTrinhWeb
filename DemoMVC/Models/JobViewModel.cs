namespace DemoMVC.Models;

public class JobViewModel
{
    public required int MaCongViec { get; set; }
    public required string? TenCongViec { get; set; }
    public required bool TrangThai { get; set; }
}