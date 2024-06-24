using Practice.Core.ShareData;
using Practice.Services.Service;

namespace Practice.Services.Helper;

public static class UserHelper
{
    public static void StoreDataToDeleteUser(int idUser)
    {
        DataStorage.SetData("hasCreatedUser",true);
        DataStorage.SetData("idUser", idUser);
    }

    public static void DeleteUserFromStorage(UserServices userService)
    {
        if ((bool)DataStorage.GetData("hasCreatedUser"))
        {
             userService.DeleteUser((int)DataStorage.GetData("idUser"));
        };
    }
}