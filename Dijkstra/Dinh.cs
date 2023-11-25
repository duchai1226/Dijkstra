using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    struct DinhKe
    {
        public int _trongSo;
        public Dinh _dinh;// Ten cua dinh ke tao voi dinh dang xet canh co trong so la _trongSo
        //public string _status;
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

        public void Duyet(Input _InputData,XuLy xlds,List<string> check,Result a)
        {
            if(DsDinhKe.Count==0)
                FindNearPoint(_InputData.DsTrongSo);
            
            DsDinhKe = DsDinhKe.OrderBy(t => t._trongSo).ToList();
            //int n = DsDinhKe.Count;
            foreach (DinhKe i in DsDinhKe.ToList())
            {
                if (i._dinh.CheckList(check) > 0)
                    DsDinhKe.Remove(i);
            }
            foreach (DinhKe i in DsDinhKe)
            {
                a._tongTrongSo += i._trongSo;
                a._map.Add(i._dinh.name);
                check.Add(i._dinh.name);
                Result temp = new Result(a._tongTrongSo, a._map);
                if (i._dinh.name == _InputData.End)
                {
                    xlds.ketQua.Add(temp); 
                }           
                else
                {
                    i._dinh.Duyet(_InputData, xlds, check, a);
                }
                temp._map.RemoveAt(temp._map.Count - 1);
                temp._tongTrongSo -= i._trongSo;
                //a._map.RemoveAt(a._map.Count - 1);
                a = temp;
            }
        }

    }
}
