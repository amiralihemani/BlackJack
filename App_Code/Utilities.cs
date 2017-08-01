using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// These are utility methods.
/// </summary>
public static class Utilities
{
    public static DataTable getRecordSet(string query)
    {
        SqlConnection connDB = new SqlConnection(ConfigurationManager.ConnectionStrings["BlackJackDatabase"].ConnectionString);
        SqlDataAdapter adapterDB = new SqlDataAdapter(query, connDB);

        DataSet datasetDB = new DataSet();
        adapterDB.Fill(datasetDB, "RecordSet");
        connDB.Close();
        return datasetDB.Tables["RecordSet"];
    }

    public static bool updateRecord(string query)
    {
        SqlConnection connDB = new SqlConnection(ConfigurationManager.ConnectionStrings["BlackJackDatabase"].ConnectionString);
        SqlCommand sqlComm = new SqlCommand();
        sqlComm = connDB.CreateCommand();
        sqlComm.CommandText = query;
        connDB.Open();
        sqlComm.ExecuteNonQuery();
        connDB.Close();
        return true;
    }


}