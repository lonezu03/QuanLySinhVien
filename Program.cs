using System;
using System.Collections.Generic;
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
            var ds = new taoList<doAn3.sinhvien>();
            ds.Header = null;
            int chon = 0;
            var SVtmp = new sinhvien();
            ds.DocFile("doc.txt", ds);

            do
            {
                Console.WriteLine("***********************************************************************************************************");
                Console.Write("\nChọn menu !!!!");
                Console.Write("\n1.Thêm sinh viên vào danh sách");
                Console.Write("\n2.Thêm nhiều sinh viên vào danh sách");
                Console.Write("\n3.Xem danh sách sinh viên");
                Console.Write("\n4.Lưu Danh sách sinh viên vào file");
                Console.Write("\n5.Mở danh sách sinh viên từ file");
                Console.Write("\n6.Xóa sinh viên khỏi danh sách");
                Console.Write("\n7.Hoàn tác vụ vừa dùng ");
                Console.Write("\n8.Lọc danh sách sinh viên theo khoa");
                Console.Write("\n9.Lọc danh sách sinh viên đủ điều kiện tốt nghiệp");
                Console.Write("\n10.Sắp xếp danh sách sinh viên theo mã sinh viên(bubble sort)");
                Console.Write("\n11.Sắp xếp danh sách sinh viên theo mã sinh viên(quick sort)");
                Console.Write("\n12.Sắp xếp danh sách sinh viên theo mã sinh viên(heap sort)");

                Console.Write("\nNhập -999 để thoát menu: ");
                Console.Write("\nNhap lựu chọn: ");
                int pre = 0;
                if (chon != 0)
                    pre = chon;
                chon = Int32.Parse(Console.ReadLine());
                Console.WriteLine("***********************************************************************************************************");
                switch (chon)
                {
                    case 1:
                        {
                            char a= 'A';
                            ds.themSV(ds);
                            ds.xuatDS();
                            do
                            {
                                Console.Write("\nBạn có muốn lưu không ('y'xác nhận 'n' không): ");
                                a = char.Parse(Console.ReadLine());
                                if (a == 'n')
                                    break ;
                            } while (a != 'y');
                            ds.luuFile("doc.txt",ds);
                            break;
                        };
                    case 2:
                        {
                            ds.themNhieuSV();
                            break;
                        }
                    case 3:
                        {
                            ds.xuatDS();
                            break;
                        };
                    case 4:
                        {
                            ds.luuFile("doc.txt", ds);
                            break;
                        };
                    case 5:
                        {
                            ds.DocFile("doc.txt", ds);
                            Console.WriteLine("\nDanh sách sinh viên sau khi đọc file là: ");
                            ds.xuatDS();
                            break;
                        };
                    case 6:
                        {
                            char a='a';
                            ds.Remove();
                            do
                            {
                                Console.Write("\nBạn có muốn lưu không ('y'xác nhận 'n' không): ");
                                a = char.Parse(Console.ReadLine());
                                if (a == 'n')
                                    break;
                            } while (a != 'y');
                            ds.luuFile("doc.txt", ds);
                            break;
                        };
                    case 7:
                        {
                            if (pre == 1)
                            {
                                ds.backThem();
                                Console.WriteLine("\nDanh sách sau khi hoàn tác là: !!!");
                                ds.xuatDS();
                            }
                            else if (pre == 6)
                            {
                                ds.backXoa();
                                Console.WriteLine("\nDanh sách sau khi hoàn tác là: !!!");
                                ds.xuatDS();
                            }
                            else
                                Console.WriteLine("\nLưu ý chỉ được hoàn tác sau khi đã thêm hoặc xóa !!!");
                            break;
                        };
                    case 8:
                        {
                            var dsLop = new taoList<doAn3.sinhvien>();
                            dsLop.Header = null;
                            ds.xepSVTheoKhoa(ds, dsLop);

                            break;
                        };
                    case 9:
                        {
                            var dsTotnghiep = new taoList<doAn3.sinhvien>();
                            dsTotnghiep.Header = null;
                            ds.xepSVDuDKTotNghiep(ds, dsTotnghiep);
                            break;
                        };
                    case 10:
                        {
                            ds.BubbleSort();
                            ds.xuatDS();
                            break;
                        }
                    case 11:
                        {
                            ds.QuickSort();
                            //ds.xuatSV(ds.Header.Data);
                            
                            ds.xuatDS();
                            break;
                        }
                    case 12:
                        {
                            ds.HeapSort();
                            
                            ds.xuatDS();
                            break;
                        }
                    default:
                        break;
                }
            } while (chon != -999);
        }
    }
}

   
