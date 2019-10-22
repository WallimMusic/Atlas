using System;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Obje.Classes;
using Erp;
class ErpManager
{
    public string Screen, connStr;

    private ArrayList m_Parameters = null;
    private SqlConnection m_Connection = null;
    private SqlTransaction m_Transaction = null;

    private bool m_HasTransaction = false;

    public ErpManager()
    {
        CreatGlobalVariables();
    }

    private void CreatGlobalVariables()
    {
        m_Parameters = new ArrayList();
    }

    #region Parameter Functions

    public void AddParameterValue(string parameterName, object value)
    {
        AddParameterValue(parameterName, value, 50);
    }

    public void AddParameterValue(string parameterName, object value, int size)
    {
        AddParameterValue(parameterName, value, SqlDbType.VarChar, size);
    }

    public void AddParameterValue(string parameterName, object value, SqlDbType dbType)
    {
        SqlParameter sqlParameter = new SqlParameter();
        sqlParameter.ParameterName = parameterName;
        sqlParameter.SqlDbType = dbType;
        sqlParameter.Value = value;
        m_Parameters.Add(sqlParameter);
    }

    public void AddParameterValue(string parameterName, object value, SqlDbType dbType, int size)
    {
        SqlParameter sqlParameter = new SqlParameter();
        sqlParameter.ParameterName = parameterName;
        sqlParameter.SqlDbType = dbType;
        sqlParameter.Size = size;
        sqlParameter.Value = value;
        m_Parameters.Add(sqlParameter);
    }

    public void parameterDelete()
    {
        m_Parameters.Clear();
    }

    #endregion

    #region Transaction Functions

    public void BeginTransaction()
    {
        if (hasActiveConnection())
        {
            m_Transaction = m_Connection.BeginTransaction();
            m_HasTransaction = true;
        }
    }

    public void CommitTransaction()
    {
        if (m_HasTransaction)
        {
            m_HasTransaction = false;
            m_Transaction.Commit();
            CloseConnection();
        }
    }

    public void RollBackTransaction()
    {
        if (m_HasTransaction)
        {
            m_HasTransaction = false;
            m_Transaction.Rollback();
            CloseConnection();
        }
    }

    #endregion

    #region Connection Functions

