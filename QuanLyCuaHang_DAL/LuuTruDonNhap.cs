using Newtonsoft.Json;
using QuanLyCuaHang_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang_DAL
{
    public class LuuTruDonNhap : ILuuTruDonNhap
    {
        private const string _filePath = "./files/DonNhap.txt";
        private void LuuListDonNhap(List<HoaDon> ds)
        {
            StreamWriter sw = new StreamWriter(_filePath);
            string json = JsonConvert.SerializeObject(ds);
            sw.Write(json);
            sw.Close();
        }

        private string CreateIdHoaDonNhap(string prefix="Nhap")
        {
            var ds = ReadListDonNhap();
            int max = 0;
            foreach (var s in ds)
            {
                string[] arr = s.Id.Split('_');
                int x = int.Parse(arr[1]);
                if (x > max)
                    max = x;
            }
            max++;
            return prefix+ "_" + max.ToString();
        }

        public void CreateDonNhap(HoaDon h)
        {
            var ds = ReadListDonNhap();
            h.Id = CreateIdHoaDonNhap();
            ds.Add(h);
            LuuListDonNhap(ds);
        }
        public List<HoaDon> ReadListDonNhap()
        {
            StreamReader sr = new StreamReader(_filePath);
            string json = sr.ReadToEnd();
            sr.Close();
            return JsonConvert.DeserializeObject<List<HoaDon>>(json);
        }
        public HoaDon ReadDonNhapById(string id)
        {
            var dsDonNhap = ReadListDonNhap();
            foreach (HoaDon h in dsDonNhap)
            {
                if (h.Id == id)
                    return h;
            }
            return null;
        }

        public bool UpdateDonNhap(HoaDon hOld, HoaDon hNew)
        {
            var dsDonNhap = ReadListDonNhap();
            for (int i = 0; i < dsDonNhap.Count; i++)
            {
                if (dsDonNhap[i].Id == hOld.Id)
                {
                    dsDonNhap[i] = hNew;
                    LuuListDonNhap(dsDonNhap);
                    return true;
                }
            }
            return false;
        }
        public bool DeleteDonNhap(string id)
        {
            var dsDonNhap = ReadListDonNhap();
            for (int i = 0; i < dsDonNhap.Count; i++)
            {
                if (dsDonNhap[i].Id == id)
                {
                    dsDonNhap.RemoveAt(i);
                    LuuListDonNhap(dsDonNhap);
                    return true;
                }
            }
            return false;
        }
    }
}
