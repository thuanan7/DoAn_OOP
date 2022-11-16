using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuanLyCuaHang_Entities;
using QuanLyCuaHang_Services;

namespace Web_QuanLyCuaHang_OOP.Pages
{
    public class MH_Sua_DonBanModel : PageModel
    {
        public string chuoiThongBao = String.Empty;
        private IXuLyDonBan _xuLyDonBan = new XuLyDonBan();
        public HoaDon h = new();
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        [BindProperty]
        public string NewId { get; set; }
        [BindProperty]
        public DateTime NewNgayTao { get; set; }
        public void OnGet()
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

        public void OnPost()
        {
            try
            {
                h = _xuLyDonBan.ReadDonBanById(Id);
                HoaDon newh = new HoaDon()
                {
                    Id = NewId,
                    NgayTao = NewNgayTao,
                    DanhSachHang = h.DanhSachHang.ToList()
                };
                _xuLyDonBan.UpdateDonBan(h, newh);
                Response.Redirect($"./MH_Sua_DonBan?Id={newh.Id}");
            }
            catch (Exception ex)
            {
                chuoiThongBao = ex.Message;
            }
        }
    }
}
