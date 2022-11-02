using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuanLyCuaHang_Services;

namespace Web_QuanLyCuaHang_OOP.Pages.LoaiHang
{
    public class MH_Them_LoaiHangModel : PageModel
    {
        public string chuoiThongBao;
        [BindProperty]
        public string Id { get; set; }
        [BindProperty]
        public string Name { get; set; }
        private IXuLyCuaHang _xuLyCuaHang = new XuLyCuaHang();
        public void OnGet()
        {
            chuoiThongBao = string.Empty;
        }

        public void OnPost()
        {
            
            try
            {
                _xuLyCuaHang.CreateLoaiHang(Id.Trim(), Name.Trim());
                chuoiThongBao = "Thêm thành công!";
                //redirect o day
            }
            catch (Exception ex)
            {
                chuoiThongBao = ex.Message;
            }
        }
    }
}
