using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace doAn3
{
    [Serializable]
    public class sinhvien : IComparable<sinhvien>
    {
        private string m_idSV;
        private string m_nameSV;
        private string m_lop;
        private double m_ngayCTXH;
        private int m_tinChi;

        private double m_diemLyThuyet;
        private double m_diemThucHanh;

        public string IdSV { get => m_idSV; set => m_idSV = value; }
        public string NameSV { get => m_nameSV; set => m_nameSV = value; }
        public string Lop { get => m_lop; set => m_lop = value; }
        public double NgayCTXH { get => m_ngayCTXH; set => m_ngayCTXH = value; }
        public int TinChi { get => m_tinChi; set
            {
                if (value < 0 )
                {
                    Console.WriteLine("\nNhập điểm không hợp lệ");
                    m_tinChi = -1;
                }
                else
                    m_tinChi = value;
            } }
        public double DiemLyThuyet { get => m_diemLyThuyet; set
            {
                if (value < 0 || value > 10)
                {  Console.WriteLine("\nNhập điểm không hợp lệ");
                    m_diemLyThuyet = -1;
            }else
                    m_diemLyThuyet = value; } }
        public double DiemThucHanh { get => m_diemThucHanh; set
            {
                if (value < 0 || value > 10)
                {
                    Console.WriteLine("\nNhập điểm không hợp lệ");
                    m_diemThucHanh = -1;
                }
                else
                    m_diemThucHanh = value;
            }
        }
    

        public sinhvien(string idSV, string nameSV, string lop, int ngayCTXH, int tinChi, double diemLyThuyet, double diemThucHanh)
        {
            m_idSV = idSV;
            m_nameSV = nameSV;
            m_lop = lop;
            m_ngayCTXH = ngayCTXH;
            m_tinChi = tinChi;
            m_diemLyThuyet = diemLyThuyet;
            m_diemThucHanh = diemThucHanh;
        }
        public sinhvien()
        {
            m_idSV = "";
            m_nameSV = "";
            m_lop = "";
            m_ngayCTXH = -1;
            m_tinChi = -1;
            m_diemLyThuyet = -1;
            m_diemThucHanh = -1;
        }

        public int CompareTo(sinhvien other)
        {
            return this.m_idSV.CompareTo(other.m_idSV);
        }
        public double diemTB { get => (DiemLyThuyet + DiemThucHanh) / 2; }
     
    }
    


}

