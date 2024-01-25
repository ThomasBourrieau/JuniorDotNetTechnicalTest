namespace DotNetTest;
using System.Collections;
using System.Security.Principal;

public class GrtNextEnvironment
{    

    /// <summary>
    /// List of environement variable in current machine (initialized in constructor)
    /// </summary>
    public IDictionary<string,string> EnvironmentVariables {get;} = new Dictionary<string,string>(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// name of user connected in current session
    /// </summary>
    public string UserName { get; private set; }

    /// <summary>
    /// name of the domain of current user sessions
    /// </summary>
    public string SessionDomain { get; private set; }

    /// <summary>
    /// Index to access value of an environment variable by name. 
    /// return null if parameter is null or empy or not existing in EnvironmentVariables dictionary, else return the value
    /// </summary>
    /// <param name="varName"></param>
    /// <returns></returns>
    public string this[string varName]
    {
        get
        {
            return null;
        }
    }

    /// <summary>
    /// Default constructor, call LoadEnvironmentVariables the environement variables 
    /// </summary>
    public GrtNextEnvironment()
    {
        LoadEnvironmentVariables();
        LoadUserContext();
    }

    /// <summary>
    /// Load informations from current user session and fill SessionDomain and UserName
    /// </summary>
    private void LoadUserContext()
    {
        
    }

    /// <summary>
    /// initialize the EnvironmentVariables dictionary with computer environmenet variables
    /// </summary>
    private void LoadEnvironmentVariables()
    {
        
    }

    /// <summary>
    /// Return all EnvironmentVariables dictionary entries wher value contain filter ignoring case
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public IEnumerable<KeyValuePair<string,string>> GetByValue(string filter)
    {        
        yield break;
    }
}
