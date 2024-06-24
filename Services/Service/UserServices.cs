using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using Practice.Core;
using Practice.Services.Model.Request;
using Practice.Services.Model.Response;
using Practice.Test.Constants;
using RestSharp;
using Constants = Microsoft.VisualStudio.TestPlatform.CoreUtilities.Constants;

namespace Practice.Services.Service;

public class UserServices
{
    private readonly APIClient _client;

    public UserServices(APIClient apiClient)
    {
        _client = apiClient;
    }
    public async Task<RestResponse<CreateUserDtoRes>> CreateUser(CreateUserDtoReq userReq)
    {
        var response = await _client
            .AddHeader("accept", "application/json")
            .AddAuthorizationHeader(TokenConstant.Token)
            .AddJsonBody(userReq).ExecutePostAsync<CreateUserDtoRes>();
        return response;
    }
  
    public async Task<RestResponse<GetAllUserDtoRes>> GetAllUser( )
    {
        var response = await _client
            .AddHeader("accept", "application/json")
            .AddAuthorizationHeader(TokenConstant.Token)
            .ExecuteyGetAsync<GetAllUserDtoRes>();
        return response;
    }
    public async Task<RestResponse<GetDetailUserDtoRes>> GetUserDetail(int idUser)
    {
        var response = await _client.CreateRequest($"/{idUser}")
            .ExecuteyGetAsync<GetDetailUserDtoRes>();
        return response;
    }
    public async Task<RestResponse<UpdateUserDtoRes>> UpdateUser(UpdateUserDtoReq updateUseReq,int idUser)
    {
        var response = await _client.CreateRequest($"/{idUser}")
            .AddHeader("accept", "application/json")
            .AddAuthorizationHeader(TokenConstant.Token)
            .AddJsonBody(updateUseReq)
            .ExecutePutAsync<UpdateUserDtoRes>();
        return response;
    }
    public RestResponse<DeleteUserDtoRes> DeleteUser(int idUser)
    {
        var response = _client.CreateRequest($"/{idUser}")
            .AddHeader("accept", "application/json")
            .AddAuthorizationHeader(TokenConstant.Token)
            .ExecuteDelete<DeleteUserDtoRes>();
        return response;
    }
    
    
}