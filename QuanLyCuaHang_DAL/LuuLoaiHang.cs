using Newtonsoft.Json;
using QuanLyCuaHang_Entities;

namespace QuanLyCuaHang_DAL
{
    public class LuuLoaiHang : ILuuLoaiHang
    {
        private string filePath = "./files/LoaiHang.txt";
        private void LuuListLoaiHang(List<LoaiHang> ds)
        {
            StreamWriter sw = new StreamWriter(filePath);
            string json = JsonConvert.SerializeObject(ds);
            sw.Write(json);
            sw.Close();
        }

        public void CreateLoaiHang(LoaiHang lh)
        {
            var dsLoaiHang = ReadListLoaiHang();
            dsLoaiHang.Add(lh);
            LuuListLoaiHang(dsLoaiHang);
        }

        public List<LoaiHang> ReadListLoaiHang()
        {
            StreamReader sr = new StreamReader(filePath);
            string json = sr.ReadToEnd();
            var dsLoaiHang = JsonConvert.DeserializeObject<List<LoaiHang>>(json);
            sr.Close();
            return dsLoaiHang;
        }
        public LoaiHang ReadLoaiHangById(string id)
        {
            var dsLoaiHang = ReadListLoaiHang();
            foreach (LoaiHang hang in dsLoaiHang)
            {
                if (hang.Id == id)
                    return hang;
            }
            return null;
        }

        public bool UpdateLoaiHang(LoaiHang lh)
        {
            var dsLoaiHang = ReadListLoaiHang();
            for (int i = 0; i < dsLoaiHang.Count; i++)
            {
                if (dsLoaiHang[i].Id == lh.Id)
                {
                    dsLoaiHang[i] = lh;
                    LuuListLoaiHang(dsLoaiHang);
                    return true;
                }
            }
            return false;
        }
        public bool DeleteLoaiHang(string id)
        {
            var dsLoaiHang = ReadListLoaiHang();
            for (int i = 0; i < dsLoaiHang.Count; i++)
            {
                if (dsLoaiHang[i].Id == id)
                {
                    dsLoaiHang.RemoveAt(i);
                    LuuListLoaiHang(dsLoaiHang);
                    return true;
                }
            }
            return false;
        }
    }
}