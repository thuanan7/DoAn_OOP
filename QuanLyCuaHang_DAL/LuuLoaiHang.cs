using Newtonsoft.Json;
using QuanLyCuaHang_Entities;

namespace QuanLyCuaHang_DAL
{
    public class LuuLoaiHang : ILuuLoaiHang
    {
        private string filePath = "./files/LoaiHang.txt";
        public void CreateLoaiHang(LoaiHang lh)
        {
            var dsLoaiHang = ReadLoaiHang();
            dsLoaiHang.Add(lh);
            LuuListSanPham(dsLoaiHang);
        }

        public List<LoaiHang> ReadLoaiHang()
        {
            StreamReader sr = new StreamReader(filePath);
            string json = sr.ReadToEnd();
            var dsLoaiHang = JsonConvert.DeserializeObject<List<LoaiHang>>(json);
            sr.Close();
            return dsLoaiHang;
        }

        private void LuuListSanPham(List<LoaiHang> ds)
        {
            StreamWriter sw = new StreamWriter(filePath);
            string json = JsonConvert.SerializeObject(ds);
            sw.Write(json);
            sw.Close();
        }
    }
}