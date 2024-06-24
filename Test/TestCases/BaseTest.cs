using NUnit.Framework.Interfaces;
using Practice.Core;
using Practice.Core.Configurations;
using Practice.Core.Extensions;
using Practice.Core.Report;
using Practice.Core.ShareData;
using Practice.Core.Utilities;
using Practice.Services.Model.Request;
using Practice.Services.Service;
using Practice.Test.Constants;
using Practice.Test.TestCases.PracticeTest;

namespace Practice.Test;

public class BaseTest
{
    protected Dictionary<string, CreateUserDtoReq> UserData;
    protected Dictionary<string, UpdateUserDtoReq> UserDataUpdate;
    
    
    protected APIClient ApiClient;

    public BaseTest()
    {
        UserData = JsonFileUtility.ReadAndParse<CreateUserDtoReq>(FileConstant.AccountFilePath.GetAbsolutePath());
        UserDataUpdate = JsonFileUtility.ReadAndParse<UpdateUserDtoReq>(FileConstant.UpdateUserFilePath.GetAbsolutePath());
        ApiClient = new APIClient(ConfigurationManager.GetConfiguration()["application:url"]);
        ExtentTestManager.CreateParentTest(TestContext.CurrentContext.Test.ClassName);
    }

    [SetUp]
    public void SetUp()
    {
        ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
        DataStorage.InitData();
    }
    [TearDown]
    public void TearDown()
    {
        DataStorage.ClearData();
        UpdateTestReport(); 
    }
    public void UpdateTestReport()
    {
        var status = TestContext.CurrentContext.Result.Outcome.Status;
        var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : TestContext.CurrentContext.Result.StackTrace;
        var message = TestContext.CurrentContext.Result.Message;

        switch (status)
        {
            case TestStatus.Failed:
                ReportLog.Fail($"Test failed with message: {message}");
                ReportLog.Fail($"Stacktrace: {stacktrace}");
                break;
            case TestStatus.Inconclusive:
                ReportLog.Skip($"Test inconclusive with message: {message}");
                ReportLog.Skip($"Stacktrace: {stacktrace}");
                break;
            case TestStatus.Skipped:
                ReportLog.Skip($"Test skipped with message: {message}");
                break;
            default:
                ReportLog.Pass("Test passed");
                break;
        }
    }

}