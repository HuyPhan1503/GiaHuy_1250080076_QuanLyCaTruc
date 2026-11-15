using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyCaVanHanh.Data;

namespace QuanLyCaVanHanh.Services
{
    public static class ThongKeService
    {
        public static DataSet LayBaoCaoThongKe(DateTime tuNgay, DateTime denNgay)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = DbHelper.TaoKetNoi())
            {
                using (SqlCommand cmd = new SqlCommand("usp_BaoCaoThongKe", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DbHelper.P("@TuNgay", tuNgay.Date));
                    cmd.Parameters.Add(DbHelper.P("@DenNgay", denNgay.Date));

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }
            }
            return ds;
        }
    }
}