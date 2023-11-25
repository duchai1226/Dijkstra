using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dijkstra
{
    struct Result
    {
        public int _tongTrongSo;
        public List<String> _map;
        public Result(int _tongTrongSo,List<string> _map)
        {
            this._tongTrongSo = _tongTrongSo;
            this._map = _map;
        }
    }
    class XuLy
    {
        Input _InputData=new Input();
        List<Result> _ketQua = new List<Result> { new Result { _tongTrongSo = 0, _map = new List<string>() } };  // Danh sach chua ket qua
        public List<Result> ketQua
        {
            get
            {
                return _ketQua;
            }
            set
            {
                _ketQua = value;
            }
        }
       
        public Input InputData
        {
            get
            {
                return _InputData;
            }
            set
            {
                _InputData = value;
            }
        }      
        public void ReturnResult(Result a)
        {
            _ketQua.Add(a);
        }
        public void TinhToan(Dinh Root)
        {
            Result a = new Result ();// tao 1 bien kieu Result de tra ket qua ve danh sach ket qua
            List<string> check = new List<string> { _InputData.Root };//List chua cac dinh da xet
            a._map = new List<string> {_InputData.Root};//Khoi tao so do duong di ngan nhat
            //List<DinhKe> temp = new List<DinhKe>();
            //Root.FindNearPoint(_InputData.DsTrongSo);// Xac dinh danh sach cac dinh ke
            //Root.DsDinhKe=Root.DsDinhKe.OrderBy(t => t._trongSo).ToList();//Sap xep lai thu tu ds dinh
            Root.Duyet(_InputData,this, check, a);//Tim cac duong di den dich
        }
        //public void DuongDiNganNhat()
        //{
        //    _InputData.FindPoint(_InputData.Root).Duyet(_InputData,this);
        //}
        public void Xuat()
        {
            Result min = new Result();
            min = ketQua[0];
            foreach(Result i in ketQua)
            {
                if(i._tongTrongSo<min._tongTrongSo)
                {
                    min = i;
                }
            }
            Console.Write("Duong di ngan nhat: ");
            for(int i=0;i<min._map.Count;i++)
            {
                Console.Write("{0}\t", min._map[i]);
            }
            Console.Write("\nDo dai duong di: {0}",min._tongTrongSo);

        }
    }
        
}
