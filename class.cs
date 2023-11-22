using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;



namespace doAn3
{
    public class Node<sinhvien> where sinhvien : IComparable<doAn3.sinhvien>
        //public class Node<sinhvien> where sinhvien : IComparable
    {
        public doAn3.sinhvien Data { get; set; }
        public Node<sinhvien> Next { get; set; }
        public Node()
        {
            Data = null;
            Next = null;
        }
        public Node(doAn3.sinhvien a)
        {
            Data = a;
            Next = null;
        }
    }
    class taoList<sinhvien> where sinhvien : IComparable<doAn3.sinhvien>

        //class taoList<sinhvien> where sinhvien : IComparable
    {

        public int dem = -1;
        public Node<doAn3.sinhvien> Header { get; set; } = new Node<doAn3.sinhvien>();
        public doAn3.sinhvien tmp = new doAn3.sinhvien();

        public Node<doAn3.sinhvien> TimNode(string data)
        {
            var q = Header;
            var currentNode = Header;
            while (currentNode != null)
            {
                if (currentNode.Data.IdSV.CompareTo(data) == 0)
                    return currentNode;
                q = currentNode;
                currentNode = currentNode.Next;
            }
            return null;

        }
        public Node<doAn3.sinhvien> FindPrevious(string data)
        {

            var q = Header;
            var currentNode = Header;
            while (currentNode != null)
            {
                if (currentNode.Data.IdSV.CompareTo(data) == 0)
                    return q;
                q = currentNode;
                currentNode = currentNode.Next;
            }
            return null;

        }
        public Node<doAn3.sinhvien> Insert(doAn3.sinhvien data, doAn3.sinhvien afterValue)
        {
            var newNode = new Node<doAn3.sinhvien>(data);
            var currentNode = TimNode(afterValue.IdSV);
            if (currentNode != null)
            {
                newNode.Next = currentNode.Next;
                currentNode.Next = newNode;
                return newNode;
            }
            return null;
        }
        public Node<sinhvien> Insert(doAn3.sinhvien data, Node<sinhvien> afterNode)
        {
            var newNode = new Node<sinhvien>(data)
            {
                Next = afterNode.Next
            };
            afterNode.Next = newNode;
            return newNode;
        }
        public Node<doAn3.sinhvien> addlast(doAn3.sinhvien data)
        {
            var p = Header;
            var q = new Node<doAn3.sinhvien>(data);
            if (p == null)
            {
                Header = q; // Nếu danh sách rỗng, thiết lập Header thành q
            }
            else
            {
                var c = Header;
                while (c != null)
                {
                    if (c?.Data.IdSV.CompareTo(data.IdSV) == 0)
                    {
                        Console.WriteLine("\n Mã số sinh viên bị trùng !!!");
                        return q;
                    }
                    c = c.Next;
                }
                p = Header;
                while (p.Next != null)
                {
                    p = p.Next;
                }
                p.Next = q;
            }
            tmp = q.Data;
            //cay.Add(data);
            return q;
        }
        public Node<doAn3.sinhvien> addfirst(doAn3.sinhvien data)
        {
            var p = Header;
            var q = new Node<doAn3.sinhvien>(data);
            if (p != null)
            {
                q.Next = Header;
                Header = q;
            }
            else
                Header = q;
            return q;
        }
        public void Remove()
        {
            Console.WriteLine("\n Bạn đã chọn xóa sinh viên khỏi danh sách !!!");
            if (Header != null)
            {
                string ma;
                var p = Header;
                char a = 'A';
                Console.Write("\nNhập mã sinh viên mà bạn muốn xóa khỏi danh sách: ");
                ma = Console.ReadLine();

                if (Header.Data.IdSV != ma)
                {
                    var previousNode = FindPrevious(ma);
                    if (previousNode != null)
                    {
                        do
                        {
                            Console.Write("\nBạn có xác nhận('y' để xác nhận 'n' để hủy thao tác xóa): ");
                            a = char.Parse(Console.ReadLine());
                            if (a == 'n')
                                return;
                        } while (a != 'y');
                        tmp = previousNode.Data;
                        previousNode.Next = previousNode.Next.Next;
                    }
                    else
                    {
                        Console.WriteLine("\nKhông tìm thấy mã sinh viên bạn muốn xóa!!!");
                        return;
                    }
                }
                else
                {
                    do
                    {
                        Console.Write("\nBạn có xác nhận('y' để xác nhận 'n' để hủy thao tác xóa): ");
                        a = char.Parse(Console.ReadLine());
                        if (a == 'n')
                            return;
                    } while (a != 'y');
                    tmp = Header.Data;
                    Header = Header.Next;
                }
                Console.WriteLine("\nDanh sách sinh viên sau khi xóa là: ");
                xuatDS();
            }
            else
            {
                Console.WriteLine("\nDanh sách rỗng thao tác không được thực thi !!!");
                return;
            }
        }
        public void xuatSV(doAn3.sinhvien a)
        {
            Console.WriteLine($"| {a.IdSV,10} | {a.NameSV,20} | {a.Lop,8} | {a.TinChi,8} | {a.NgayCTXH,10} | {a.DiemLyThuyet,14} | {a.DiemThucHanh,14} |");
        }
        public void xuatDS()
        {

            // Console.WriteLine("\nXuất danh sách đây:");
            Console.WriteLine(new string('-', 106));
            Console.WriteLine($"| {"ID",10} | {"Name",20} | {"Lop",8} | {"TinChi",8} | {"NgayCTXH",10} | {"DiemLyThuyet",14} | {"DiemThucHanh",14} |");
            Console.WriteLine(new string('-', 106));

            Node<doAn3.sinhvien> p = Header;
            while (p != null)
            {
                xuatSV(p.Data);
                p = p.Next;
            }
            Console.WriteLine(new string('-', 106));
            Console.WriteLine();
        }
        public void themSV(taoList<doAn3.sinhvien> ds)
        {
            var a = new doAn3.sinhvien();
            Console.WriteLine(new string('-', 106));
            Console.WriteLine($"| {"ID",10} | {"Name",20} | {"Lop",8} | {"TinChi",8} | {"NgayCTXH",10} | {"DiemLyThuyet",14} | {"DiemThucHanh",14} |");
            Console.WriteLine(new string('-', 106));
            Console.Write("\n Nhập mã của sinh viên: ");
            a.IdSV = Convert.ToString(Console.ReadLine());
            Console.Write("\n Nhập Tên của sinh viên: ");
            a.NameSV = Convert.ToString(Console.ReadLine());
            Console.Write("\n Nhập Lớp của sinh viên: ");
            a.Lop = Convert.ToString(Console.ReadLine());
            Console.Write("\n Nhập số ngày công tác xã hội chỉ sinh viên đã đạt đc: ");
            a.NgayCTXH = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n Nhập số tín chỉ sinh viên đã đạt đc: ");
            a.TinChi = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n Nhập điểm lý thuyêt của sinh viên: ");
            a.DiemLyThuyet = Convert.ToDouble(Console.ReadLine());
            Console.Write("\n Nhập điểm thực hành của sinh viên: ");
            a.DiemThucHanh = Convert.ToDouble(Console.ReadLine());



            ds.addlast(a);
        }
        public void themNhieuSV()
        {
            var a = new doAn3.sinhvien();
            Console.WriteLine(new string('-', 106));
            Console.WriteLine($"| {"ID",10} | {"Name",20} | {"Lop",8} | {"TinChi",8} | {"NgayCTXH",10} | {"DiemLyThuyet",14} | {"DiemThucHanh",14} |");
            Console.WriteLine(new string('-', 106));
            do
            {
                a = new doAn3.sinhvien();
                Console.Write("\n Nhập mã của sinh viên(exit để thoát): ");
                a.IdSV = Convert.ToString(Console.ReadLine());
                if (a.IdSV == "exit")
                    break;
                Console.Write("\n Nhập Tên của sinh viên: ");
                a.NameSV = Convert.ToString(Console.ReadLine());
                Console.Write("\n Nhập Lớp của sinh viên: ");
                a.Lop = Convert.ToString(Console.ReadLine());
                Console.Write("\n Nhập số ngày công tác xã hội chỉ sinh viên đã đạt đc: ");
                a.NgayCTXH = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n Nhập số tín chỉ sinh viên đã đạt đc: ");
                a.TinChi = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n Nhập điểm lý thuyêt của sinh viên: ");
                a.DiemLyThuyet = Convert.ToDouble(Console.ReadLine());
                Console.Write("\n Nhập điểm thực hành của sinh viên: ");
                a.DiemThucHanh = Convert.ToDouble(Console.ReadLine());
                addlast(a);

                xuatDS();
            } while (a.IdSV != "exit");
        }
        public void luuFile(string filename, taoList<doAn3.sinhvien> ds)
        {
            using (StreamWriter a = new StreamWriter(filename))
            {
                char b = 'A';
                do
                {
                    Console.Write("\nBạn có muốn lưu không ('y'xác nhận 'n' không): ");
                    b = char.Parse(Console.ReadLine());
                    if (b == 'y')
                    {
                        var p = ds.Header;
                        while (p != null)
                        {
                            a.WriteLine(p.Data.IdSV);
                            a.WriteLine(p.Data.NameSV);
                            a.WriteLine(p.Data.Lop);
                            a.WriteLine(p.Data.NgayCTXH);
                            a.WriteLine(p.Data.TinChi);
                            a.WriteLine(p.Data.DiemLyThuyet);
                            a.WriteLine(p.Data.DiemThucHanh);
                            p = p.Next;
                        }
                        Console.WriteLine("\nLưu file thành công");
                        return;
                    }
                } while (b != 'n');
                
            }
        }
        public void DocFile(string fileName, taoList<doAn3.sinhvien> ds)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                while (!r.EndOfStream)
                {
                    var a = new doAn3.sinhvien();
                    a.IdSV = r.ReadLine();
                    a.NameSV = r.ReadLine();
                    a.Lop = r.ReadLine();
                    a.NgayCTXH = Int32.Parse(r.ReadLine());
                    a.TinChi = Int32.Parse(r.ReadLine());
                    a.DiemLyThuyet = double.Parse(r.ReadLine());
                    a.DiemThucHanh = double.Parse(r.ReadLine());
                    ds.addlast(a);
                }
            }
        }

        public void xepSVTheoKhoa(taoList<doAn3.sinhvien> ds, taoList<doAn3.sinhvien> lsTheoLop)
        {
            if (ds.Header != null) {
                string lop;
                var p = ds.Header;
                Console.Write("\nNhập lớp mà bạn muốn lọc danh sách theo: ");
                lop = Console.ReadLine();
                while (p != null)
                {
                    if (p?.Data.Lop.CompareTo(lop) == 0)
                        lsTheoLop.addlast(p.Data);
                    p = p.Next;
                }
                Console.WriteLine("\nDanh sách sinh viên lop " + lop + ": ");
                lsTheoLop.xuatDS();
            }
            else
                Console.WriteLine("\nDanh sách sinh viên rỗng thao tác không được thực thi!!!");
            return;
        }
        public void xepSVDuDKTotNghiep(taoList<doAn3.sinhvien> ds, taoList<doAn3.sinhvien> lsTotNghiep)
        {
            if (ds.Header != null)
            {
                var p = ds.Header;
                while (p != null)
                {
                    if (p.Data.NgayCTXH >= 10 && p.Data.TinChi >= 150)
                        lsTotNghiep.addlast(p.Data);
                    p = p.Next;
                }
                Console.Write("\nDanh sách sinh viên đủ điều kiện tốt nghiệp là:");
                Console.WriteLine("\nĐiều kiện tốt nghiệp là ngày ctxh đủ 10 ngày và số tín chỉ đủ hoặc hơn 150");
                lsTotNghiep.xuatDS();
            }
            else
                Console.WriteLine("\nDanh sách sinh viên rỗng thao tác không được thực thi!!!");

        }
        public void backThem()
        {
            Console.WriteLine("\n Bạn đã chọn hoàn tác sau khi thêm !!!");

            var previousNode = FindPrevious(tmp.IdSV);
            if (previousNode != null)
            {
                previousNode.Next = previousNode.Next.Next;
            }
        }
        public void backXoa()
        {
            addlast(tmp);
        }
        public void BubbleSort()
        {
            bool swapped;
            do
            {
                swapped = false;
                Node<doAn3.sinhvien> current = Header;
                Node<doAn3.sinhvien> prev = null;

                while (current != null && current.Next != null)
                {
                    if (current.Data.CompareTo(current.Next.Data) > 0)
                    {
                        // Hoán đổi dữ liệu của các nút
                        Node<doAn3.sinhvien> temp = current.Next;
                        current.Next = temp.Next;
                        temp.Next = current;

                        if (prev == null)
                        {
                            Header = temp;
                        }
                        else
                        {
                            prev.Next = temp;
                        }

                        prev = temp;
                        swapped = true;
                    }
                    else
                    {
                        prev = current;
                        current = current.Next;
                    }
                }
            } while (swapped);
        }
        public void QuickSort()
        {
            Header = QuickSort(Header);
        }

        private Node<doAn3.sinhvien> QuickSort(Node<doAn3.sinhvien> head)
        {
            if (head.Data == null || head.Next == null)
                return head;

            doAn3.sinhvien pivotValue = head.Data;

            Node<doAn3.sinhvien> lesser = new Node<doAn3.sinhvien>();
            Node<doAn3.sinhvien> equal = new Node<doAn3.sinhvien>();
            Node<doAn3.sinhvien> greater = new Node<doAn3.sinhvien>();

            Node<doAn3.sinhvien> current = head;
            while (current != null)
            {
                int compareResult = current.Data.IdSV.CompareTo(pivotValue.IdSV);
                if (compareResult < 0)
                {
                    InsertTail(lesser, current.Data);
                }
                else if (compareResult == 0)
                {
                    InsertTail(equal, current.Data);
                }
                else
                {
                    InsertTail(greater, current.Data);
                }
                current = current.Next;
            }

            lesser = QuickSort(lesser);
            greater = QuickSort(greater);

            return ConcatenateLists(lesser, equal, greater);
        }

        // Các phương thức hỗ trợ

        private void InsertTail(Node<doAn3.sinhvien> list, doAn3.sinhvien data)
        {
            if (list.Data != null)
            {
                var current = list;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new Node<doAn3.sinhvien>(data);
            }
            else
            {
                list.Data = data;
            }
        }
        private Node<doAn3.sinhvien> ConcatenateLists(Node<doAn3.sinhvien> a, Node<doAn3.sinhvien> b, Node<doAn3.sinhvien> c)
        {
            if (a.Data == null && b.Data == null && c.Data == null)
            {
                return null;
            }
            if (a.Data == null)
            {
                if (b.Data == null && c.Data == null)
                {
                    return null;
                }
                if (b.Data == null)
                {
                    return c;
                }
                if (c.Data == null)
                {
                    return b;
                }
                Node<doAn3.sinhvien> temp = b;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = c;
                return b;
            }
            Node<doAn3.sinhvien> tail = a;
            while (tail.Next != null)
            {
                tail = tail.Next;
            }
            if (b.Data != null)
            {
                tail.Next = b;
                while (tail.Next != null)
                {
                    tail = tail.Next;
                }
            }
            if (c.Data != null)
            {
                tail.Next = c;
            }
            return a;
        }
       




        public int Length()
        {
            int de = 0;
            var p = Header;
            while (p != null)
            {
                de++;
                p = p.Next;
            }
            return de;
        }

        public void HeapSort()
        {
            int length = Length();
            for (int i = length / 2 - 1; i >= 0; i--)
            {
                Heapify(length, i);
            }

            for (int i = length - 1; i >= 0; i--)
            {
                Node<doAn3.sinhvien> current = Header;
                Node<doAn3.sinhvien> prev = null;
                for (int j = 0; j < i; j++)
                {
                    prev = current;
                    current = current.Next;
                }
                Swap(current, Header);

                Heapify(i, 0);

                if (prev == null)
                {
                    Header = current;
                }
                else
                {
                    prev.Next = current;
                }
            }
        }

        private void Heapify(int length, int rootIndex)
        {
            int largest = rootIndex;
            int leftChild = 2 * rootIndex + 1;
            int rightChild = 2 * rootIndex + 2;

            if (leftChild < length && FindNodeAtIndex(leftChild).Data.CompareTo(FindNodeAtIndex(largest).Data) > 0)
            {
                largest = leftChild;
            }

            if (rightChild < length && FindNodeAtIndex(rightChild).Data.CompareTo(FindNodeAtIndex(largest).Data) > 0)
            {
                largest = rightChild;
            }

            if (largest != rootIndex)
            {
                Node<doAn3.sinhvien> largestNode = FindNodeAtIndex(largest);
                Swap(largestNode, FindNodeAtIndex(rootIndex));

                Heapify(length, largest);
            }
        }
        private Node<doAn3.sinhvien> FindNodeAtIndex(int index)
        {
            var current = Header;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current;
        }
        private void Swap(Node<doAn3.sinhvien> a, Node<doAn3.sinhvien> b)
        {
            doAn3.sinhvien temp = a.Data;
            a.Data = b.Data;
            b.Data = temp;
        }



    
    }
}