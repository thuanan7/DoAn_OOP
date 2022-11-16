using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuanLyCuaHang_Entities;
using QuanLyCuaHang_Services;

namespace Web_QuanLyCuaHang_OOP.Pages
{
    public class MH_ChiTiet_DonBanModel : PageModel
    {
        public string chuoiThongBao;
        private IXuLyDonBan _xuLyDonBan = new XuLyDonBan();
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
                    h = _xuLyDonBan.ReadDonBanById(Id);
                }
                catch (Exception ex)
                {
                    chuoiThongBao = ex.Message;
                }
            }
        }
    }
}
