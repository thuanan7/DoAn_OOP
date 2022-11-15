using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuanLyCuaHang_Entities;
using QuanLyCuaHang_Services;

namespace Web_QuanLyCuaHang_OOP.Pages
{
    public class MH_ChiTiet_DonNhapModel : PageModel
    {
        public string chuoiThongBao;
        private IXuLyDonNhap _xuLyDonNhap = new XuLyDonNhap();
        public HoaDon h;
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(Id))
            {
                chuoiThongBao = "Id không hợp lệ!";
            }
            else
            {
                try
                {
                    h = _xuLyDonNhap.ReadDonNhapById(Id);
                }
                catch (Exception ex)
                {
                    chuoiThongBao = ex.Message;
                }
            }
        }
    }
}
