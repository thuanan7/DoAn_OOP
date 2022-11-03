using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuanLyCuaHang_Services;

namespace Web_QuanLyCuaHang_OOP.Pages
{
    public class MH_Them_LoaiHangModel : PageModel
    {
        public string chuoiThongBao;
        [BindProperty]
        public string Id { get; set; }
        [BindProperty]
        public string Name { get; set; }
        private IXuLyLoaiHang _xuLyLoaiHang = new XuLyLoaiHang();
        public void OnGet()
        {
            chuoiThongBao = string.Empty;
        }

        public void OnPost()
        {
            
            try
            {
                _xuLyLoaiHang.CreateLoaiHang(Id.Trim(), Name.Trim());
                chuoiThongBao = "Thêm thành công!";
                Response.Redirect("/LoaiHangPages/MH_DanhSach_LoaiHang");
            }
            catch (Exception ex)
            {
                chuoiThongBao = ex.Message;
            }
        }
    }
}
