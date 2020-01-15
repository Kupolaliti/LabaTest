using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace Laba1
{
    class DB
    {
        static SqlConnection connect;
        static public int SQL_CONNECT(string Login, string Password)
        {
            try
            {
                string connection = @"Data Source=.\SQLEXPRESS;Initial Catalog=LabISIS;User Id = Pchelovek; Password = Pchela;";
                connect = new SqlConnection(connection);
                connect.Open();
                SqlCommand proverka = new SqlCommand("EnterPchel", connect);
                proverka.CommandType = CommandType.StoredProcedure;
                proverka.Parameters.Add(new SqlParameter("@Login", SqlDbType.NVarChar, 25)).Value = Login;
                proverka.Parameters.Add(new SqlParameter("@Parol", SqlDbType.NVarChar, 25)).Value = Password;
                proverka.Parameters.Add(new SqlParameter("@PchelID", SqlDbType.Int)).Direction = ParameterDirection.Output;
                proverka.ExecuteNonQuery();
                connect.Close();
                if (Convert.ToInt32(proverka.Parameters["@PchelID"].Value) == -1)
                    return -1;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        static public int UpdateINI(int Height, int Width, float Opacity, string Text, int LocationX, int LocationY, float FontS)
        {
            try
            {
                SqlCommand Upd = new SqlCommand(@"UPDATE [INI] SET [Height] = @Height, [Width] = @Width, [Opacity] = @Opacity, [Text] = @Text, [Location.X] = @LocationX, [Location.Y] = @LocationY, [Font.Size] = @FontS", connect);
                Upd.Parameters.AddWithValue("@Height", Height);
                Upd.Parameters.AddWithValue("@Width", Width);
                Upd.Parameters.AddWithValue("@Opacity", Opacity);
                Upd.Parameters.AddWithValue("@Text", Text);
                Upd.Parameters.AddWithValue("@LocationX", LocationX);
                Upd.Parameters.AddWithValue("@LocationY", LocationY);
                Upd.Parameters.AddWithValue("@FontS", FontS);
                connect.Open();
                Upd.ExecuteNonQuery();
                connect.Close();
                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally { connect.Close(); }
        }

        static public int UpdateRes(string FirstText, string SecondText)
        {
            try
            {
                SqlCommand Upd = new SqlCommand(@"UPDATE [Результат] SET [Первый текст] = @FirstText, [Второй текст] = @SecondText", connect);
                Upd.Parameters.AddWithValue("@FirstText", FirstText);
                Upd.Parameters.AddWithValue("@SecondText", SecondText);
                connect.Open();
                Upd.ExecuteNonQuery();
                connect.Close();
                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally { connect.Close(); }
        }
    }
}
