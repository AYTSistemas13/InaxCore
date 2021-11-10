using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InaxCore.Helpers.SqlConections
{
  public class ProdConection
  {

    int rowsAfected = 0;

    public static async Task<SqlDataReader> GetReader(string queryString)
    {
      //pruebas
      //string connectionString = @"Server=ayt.database.windows.net;Database=aytProd;User ID=aytuser;Password=$r%ER2aY#wBD3cDP";
      //produccion
      string connectionString = @"Server=ayt.database.windows.net;Database=aytExport;User ID=aytuser;Password=$r%ER2aY#wBD3cDP";
      SqlConnection cnn = new SqlConnection(connectionString);
      SqlCommand command = new SqlCommand(queryString, cnn);
      cnn.Open();
      SqlDataReader dataReader = await command.ExecuteReaderAsync();
      return dataReader;
    }

    public static async Task<bool> StartNonQuery(string queryString)
    {
      //pruebas
      //string connectionString = @"Server=ayt.database.windows.net;Database=aytProd;User ID=aytuser;Password=$r%ER2aY#wBD3cDP";
      //productivo
      string connectionString = @"Server=ayt.database.windows.net;Database=aytExport;User ID=aytuser;Password=$r%ER2aY#wBD3cDP";
      SqlConnection cnn = new SqlConnection(connectionString);
      SqlCommand command = new SqlCommand(queryString, cnn);
      cnn.Open();
      try
      {
        await command.ExecuteNonQueryAsync();
        cnn.Close();
        return true;
      }
      catch (Exception e)
      {
        return false;
      }

    }

    public async Task<int> queryInsert(String queryStr)
    {
      //pruebas
      //string connectionString = @"Server=ayt.database.windows.net;Database=aytProd;User ID=aytuser;Password=$r%ER2aY#wBD3cDP";
      //productivo
      string connectionString = @"Server=ayt.database.windows.net;Database=aytExport;User ID=aytuser;Password=$r%ER2aY#wBD3cDP";
      SqlConnection conn = new SqlConnection(connectionString);
      SqlCommand command = new SqlCommand(queryStr, conn);
      if (conn.State == ConnectionState.Closed)
        conn.Open();
      try
      {
        rowsAfected = command.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
        return -2;
      }
      return rowsAfected;
    }

  }
}