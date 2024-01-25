namespace DotNetTest;

public interface IExtGrtNextEnvironment
{
    /// <summary>
    /// One drive path specified in OneDrive environment variable value
    /// </summary>
    public string OneDrivePath { get; }

    /// <summary>
    /// return total count of files in OneDrivePath and sub folders
    /// </summary>
    /// <returns></returns>
    public int CountSynchronizedFile();
}
