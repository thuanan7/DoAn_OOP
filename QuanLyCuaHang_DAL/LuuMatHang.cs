using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QuanLyCuaHang_Entities;

namespace QuanLyCuaHang_DAL
{
    public class LuuMatHang : ILuuMatHang
    {
        private string filePath = "./files/MatHang.txt";
        private void LuuListSanPham(List<MatHang> ds)
        {
            StreamWriter sw = new StreamWriter(filePath);
            string json = JsonConvert.SerializeObject(ds);
            sw.Write(json);
            sw.Close();
        }

         public void CreateMatHang(MatHang mh, string idPrefix="")
        {
            var dsMatHang = ReadListMatHang();
            int max = 1;
            foreach (var s in dsMatHang)
            {
                string[] arr = s.Id.Split('_');
                int x = int.Parse(arr[1]);
                if (x > max)
                    max = x;
            }

            mh.Id = idPrefix + "_" + max.ToString();
            dsMatHang.Add(mh);
            LuuListSanPham(dsMatHang);
        }

        public List<MatHang> ReadListMatHang()
        {
            StreamReader sr = new StreamReader(filePath);
            string json = sr.ReadToEnd();
            sr.Close();

            return JsonConvert.DeserializeObject<List<MatHang>>(json);
        }
        public MatHang ReadMatHangById(string id)
        {
            var ds = ReadListMatHang();
            foreach (MatHang h in ds)
            {
                if (h.Id == id)
                    return h;
            }
            return null;
        }
        public bool UpdateMatHang(MatHang mh)
        {
            var dsMatHang = ReadListMatHang();
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if (dsMatHang[i].Id == mh.Id)
                {
                    dsMatHang[i] = mh;
                    LuuListSanPham(dsMatHang);
                    return true;
                }
            }
            return false;
        }
        public bool DeleteMatHang(string id)
        {
            var dsMatHang = ReadListMatHang();
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if (dsMatHang[i].Id == id)
                {
                    dsMatHang.RemoveAt(i);
                    LuuListSanPham(dsMatHang);
                    return true;
                }
            }
            return false;
        }
    }
}
