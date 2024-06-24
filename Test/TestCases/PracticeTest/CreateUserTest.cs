using System.Net;
using FluentAssertions;
using Newtonsoft.Json;
using Practice.Core.Extensions;
using Practice.Core.Report;
using Practice.Services.Helper;
using Practice.Services.Model.Request;
using Practice.Services.Model.Response;
using Practice.Services.Service;
using RestSharp;

namespace Practice.Test.TestCases.PracticeTest;

public class CreateUserTest : BaseTest
{
    private UserServices _userServices;

    public CreateUserTest() : base()
    {
        _userServices = new UserServices(ApiClient);
    }
    [Test]
    [TestCase("user_1")]
    public async Task CreateUser(string userKey)
    {
        ReportLog.Info("1.Create User");
        CreateUserDtoReq userReq = UserData[userKey];
        var response =  await _userServices.CreateUser(userReq);
        var result = response.Data;
        UserHelper.StoreDataToDeleteUser(result.Data.Id);
        ReportLog.Info("2.Verify Status Code");
        response.VerifyStatusCodeOk();
        ReportLog.Info("3.Verify Data");
        response.Data.Code.Should().Be(201);
        result.Data.Should().BeEquivalentTo(userReq, options => options
            .ExcludingMissingMembers());
    }

    [TearDown]
    public void TearDown()
    {
        UserHelper.DeleteUserFromStorage(_userServices);
    }
    
}