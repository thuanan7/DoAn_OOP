using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuanLyCuaHang_Entities;
using QuanLyCuaHang_Services;

namespace Web_QuanLyCuaHang_OOP.Pages
{
    public class MH_Xoa_DonNhapModel : PageModel
    {
        public string chuoiThongBao;
        private IXuLyDonNhap _xuLyDonNhap = new XuLyDonNhap();
        public HoaDon h = new();
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public void OnGet()
        {
            try
            {
                h = _xuLyDonNhap.ReadDonNhapById(Id);
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
                _xuLyDonNhap.DeleteDonNhap(Id);
                chuoiThongBao = "Xóa thành công!";
            }
            catch (Exception ex)
            {
                chuoiThongBao = ex.Message;
            }
        }
    }
}
