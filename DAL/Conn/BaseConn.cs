using Dapper;
using Microsoft.Data.SqlClient;
using MySqlConnector;
using System.Data;

namespace DAL.Conn;


public abstract class BaseConnectionSqlServer(string connectionString)
{
    public IDbConnection Connections => new SqlConnection(connectionString);  
}

public abstract class BaseConnectionMySqlServer(string connectionString)
{
    public IDbConnection Connections => new MySqlConnection(connectionString);
}

// concrete class
public class Server130(string connStr) : BaseConnectionSqlServer(connStr) { }

public class ServerEHR(string connStr) : BaseConnectionSqlServer(connStr) { }

public class ServerProd(string connStr) : BaseConnectionSqlServer(connStr) { }

public class ServerCikMan(string connStr) : BaseConnectionMySqlServer(connStr) { }
