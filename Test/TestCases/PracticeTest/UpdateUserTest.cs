using FluentAssertions;
using Practice.Core.Extensions;
using Practice.Core.Report;
using Practice.Services.Helper;
using Practice.Services.Model.Request;
using Practice.Services.Service;
using Practice.Test.Constants;

namespace Practice.Test.TestCases.PracticeTest;

public class UpdateUserTest : BaseTest
{
    private UserServices _userServices;

    public UpdateUserTest() : base()
    {
        _userServices = new UserServices(ApiClient);
    }
    [Test]
    [TestCase("update_user", "user_1")]
    public async Task UpdateUser(string userUpdateKey, string userCreateKey)
    {
        ReportLog.Info("1. Create User");
        CreateUserDtoReq userReq = UserData[userCreateKey];
        var responseCreatedUser = await _userServices.CreateUser(userReq);
        
        ReportLog.Info("2. Get Id User To Update User ");
        var resultCreatedUser = responseCreatedUser.Data;
        var idUser = resultCreatedUser.Data.Id;
        
        UserHelper.StoreDataToDeleteUser(idUser);
        ReportLog.Info("3.Update User ");
        UpdateUserDtoReq updateUserDtoReq = UserDataUpdate[userUpdateKey];
        var response = await _userServices.UpdateUser(updateUserDtoReq, idUser);
        
        ReportLog.Info("4.Verify Schema Response Update User ");
        await RestExtensions.VerrifySchema(response.Content, FileConstant.UpdateUserFilePath);
        
        ReportLog.Info("5.Verify Data From Response Update User ");
        var result = response.Data;
        response.VerifyStatusCodeOk();
        result.Code.Should().Be(200);
        result.Data.Should().BeEquivalentTo(updateUserDtoReq, options => options
            .ExcludingMissingMembers());
    }
    [TearDown]
    public void TearDown()
    {
        UserHelper.DeleteUserFromStorage(_userServices);
    }
}