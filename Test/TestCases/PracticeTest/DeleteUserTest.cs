using FluentAssertions;
using Practice.Core.Extensions;
using Practice.Core.Report;
using Practice.Services.Helper;
using Practice.Services.Model.Request;
using Practice.Services.Service;

namespace Practice.Test.TestCases.PracticeTest;

public class DeleteUserTest : BaseTest
{
    private UserServices _userServices;

    public DeleteUserTest() : base()
    {
        _userServices = new UserServices(ApiClient);
    }
    [Test]
    [TestCase("user_1")]
    public async Task DeleteUser (string userKey)
    {
        ReportLog.Info("1.Create User");
        CreateUserDtoReq userReq = UserData[userKey];
        var responseCreateUser = await _userServices.CreateUser(userReq);
        var resultCreatUser = responseCreateUser.Data;
        
        ReportLog.Info("2.Get Id To Perform Delete");
        var idUser = resultCreatUser.Data.Id;
        
        ReportLog.Info("2.Delete User");
        var response =   _userServices.DeleteUser(idUser);
        
       
        var result = response.Data;
        ReportLog.Info("2.Verify Status Code");
        response.VerifyStatusCodeOk();
        ReportLog.Info("2.Verify Data Response of Delete User");
        result.Code.Should().Be(204);
        result.Meta.Should().BeNull();
        result.Data.Should().BeNull();
    }
}