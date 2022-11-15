using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuanLyCuaHang_Entities;
using QuanLyCuaHang_Services;

namespace Web_QuanLyCuaHang_OOP.Pages
{
    public class MH_DanhSach_DonNhapModel : PageModel
    {
        public string chuoiThongBao;
        private IXuLyDonNhap _xuLyDonNhap = new XuLyDonNhap();
        public List<HoaDon> dsDonNhap;

        [BindProperty]
        public string TuKhoa { get; set; }
        public void OnGet()
        {
            try
            {
                dsDonNhap = _xuLyDonNhap.ReadListDonNhap();
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
                dsDonNhap = _xuLyDonNhap.ReadListDonNhap(TuKhoa);
            }
            catch (Exception ex)
            {
                chuoiThongBao = ex.Message;
            }
        }
    }
}
