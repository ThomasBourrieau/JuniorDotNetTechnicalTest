global using Microsoft.VisualStudio.TestTools.UnitTesting;
global using DotNetTest;

namespace DotNetTestUnitTests;

/// <summary>
/// Tested skills : 
/// - use generic functions windows (sessions, environement variables...)
/// - manipulate collections of items
/// - manipulate custom indexer
/// - manipulate string
/// - use vs code and unit tests
/// </summary>
[TestClass]
public class EnvironmentVariablesTests
{
    [TestMethod]
    public void ExerciceTest1()
    {
        //For this test, you have to write the content of GrtNextEnvironment.LoadEnvironmentVariables to fill the content of 
        //GrtNextEnvironment.EnvironmentVariables with the machine environement variables
        var grtenv = new GrtNextEnvironment();  

        //we assert EnvironmentVariables is filled
        Assert.IsTrue(grtenv.EnvironmentVariables.Count > 0);
    } 
    
    [TestMethod]
    public void ExerciceTest2()
    {
        //For this test, implement the method GrtNextEnvironment.GetByValue(string) to return all KeyValuePair of the dictionary EnvironmentVariables
        // that containts the value in parameter ignoring case.
        var grtenv = new GrtNextEnvironment();  
        var grtEnvVars = grtenv.GetByValue("windows");

        //We assert that result of search for windows contains multiple results
        Assert.IsTrue( grtEnvVars.Count() > 0);
        
        //we ensure we match key windir in results
        var keyValue = grtEnvVars.FirstOrDefault(v => v.Key == "windir");
        Assert.AreEqual(keyValue.Key,"windir",true);
    }

     [TestMethod]
    public void ExerciceTest3()
    {
        //For this test, implement the indexer public string this[string varName] in class GrtNextEnvironment 
        // so we can get content of an environment variable using indexer[]. the indexer will return null if parameter is empty or not found
        var grtenv = new GrtNextEnvironment(); 

        //test valid entry with expected output
        Assert.AreEqual(@"C:\WINDOWS",grtenv["windir"]);
        //test invalid entry
        Assert.IsNull(grtenv["BADENV"]);
        Assert.IsNull(grtenv[" "]);
    }

    
     [TestMethod]
    public void ExerciceTest4()
    {
        //For this test, implement the content of GrtNextEnvironment.LoadUserContext to fill the property UserName whith current user logged name
        // and property SessionDomain with current user logged domain
         var grtenv = new GrtNextEnvironment(); 

        //test username has been set
        Assert.IsFalse(string.IsNullOrWhiteSpace(grtenv.UserName));
        //test domain is valid, supposed to be TERA in GRTgaz laptop
        Assert.AreEqual("TERA",grtenv.SessionDomain);
        //test we match the user name in the OneDrive environement variable value
        Assert.IsTrue( grtenv["OneDrive"].Contains(grtenv.UserName));
    }
}