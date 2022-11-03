using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuanLyCuaHang_Entities;
using QuanLyCuaHang_Services;

namespace Web_QuanLyCuaHang_OOP.Pages
{
    public class MH_DanhSach_LoaiHangModel : PageModel
    {
        public string chuoiThongBao;
        private IXuLyLoaiHang _xuLyLoaiHang = new XuLyLoaiHang();
        public List<LoaiHang> dsLoaiHang;

        [BindProperty]
        public string TuKhoa { get; set; }
        public void OnGet()
        {
            try
            {
                dsLoaiHang = _xuLyLoaiHang.ReadListLoaiHang();
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
                dsLoaiHang = _xuLyLoaiHang.ReadListLoaiHang(TuKhoa);
            }
            catch (Exception ex)
            {
                chuoiThongBao = ex.Message;
            }
        }
    }
}
