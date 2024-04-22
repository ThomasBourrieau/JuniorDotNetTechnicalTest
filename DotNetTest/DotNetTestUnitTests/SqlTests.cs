namespace DotNetTestUnitTests;

[TestClass]
public class SqlTests
{
    /// <summary>
    /// Instance of sql database, initialized in InitializeTestClass
    /// </summary>
    static SQLiteManager _dbInstance;

    /// <summary>
    /// Initiale db instance and generate its content
    /// </summary>
    /// <param name="testContext"></param>
    [ClassInitialize]
    public static void InitializeTestClass(TestContext testContext)
    {
        _dbInstance = new SQLiteManager();
        _dbInstance.GenerateLocalDb();
    }

    [TestMethod]
    public void Exercice1SelectUserTest()
    {
        //TODO TEST 
        //For this test, implement the content of SQLiteManager.GetAppUsers function to return the list of AppUser in _dbInstance. 
        //You can see database structure and content in SQLiteManager.GenerateLocalDb method.
        
        var users = _dbInstance.GetAppUsers().ToList();
        Assert.AreEqual(3, users.Count);
        Assert.AreEqual("Bourrieau", users[0].Name);
        Assert.AreEqual(0, users[0].Authorizations.Count);
    }

    [TestMethod]
    public void Exercice2SelectUserWithAuthorizationsTest()
    {
        //TODO TEST 
        //For this test, modify the content of SQLiteManager.GetAppUsers to take 
        //withAuthorizations parameter in account so we also load list of authorizations.
        //if parameter is set to false, authorizations must not be loaded, as before
        
        //test without authorizations
        Exercice1SelectUserTest();
        
        //test with authorizations 
        var users = _dbInstance.GetAppUsers(true).ToList();
        Assert.AreEqual(3, users.Count());
        Assert.AreEqual("Bourrieau", users[0].Name);
        Assert.AreEqual(2, users[0].Authorizations.Count);
        Assert.AreEqual("Vu", users[2].Name);
        Assert.AreEqual(0, users[2].Authorizations.Count);
    }

    [TestMethod]
    public void Exercice3AppUserToStringTest()
    {
        //TODO TEST 
        //For this test, modify AppUser class so call to ToString method display : 
        //if authorizations are loaded
        //      - User <Id> : <Name> <FirstName> AUTH (<AuthorizationName1> - <AuthorizationName2> - ... - <AuthorizationNamex>)
        //else of if no authorizations 
        //      - User <Id> : <Name> <FirstName>

        var users = _dbInstance.GetAppUsers(true).ToList();
        Assert.AreEqual("User 1 : Bourrieau Thomas AUTH (AUTH_ADM - AUTH_DEV)",users[0].ToString());
        Assert.AreEqual("User 3 : Vu Tri",users[2].ToString());

        
        users = _dbInstance.GetAppUsers(false).ToList();
        Assert.AreEqual("User 1 : Bourrieau Thomas",users[0].ToString());        
    }
}
