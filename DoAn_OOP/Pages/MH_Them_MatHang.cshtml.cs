using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuanLyCuaHang_Services;

namespace Web_QuanLyCuaHang_OOP.Pages
{
    public class MH_Them_MatHangModel : PageModel
    {
        public string chuoiThongBao;
        [BindProperty]
        public string categoryId { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Company { get; set; }
        [BindProperty]
        public int Year { get; set; }
        [BindProperty]
        public DateTime Exp { get; set; }
        private IXuLyMatHang _xuLyMatHang = new XuLyMatHang();
        public void OnGet()
        {
            chuoiThongBao = string.Empty;
        }

        public void OnPost()
        {
            
            try
            {
                _xuLyMatHang.CreateMatHang(categoryId, Name, Company, Year, Exp);
                chuoiThongBao = "Thêm thành công!";
                Response.Redirect("/MH_DanhSach_MatHang");
            }
            catch (Exception ex)
            {
                chuoiThongBao = ex.Message;
            }
        }
    }
}
