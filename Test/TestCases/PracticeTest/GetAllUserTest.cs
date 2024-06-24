using System.Net;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Practice.Core;
using Practice.Core.Extensions;
using Practice.Core.Report;
using Practice.Services.Service;

namespace Practice.Test.TestCases.PracticeTest;

public class GetAllUserTest : BaseTest
{
    private UserServices _userServices;

    public GetAllUserTest() : base()
    {
        _userServices = new UserServices(ApiClient);
    }
    [Test]
    public async Task GetAllUsersAsyncTest()
    {
        ReportLog.Info("1.Get ALl User");
        var response = await _userServices.GetAllUser();
        var result = response.Data;
        ReportLog.Info("2.Vefify Status Code");
        response.VerifyStatusCodeOk();
        ReportLog.Info("3.Vefify Data");
        result.Meta.Should().NotBeNull();
        result.Meta.Pagination.Total.Should().BeGreaterThan(0, "because Total should be a positive number");
        result.Meta.Pagination.Page.Should().BeGreaterThan(0, "because Page should be a positive number");
        result.Meta.Pagination.Pages.Should().BeGreaterThan(0, "because Pages should be a positive number");
        result.Meta.Pagination.Limit.Should().BeGreaterThan(0, "because Limit should be a positive number");
        var expectedKeys = new List<string> { "id", "name", "email", "gender", "status" };
        var listData = result.Data;
        foreach (var item in listData)
        { 
            JObject user = JObject.FromObject(item);
            foreach (var key in expectedKeys)
            {
                user.ContainsKey(key).Should().BeTrue($"because user should have the key '{key}'");
            }
        }
    }
}