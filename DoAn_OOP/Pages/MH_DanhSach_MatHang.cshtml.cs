using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuanLyCuaHang_Entities;
using QuanLyCuaHang_Services;

namespace Web_QuanLyCuaHang_OOP.Pages
{
    public class MH_DanhSach_MatHangModel : PageModel
    {
        public string chuoiThongBao;
        private IXuLyMatHang _xuLyMatHang = new XuLyMatHang();
        public List<MatHang> dsMatHang;

        [BindProperty]
        public string TuKhoa { get; set; }
        public void OnGet()
        {
            try
            {
                dsMatHang = _xuLyMatHang.ReadListMatHang();
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
                dsMatHang = _xuLyMatHang.ReadListMatHang(TuKhoa);
            }
            catch (Exception ex)
            {
                chuoiThongBao = ex.Message;
            }
        }
    }
}
