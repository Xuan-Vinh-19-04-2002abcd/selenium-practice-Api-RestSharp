using FluentAssertions;
using Practice.Core.Extensions;
using Practice.Core.Report;
using Practice.Services.Helper;
using Practice.Services.Model.Request;
using Practice.Services.Service;

namespace Practice.Test.TestCases.PracticeTest;

public class GetDetailUserTest : BaseTest
{
    private UserServices _userServices;

    public GetDetailUserTest() : base()
    {
        _userServices = new UserServices(ApiClient);
    }

    [Test]
    [TestCase("user_1")]
    public async Task GetDetailUserAsyncTest(string userKey)
    {
        ReportLog.Info("1.Create User");
        CreateUserDtoReq userReq = UserData[userKey];
        var responseCreateUser = await _userServices.CreateUser(userReq);
        var resultCreatUser = responseCreateUser.Data;
        var idUser = resultCreatUser.Data.Id;
        
        UserHelper.StoreDataToDeleteUser(idUser);
        
        ReportLog.Info("2.Get Detail Users");
        var responseGetDetailUser = await _userServices.GetUserDetail(idUser);
        
        ReportLog.Info("3.Verify response status code");
        responseGetDetailUser.VerifyStatusCodeOk();
        
        ReportLog.Info("4.Verify response data");
        var resultGetDetailUser = responseGetDetailUser.Data;
        
        ReportLog.Info("5.Verify status code");
        responseGetDetailUser.Data.Code.Should().Be(200);
        resultGetDetailUser.Data.Should().BeEquivalentTo(userReq, options => options
            .ExcludingMissingMembers());
    }
    [TearDown]
    public void TearDown()
    {
        UserHelper.DeleteUserFromStorage(_userServices);
    }
}