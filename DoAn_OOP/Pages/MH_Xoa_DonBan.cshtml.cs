using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuanLyCuaHang_Entities;
using QuanLyCuaHang_Services;

namespace Web_QuanLyCuaHang_OOP.Pages
{
    public class MH_Xoa_DonBanModel : PageModel
    {
        public string chuoiThongBao;
        private IXuLyDonBan _xuLyDonBan = new XuLyDonBan();
        public HoaDon h = new();
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public void OnGet()
        {
            try
            {
                h = _xuLyDonBan.ReadDonBanById(Id);
                chuoiThongBao = string.Empty;
            }
            catch (Exception ex)
            {
                chuoiThongBao = ex.Message;
            }
        }

        public void OnPost()
        {
            try
            {
                _xuLyDonBan.DeleteDonBan(Id);
                chuoiThongBao = "Xóa thành công!";
            }
            catch (Exception ex)
            {
                chuoiThongBao = ex.Message;
            }
        }
    }
}
