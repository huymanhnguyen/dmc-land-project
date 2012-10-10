using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DMC.Database;

namespace DMC.Land.DangKyBienDong
{
    class clsMatBonGCN
    {
    //Khai báo mảng tham số
    string[] Paras = {"@MaHoSoCapGCN"};
    //Khai báo biến nhận chuỗi kết nối Database
    string strConnnection  = "";
    /* Khai báo biến kiểm tra lỗi */
    string strError = "";
    /* Khai báo biến mã hồ sơ cấp GCN */
    string  strMaHoSoCapGCN;

    /* Khai báo thuộc tính nhận chuỗi kết nối Database */
    public string  Connection
    {
        set {strConnnection = value;}
    }
    /* Khai báo thuộc tính nhận thông báo lỗi */
    public string Err
    {
        get{return strError ;}
    }
    /* Khai báo thuộc tính Mã hồ sơ cấp GCN */
    public string MaHoSoCapGCN 
    {
        set {strMaHoSoCapGCN = value ;}
    }

    
    // Truy vấn thông tin mặt 4 giấy chứng nhận theo Mã hồ sơ cấp GCN
    public  DataTable   SelectNoiDungThayDoiVaCoSoPhapLyByMaHoSoCapGCN()
    {
        DataTable dtRecords = new DataTable();
        this.GetData("spSelectNoiDungThayDoi", ref dtRecords);
        return dtRecords;
    }

    private string GetData( string   strStoreProcedureName , ref  System.Data.DataTable  dtRecords)
    {
        try
        {
            /* Khai báo và khởi tạo lớp thao tác cơ sở dữ liệu */
            clsDatabase Database = new clsDatabase();
            /* Gán giá trị cho thuộc tính chuỗi kết nối cơ sở dữ liệu */
            Database.Connection = strConnnection;
            if (Database.OpenConnection() == true )
            {
                /* Khai báo mảng giá trị */
                string[] Values =  {strMaHoSoCapGCN};
                /* Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến */
                if (Paras.Length  != Values.Length)
                {
                    return "Mảng giá trị chuyền vào chưa phù hợp!";
                }
                Database.getValue(ref dtRecords, strStoreProcedureName, Paras, Values);
                Database.CloseConnection();
                strError = "";
            }
        }
        catch (Exception ex)
        {
            strError = ex.Message;
            System.Windows.Forms.MessageBox.Show ("Thông báo lỗi: " + System.Environment.NewLine + strError );
        }
        return strError;
    }

    }
}
