using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapInfo.Geometry;
using MapInfo;
using MapInfo.Mapping;
using MapInfo.Data;
namespace DMC.Land.TinhToanDenBu
{
    class Class1
    {
        List<DPoint> tapdiem;
        bool[] tapdiemdadi;
        List<DPoint> tapketqua;
        private Map pMap;
        int count;
        public Map map {
            set { pMap = value; }
            get { return pMap; }
        }
        public List<DPoint> arrtapDiem
        {
            set { tapdiem = value; }
            get { return tapdiem; }
        }
        public List < DPoint>  arrKetQua
        {
            set { tapketqua = value; }
            get { return tapketqua; }
        }
        public int CountPoint
        {
            set { count = value; }
            get { return count; }
        }
        
        public Class1 (IEnumerable<DPoint> tapdiemxet)
        {
            tapdiem = new List<DPoint>(tapdiemxet);
            tapketqua = new List<DPoint>();

            tapdiemdadi = new bool[tapdiem.Count];
            for (int i = 0; i < tapdiem.Count; i++)
                tapdiemdadi[i] = false;            
        }
        /// <summary>
        /// i la diem dang xet
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public void TryOthers(List<DPoint> ls, int i)
        {
            if (i < tapdiem.Count)
            {
                //for (int j = 0; j < tapdiem.Count-1 ; j++)
                    for (int j = 0; j < tapdiem.Count; j++)
                {
                    //if (tapdiemdadi[j] == false && (ls.Count > 1 ? !XetGiao(ls, tapdiem[j], ls[ls.Count - 1]) : true))
                        if ( (ls.Count > 1 ? !XetGiao(ls, tapdiem[j], ls[ls.Count -1]) : true  ) && tapdiemdadi[j] == false )
                    {

                        // Danh dau diem dang xet da duoc di
                        tapdiemdadi[j] = true;
                        // Thu cau hinh tiep theo

                        ls.Add(tapdiem[j]);

                        TryOthers(ls, i + 1);

                        tapdiemdadi[j] = true;
                    }
                 }
            }
            
        }

        private bool XetGiao(List<DPoint> DiemDaDiQua, DPoint x1, DPoint x2)
        {
            // tao mot tap hop cac diem qua 2 diem x1, x2
            DPoint [] DLine = new DPoint[2];
            DLine[0]=x1;
            DLine[1]=x2 ;
            //tao tap hop diem da qua
            DPoint[] TapDiemDaQua = new DPoint[DiemDaDiQua.Count];
            for (int i = 0; i < DiemDaDiQua.Count; i++) {
                TapDiemDaQua[i] = DiemDaDiQua[i];
            }
            //tao multilPolyLine qua tap hop diem x1,x2
            MultiCurve poDLine = new MultiCurve(pMap.GetDisplayCoordSys(), CurveSegmentType.Linear, DLine);
            //tao multilPolyLine qua tap hop diem da di qua
            MultiCurve poDiemDaQua = new MultiCurve(pMap.GetDisplayCoordSys(), CurveSegmentType.Linear, TapDiemDaQua);
            MultiPoint  point = new MultiPoint(pMap.GetDisplayCoordSys());
            //lay giao diem cua 2 polyline tim dc
            point = poDLine.IntersectNodes(poDiemDaQua, IntersectTypes.InclAll);
          
                if (point.PointCount > 0)
                {
                    foreach (DPoint dp in point) {
                        double dx1, dx2, dy1, dy2, dx, dy;
                        dx=Convert.ToDouble(string.Format("{0:0.0}", dp.x));
                        dy = Convert.ToDouble(string.Format("{0:0.0}", dp.y));
                        dx1 = Convert.ToDouble(string.Format("{0:0.0}", DLine[0].x));
                        dy1 = Convert.ToDouble(string.Format("{0:0.0}", DLine[0].y));
                        dx2 = Convert.ToDouble(string.Format("{0:0.0}", DLine[1].x));
                        dy2 = Convert.ToDouble(string.Format("{0:0.0}", DLine[1].y));
                        if (((dx==dx1)&&(dy==dy1 ))||((dx==dx2)&&(dy==dy2)))
                        {
                            return false;
                        }
                        else {
                            return true;
                        }
                    }
                    //neu co giao diem
                    return true   ;
                }
                else
                {
                    //neu ko co giao diem
                    return false  ;
                }
           
         }

    }
}
