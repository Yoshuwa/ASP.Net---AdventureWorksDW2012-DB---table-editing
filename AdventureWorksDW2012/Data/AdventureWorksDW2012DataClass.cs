using System;
using System.Data;
using System.Data.SqlClient;

public class AdventureWorksDW2012DataClass
{
    public static string connectionString
            = "Data Source=(local);Initial Catalog=AdventureWorksDW2012;Integrated Security=SSPI;";

    public static SqlConnection GetConnection()
    {
        SqlConnection connection = new SqlConnection(connectionString);
        return connection;
    }
    
    public int getIdent_Current(string Table)
    {
        string query = null;
        SqlConnection connection = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataReader reader = default(SqlDataReader);
        int returnValue = 0;

        query = "SELECT IDENT_CURRENT('" + Table + "')";
        connection = GetConnection();
        command = new SqlCommand(query, connection);
        command.CommandType = CommandType.Text;
        try
        {
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.HasRows == true)
            {
                while (reader.Read())
                {
                    returnValue = Convert.ToInt32(reader.GetValue(0));
                }
            }
            reader.Close();
            connection.Close();
        }
        catch //(SqlException ex)
        {
            //MessageBox.Show(ex.Message);
        }
        finally
        {
            connection.Close();
        }
        return returnValue;
    }

    public int getIdent_Incr(string Table)
    {
        string query = null;
        SqlConnection connection = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataReader reader = default(SqlDataReader);
        int returnValue = 0;

        query = "SELECT IDENT_INCR('" + Table + "')";
        connection = GetConnection();
        command = new SqlCommand(query, connection);
        command.CommandType = CommandType.Text;
        try
        {
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.HasRows == true)
            {
                while (reader.Read())
                {
                    returnValue = Convert.ToInt32(reader.GetValue(0));
                }
            }
            reader.Close();
            connection.Close();
        }
        catch //(SqlException ex)
        {
            //MessageBox.Show(ex.Message);
        }
        finally
        {
            connection.Close();
        }
        return returnValue;
    }

    public int getAutoID(string Mode, string Table)
    {
        int Ident_Current = getIdent_Current(Table);
        if (Mode == "Last")
        {
            return Ident_Current;
        }
        else if (Mode == "New")
        {
            return Ident_Current = Ident_Current + getIdent_Incr(Table);
        }
        return Ident_Current;
    }

}




 
