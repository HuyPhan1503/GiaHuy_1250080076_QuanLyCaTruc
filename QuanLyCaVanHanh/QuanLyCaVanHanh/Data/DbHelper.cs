using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCaVanHanh.Data
{
    public static class DbHelper
    {
        private static readonly string ChuoiKetNoi =
            ConfigurationManager.ConnectionStrings["CaTrucDB"].ConnectionString;

        public static SqlConnection TaoKetNoi()
        {
            return new SqlConnection(ChuoiKetNoi);
        }

        // Tạo tham số, null thì chuyển thành DBNull
        public static SqlParameter P(string ten, object giaTri)
        {
            return new SqlParameter(ten, giaTri ?? DBNull.Value);
        }

        // Chạy câu SELECT (dùng cho view)
        public static DataTable Query(string sql, params SqlParameter[] thamSo)
        {
            using (var conn = TaoKetNoi())
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddRange(thamSo);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Gọi stored procedure, trả về kết quả (nếu có)
        public static DataTable CallProc(string tenProc, params SqlParameter[] thamSo)
        {
            using (var conn = TaoKetNoi())
            using (var cmd = new SqlCommand(tenProc, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(thamSo);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static bool KiemTraKetNoi(out string loi)
        {
            try
            {
                using (var conn = TaoKetNoi())
                {
                    conn.Open();
                    loi = null;
                    return true;
                }
            }
            catch (Exception ex)
            {
                loi = ex.Message;
                return false;
            }
        }
    }
}