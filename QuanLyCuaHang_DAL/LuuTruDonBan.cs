using Newtonsoft.Json;
using QuanLyCuaHang_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang_DAL
{
    public class LuuTruDonBan : ILuuTruDonBan
    {
        private const string _filePath = "./files/DonBan.txt";
        private void LuuListDonBan(List<HoaDon> ds)
        {
            StreamWriter sw = new StreamWriter(_filePath);
            string json = JsonConvert.SerializeObject(ds);
            sw.Write(json);
            sw.Close();
        }

        private string CreateIdHoaDonBan(string prefix="Ban")
        {
            var ds = ReadListDonBan();
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

        public void CreateDonBan(HoaDon h)
        {
            var ds = ReadListDonBan();
            h.Id = CreateIdHoaDonBan();
            ds.Add(h);
            LuuListDonBan(ds);
        }
        public List<HoaDon> ReadListDonBan()
        {
            StreamReader sr = new StreamReader(_filePath);
            string json = sr.ReadToEnd();
            sr.Close();
            return JsonConvert.DeserializeObject<List<HoaDon>>(json);
        }
        public HoaDon ReadDonBanById(string id)
        {
            var dsDonBan = ReadListDonBan();
            foreach (HoaDon h in dsDonBan)
            {
                if (h.Id == id)
                    return h;
            }
            return null;
        }

        public bool UpdateDonBan(HoaDon hOld, HoaDon hNew)
        {
            var dsDonBan = ReadListDonBan();
            for (int i = 0; i < dsDonBan.Count; i++)
            {
                if (dsDonBan[i].Id == hOld.Id)
                {
                    dsDonBan[i] = hNew;
                    LuuListDonBan(dsDonBan);
                    return true;
                }
            }
            return false;
        }
        public bool DeleteDonBan(string id)
        {
            var dsDonBan = ReadListDonBan();
            for (int i = 0; i < dsDonBan.Count; i++)
            {
                if (dsDonBan[i].Id == id)
                {
                    dsDonBan.RemoveAt(i);
                    LuuListDonBan(dsDonBan);
                    return true;
                }
            }
            return false;
        }
    }
}
