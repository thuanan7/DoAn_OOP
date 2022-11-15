using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuanLyCuaHang_Entities;
using QuanLyCuaHang_Services;

namespace Web_QuanLyCuaHang_OOP.Pages
{
    public class MH_Sua_DonNhapModel : PageModel
    {
        public string chuoiThongBao = String.Empty;
        private IXuLyDonNhap _xuLyDonNhap = new XuLyDonNhap();
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
                h = _xuLyDonNhap.ReadDonNhapById(Id);
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
                h = _xuLyDonNhap.ReadDonNhapById(Id);
                HoaDon newh = new HoaDon()
                {
                    Id = NewId,
                    NgayTao = NewNgayTao,
                    DanhSachHang = h.DanhSachHang.ToList()
                };
                _xuLyDonNhap.UpdateDonNhap(h, newh);
                Response.Redirect($"./MH_Sua_DonNhap?Id={newh.Id}");
            }
            catch (Exception ex)
            {
                chuoiThongBao = ex.Message;
            }
        }
    }
}
