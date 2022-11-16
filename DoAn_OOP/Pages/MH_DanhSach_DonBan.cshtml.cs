using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuanLyCuaHang_Entities;
using QuanLyCuaHang_Services;

namespace Web_QuanLyCuaHang_OOP.Pages
{
    public class MH_DanhSach_DonBanModel : PageModel
    {
        public string chuoiThongBao;
        private IXuLyDonBan _xuLyDonBan = new XuLyDonBan();
        public List<HoaDon> dsDonBan;

        [BindProperty]
        public string TuKhoa { get; set; }
        public void OnGet()
        {
            try
            {
                dsDonBan = _xuLyDonBan.ReadListDonBan();
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
                dsDonBan = _xuLyDonBan.ReadListDonBan(TuKhoa);
            }
            catch (Exception ex)
            {
                chuoiThongBao = ex.Message;
            }
        }
    }
}
