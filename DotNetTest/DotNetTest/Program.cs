using DotNetTest;

var grtEnv = new GrtNextEnvironment();
var grtEnvVars = grtEnv.GetByValue("windows");

foreach(var grtEnvVar in grtEnvVars)
{
    Console.WriteLine(grtEnvVar.Key + " : " +grtEnvVar.Value);
}

Console.WriteLine("Path = "+grtEnv["windir"]);

Console.WriteLine("User = "+grtEnv.UserName + "     Domaine = "+grtEnv.SessionDomain);

Console.WriteLine("Path = "+grtEnv["OneDrive"]);

//IExtGrtNextEnvironment extGrtEnv = new ExtGrtNextEnvironment();
//Console.WriteLine("One drive synchronized files = "+extGrtEnv.CountSynchronizedFile());
