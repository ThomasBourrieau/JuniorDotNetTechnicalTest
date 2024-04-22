namespace DotNetTest;

public class AppUser
{
    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="FirstName"></param>
    public AppUser(int id, string name, string FirstName)
    {
        this.Id = id;
        this.Name = name;
        this.FirstName = FirstName;
    }

    /// <summary>
    /// Sql Id
    /// </summary>
    public int Id {get;}

    /// <summary>
    /// User name
    /// </summary>
    public string Name { get;  }

    /// <summary>
    /// User First name
    /// </summary>
    public string FirstName { get;  }

    /// <summary>
    /// List of user Authorizations
    /// </summary>
    public List<string> Authorizations { get; } = new List<string>();

    /// <summary>
    /// Add User authorization
    /// </summary>
    /// <param name="authorization"></param>
    public void AddAuthorization(string authorization)
    {
        if(!this.Authorizations.Contains(authorization, StringComparer.OrdinalIgnoreCase))
            this.Authorizations.Add(authorization.Trim().ToUpper());
    }

    /// <summary>
    /// return true if user have authorization in parameter
    /// </summary>
    /// <param name="authorization"></param>
    /// <returns></returns>
    public bool HaveAuthorization(string authorization)
    {
        return this.Authorizations.Contains(authorization,StringComparer.OrdinalIgnoreCase);
    }
}
