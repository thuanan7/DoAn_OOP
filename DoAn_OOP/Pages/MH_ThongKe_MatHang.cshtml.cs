using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuanLyCuaHang_Entities;
using QuanLyCuaHang_Services;

namespace Web_QuanLyCuaHang_OOP.Pages
{
    public class MH_ThongKe_MatHangModel : PageModel
    {
        public string chuoiThongBao;
        private IXuLyThongKe _xuLyThongKe = new XuLyThongKe();
        public List<MatHang> dsMatHang;

        public void OnGet()
        {
            try
            {
                dsMatHang = _xuLyThongKe.ThongKeMatHangConTrongKho();
            }
            catch (Exception ex)
            {
                chuoiThongBao = ex.Message;
            }
        }
    }
}