    public void SetupConnection()
    {
        m_Connection = new SqlConnection();


        m_Connection.ConnectionString = Erp.Properties.Settings.Default.connStr;

        if (m_Connection.State != ConnectionState.Open)
        {
            try
            {
                m_Connection.Open();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
        }
    }

    public void SetupConnection(string connStr)
    {
        m_Connection = new SqlConnection();
        if (m_Connection.State != ConnectionState.Open)
        {
            m_Connection = new SqlConnection();
            m_Connection.ConnectionString = connStr;

            try
            {
                m_Connection.Open();
            }
            catch (Exception)
            {
                throw new Exception("Server ile Bağlantı Kurulamadı.");
            }
        }
    }

    private SqlCommand CreateCommand(string sqlString)
    {
        return CreateCommand(sqlString, CommandType.Text);
    }

    private SqlCommand CreateCommand(string sqlString, CommandType commandType)
    {
        if (!hasActiveConnection())
        {
            SetupConnection();
        }

        SqlCommand OleDbCommand = new SqlCommand();
        OleDbCommand.CommandType = commandType;
        OleDbCommand.Connection = m_Connection;
        if (m_HasTransaction)
        {
            OleDbCommand.Transaction = m_Transaction;
        }
        OleDbCommand.CommandText = sqlString;

        foreach (SqlParameter sqlParameter in m_Parameters)
        {
            OleDbCommand.Parameters.Add(sqlParameter);
        }

        return OleDbCommand;
    }

    public int RunCommand(string sqlString)
    {
        SqlCommand OleDbCommand = CreateCommand(sqlString);

        int effectedRowCount = OleDbCommand.ExecuteNonQuery();
        m_Parameters.Clear();

        return effectedRowCount;
    }

    public int RunCommand(string sqlString, CommandType commandType)
    {
        SqlCommand OleDbCommand = CreateCommand(sqlString, commandType);

        int effectedRowCount = OleDbCommand.ExecuteNonQuery();
        m_Parameters.Clear();

        parameterDelete();
        return effectedRowCount;

    }

    public bool ExecuteReader(string sqlString)
    {
        SqlCommand OleDbCommand = CreateCommand(sqlString);
        SqlDataReader sqlDReader = OleDbCommand.ExecuteReader();
        bool readerResult = false;
        if (sqlDReader.Read())
        {
            readerResult = true;
        }
        sqlDReader.Close();
        m_Parameters.Clear();

        return readerResult;
    }

    public SqlDataReader GetDataReader(string sqlString)
    {
        SqlCommand OleDbCommand = CreateCommand(sqlString);
        SqlDataReader sqlDReader = OleDbCommand.ExecuteReader();
        object[] dataReaderArray = new object[1];
        if (sqlDReader.Read())
        {
            return sqlDReader;
        }
        sqlDReader.Close();
        m_Parameters.Clear();
        return null;
    }

    public SqlDataReader GetDataReaderValues(string sqlString)
    {
        SqlCommand OleDbCommand = CreateCommand(sqlString);
        SqlDataReader sqlDReader = OleDbCommand.ExecuteReader();
        if (sqlDReader.Read())
        {
            return sqlDReader;
        }
        return null;
    }

    public object GetDataValue(string sqlString, string VarC)
    {
        SqlCommand OleDbCommand = CreateCommand(sqlString);
        SqlDataReader sqlDReader = OleDbCommand.ExecuteReader();
        if (sqlDReader.Read())
        {
            return sqlDReader[VarC];
        }
        return null;
    }

    public object GetDataMix(string sqlString)
    {
        SqlCommand OleDbCommand = CreateCommand(sqlString);
        SqlDataReader sqlDReader = OleDbCommand.ExecuteReader();
        if (sqlDReader.Read())
        {
            return sqlDReader[0];
        }
        return null;
    }

    public DataSet GetDataSet(string sqlString)
    {
        return GetDataSet(sqlString, CommandType.Text);
    }

    public DataSet GetDataSet(string sqlString, CommandType commandType)
    {
        SqlCommand sCommand = CreateCommand(sqlString, commandType);
        SqlDataAdapter OleDbDataAdapter = new SqlDataAdapter();
        OleDbDataAdapter.SelectCommand = sCommand;
        DataSet dataSet = new DataSet();
        //OleDbDataAdapter.Fill(dataSet);
        m_Parameters.Clear();

        return dataSet;
    }

    public DataSet GetDataSet(string sqlString, CommandType commandType, DataSet dataSet, string tableName)
    {
        SqlCommand sCommand = CreateCommand(sqlString, commandType);
        SqlDataAdapter OleDbDataAdapter = new SqlDataAdapter();
        OleDbDataAdapter.SelectCommand = sCommand;
        OleDbDataAdapter.Fill(dataSet, tableName);
        m_Parameters.Clear();

        return dataSet;
    }

    public DataTable GetDataTable(string sql)
    {
        DataTable table = new DataTable();
        SqlCommand sCommand = CreateCommand(sql);
        SqlDataAdapter OleDbDataAdapter = new SqlDataAdapter();
        OleDbDataAdapter.SelectCommand = sCommand;
        OleDbDataAdapter.Fill(table);
        m_Parameters.Clear();

        return table;
    }

    public object GetScalarValue(string sqlString)
    {
        SqlCommand OleDbCommand = CreateCommand(sqlString);
        object result = OleDbCommand.ExecuteScalar();
        m_Parameters.Clear();

        return result;
    }

    public bool hasActiveConnection()
    {
        if (m_Connection != null && m_Connection.State == ConnectionState.Open)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CloseConnection()
    {
        if (hasActiveConnection())
        {
            m_Connection.Close();
        }
    }

    public bool Connected(string connStr)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = connStr;
        try
        {
            conn.Open();
            conn.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }

    #endregion


}

