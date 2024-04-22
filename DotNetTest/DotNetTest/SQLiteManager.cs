using System.Data.SQLite;
using System.Diagnostics;

namespace DotNetTest;

/// <summary>
/// Management class for SQLLite db 
/// </summary>
public class SQLiteManager
{
    /// <summary>
    /// default database name
    /// </summary>
    const string DEFAULT_DB_NAME = "localDb";

    /// <summary>
    /// this database name
    /// </summary>
    public string DatabaseName { get; } = DEFAULT_DB_NAME;
    
    /// <summary>
    /// this database connection string
    /// </summary>
    public string ConnectionString 
    { 
        get
        {
            return $"Data Source={DatabaseFileName};Version=3;";
        }
    } 

    /// <summary>
    /// this database file name
    /// </summary>
    public string DatabaseFileName 
    { 
        get
        {
            return $"{DatabaseName}.sqlite";
        }
    } 

    /// <summary>
    /// this database file full path
    /// </summary>
    public string DatabaseFilePath 
    { 
        get
        {
            return Path.Combine(Directory.GetCurrentDirectory(), DatabaseFileName);
        }
    } 

    /// <summary>
    /// constrcutor, with dbname
    /// </summary>
    /// <param name="dbName"></param>
    public SQLiteManager(string dbName = DEFAULT_DB_NAME)
    {
        this.DatabaseName = dbName;
    }

    /// <summary>
    /// Generate local db and insert data
    /// </summary>
    /// <param name="dbName"></param>
    public void GenerateLocalDb(string dbName=DEFAULT_DB_NAME)
    {
        if(File.Exists(this.DatabaseFilePath))
        {
            File.Delete(this.DatabaseFilePath);
        }

        // Crée un fichier de base de données SQLite vide
        SQLiteConnection.CreateFile($"{dbName}.sqlite");

        SQLiteConnection connection = new SQLiteConnection(this.ConnectionString);

        // Ouvre la connexion à la base de données
        connection.Open();

        // Create user table
        string createTableSql = 
        @"CREATE TABLE IF NOT EXISTS AppUsers (
            id INTEGER PRIMARY KEY, 
            Name TEXT, 
            FirstName TEXT
        );";
        SQLiteCommand sqlCommand = new SQLiteCommand(createTableSql, connection);
        sqlCommand.ExecuteNonQuery();
        
        // insert users
        sqlCommand.CommandText = 
        @"INSERT INTO AppUsers 
                (FirstName, Name) 
            VALUES 
                ('Thomas', 'Bourrieau'),
                ('Antonin', 'Salembier'),
                ('Tri', 'Vu')";
        sqlCommand.ExecuteNonQuery();

        //Create authorizations table 
        sqlCommand.CommandText = 
        @"CREATE TABLE IF NOT EXISTS Authorizations (
            Id INT PRIMARY KEY,
            Name VARCHAR(255),
            UserId INT,
            FOREIGN KEY (UserId) REFERENCES AppUsers(Id)
        );";            
        sqlCommand.ExecuteNonQuery();

        // insert authorizations 
        sqlCommand.CommandText = 
        @"INSERT INTO Authorizations 
                (Name, UserId) 
            VALUES 
                ('AUTH_ADM', 1),
                ('AUTH_DEV', 1),
                ('AUTH_DEV', 2)";
        sqlCommand.ExecuteNonQuery();

        Console.WriteLine($"{dbName} sqlite database successfully created in {connection.FileName}!");

        // Ferme la connexion à la base de données
        connection.Dispose();
    }

    /// <summary>
    /// Open local db connection
    /// </summary>
    /// <returns></returns>
    public SQLiteConnection GetAndOpenConnection()
    {        
        var connection = new SQLiteConnection(this.ConnectionString);
        connection.Open();
        return connection;
    }

    /// <summary>
    /// Return enumration of all users in db
    /// </summary>
    /// <param name="withAuthorizations">true if you want to select authorizations too</param>
    /// <returns></returns>
    public IEnumerable<AppUser> GetAppUsers(bool withAuthorizations = false)
    {
        /*
        To be implemented in SqlTests.Exercice1SelectUserTest then SqlTests.Exercice2SelectUserWithAuthorizationsTest
        */
        return new List<AppUser>();
    }

    /// <summary>
    /// Select users and display list in Console
    /// </summary>
    /// <param name="withAuthorizations"></param>
    internal void GetAndDisplayUsers(bool withAuthorizations)
    {
        foreach(var appUser in GetAppUsers(withAuthorizations))
        {
            Console.WriteLine(appUser.ToString());
        }
    }
}
