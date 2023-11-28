using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doAn3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            var ds = new List();
            ds.init();
            int chon = 0;
            var SVtmp = new sinhvien();
            ds.DocFile("doc.txt", ds);

            do
            {
                Console.WriteLine(new string('-', 103));
                Console.Write(new string('-', 39));
                Console.Write("MENU");
                Console.WriteLine(new string('-', 60));
                Console.WriteLine("|{0,-40}|{1,-60}|", "1.Thêm sinh viên", "5.Lọc danh sách sinh viên");
                Console.WriteLine("|{0,-40}|{1,-60}|", "2.Xem danh sách sinh viên", "6.Sắp xếp tăng dần theo MSSV(Bubble sort)");
                Console.WriteLine("|{0,-40}|{1,-60}|", "3.Xóa sinh viên khỏi danh sách sinh viên", "7.Thoát menu");
                Console.WriteLine("|{0,-40}|{1,-60}|", "4.Tìm kiếm sinh viên bằng mssv", "");
                Console.WriteLine(new string('-', 103));
                //Console.WriteLine("13.Độ dài của danh sách: ");
                Console.Write("\nNhập lựu chọn: ");
                int pre = 0;
                if (chon != 0)
                    pre = chon;
                chon = Int32.Parse(Console.ReadLine());
                Console.WriteLine("***********************************************************************************************************");
                switch (chon)
                {
                    case 1:
                        {
                            ds.themSV();
                           // ds.xuatSV(ds.Header.Data);
                            ds.xuatDS();
                            break;
                        };
                    case 2:
                        {
                            ds.xuatDS();
                            break;
                        }
                    case 3:
                        {
                            ds.xoaSV();
                            break;
                        };
                    case 4:
                        {
                            Node sv = ds.timsv();
                            if (sv != null)
                            {
                                Console.WriteLine("\nSinh Viên bạn cần tìm là: ");
                                ds.xuatSV(sv.Data);
                            }
                            break;
                        };
                    case 5:
                        {
                            ds.locSinhVienTheoYeuCau();
                            break;
                        

                };
                    case 6:
                        {
                    ds.menububblesort();
                    ds.xuatDS();
                    //ds.luuFile("doc.txt", ds.Header);
                    break;

                };
                
                    
                 
                 
                  
                  
                    default:
                        break;
                }
            } while (chon != 7);
            
        }
    }
}

   
