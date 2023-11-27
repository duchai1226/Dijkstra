using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    struct DinhKe
    {
        public double _trongSo;
        public Dinh _dinh;// Ten cua dinh ke tao voi dinh dang xet canh co trong so la _trongSo
    }
    class Dinh
    {
        string _name;
        List<DinhKe> _DsDinhKe = new List<DinhKe>(); //Danh sach chua cac dinh ke dinh dang xet       
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public List<DinhKe> DsDinhKe
        {
            get
            {
                return _DsDinhKe;
            }
            set
            {
                _DsDinhKe = value;
            }
        }
        public void FindNearPoint(List<Canh> DsTrongSoInput)
        {
            // Do trong danh sach cac canh dau vao
            DinhKe temp = new DinhKe();
            for(int i=0;i<DsTrongSoInput.Count();i++)
            {
                //Chi can ten canh co chua dinh dang xet thi dinh con lai cua canh la dinh ke
                if (_name==DsTrongSoInput[i].dinhdau._name || _name == DsTrongSoInput[i].dinhcuoi._name)                   
                {
                    if (_name == DsTrongSoInput[i].dinhdau._name)
                    {
                        temp._dinh = DsTrongSoInput[i].dinhcuoi;
                        temp._trongSo = DsTrongSoInput[i].TrongSo;
                        DsDinhKe.Add(temp);//Them dinh ke vua tim duoc vao danh sach cac dinh ke cua dinh dang xet
                    }
                    else
                    {
                        temp._dinh = DsTrongSoInput[i].dinhdau;
                        temp._trongSo = DsTrongSoInput[i].TrongSo;
                        DsDinhKe.Add(temp);//Them dinh ke vua tim duoc vao danh sach cac dinh ke cua dinh dang xet
                    }
                }
                
            }          
        }
        int CheckList(List<string> check)
        {
            int count=0;
            for(int i=0;i<check.Count;i++)
            {
                if (_name == check[i])
                     count+=1;
            }
            return count;
        }
        void ChangeCheckList(List<string> check)
        {
            foreach (DinhKe i in DsDinhKe.ToList()) //Kiểm tra các đỉnh kề của đỉnh đang xét đã được xét trước đây hay chưa
            {
                if (i._dinh.CheckList(check) > 0) //Nếu đã xét rồi thì xoá khỏi ds đỉnh kề
                    DsDinhKe.Remove(i);
            }
        }
        public void Duyet(Input _InputData,XuLy xlds,List<string> check,Result a)
        {
            if(DsDinhKe.Count==0) //Nêu đỉnh chưa có danh sách các đỉnh kề thì dò trong input và tạo ra danh sách đỉnh kề
                FindNearPoint(_InputData.DsTrongSo);
            DsDinhKe = DsDinhKe.OrderBy(t => t._trongSo).ToList(); //Sắp xếp các đỉnh kề theo thứ tự tăng dần dựa trên trọng số
            ChangeCheckList(check);
            foreach (DinhKe i in DsDinhKe)
            {
                if (_name == _InputData.Root) //Sau khi xét được 1 đường đi từ 1 đỉnh kề thì reset lại danh sách các đỉnh đã xét để xét đường đi từ 1 đỉnh kề khác 
                    check.RemoveAll(t => t != _InputData.Root);//Reset lại chỉ trừ đỉnh gốc
                a._tongTrongSo += i._trongSo; //Cộng trọng số vào tổng trọng số của đường đi
                a._map.Add(i._dinh.name);  //Thêm đỉnh kề đang xét vào danh sách đường đi            
                if (i._dinh.name == _InputData.End) //Nếu đỉnh đang xét là đỉnh cần đến
                {
                    Result temp = new Result(a);
                    xlds.ketQua.Add(temp);//Trả về đường đi và trọng số của đường đi
                }           
                else //Ngược lại thì tiếp tục xét
                {
                    check.Add(i._dinh.name);//Thêm đỉnh đang xét vào ds các đỉnh đã xét
                    i._dinh.Duyet(_InputData, xlds, check, a);
                }
                a._map.RemoveAt(a._map.Count - 1); //Sau khi trở ngược về đỉnh trước thì xoá đi điểm đã đến vì kết quả đã được lưu
                a._tongTrongSo -= i._trongSo;
            }
        }

    }
}
