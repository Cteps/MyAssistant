using MAlib.Services;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ApiService
{
    private readonly RestClient _client;

    public ApiService()
    {
        _client = new RestClient("https://localhost:5238");
    }

    public async Task<ApiResponse<T>> GetDataAsync<T>(string endpoint)
    {
        var request = new RestRequest(endpoint, Method.Get);
        var response = await _client.ExecuteAsync<ApiResponse<T>>(request);

        if (response.IsSuccessful)
        {
            return response.Data; 
        }
        else
        {
            throw new Exception($"Erro ao chamar API: {response.ErrorMessage}");
        }
    }


    public async Task<ApiResponse<T>> PostDataAsync<T>(string endpoint, object data)
    {
        var request = new RestRequest(endpoint, Method.Post);
        request.AddJsonBody(data);
        var response = await _client.ExecuteAsync<ApiResponse<T>>(request);

        if (response.IsSuccessful)
        {
            return response.Data;
        }
        else
        {
            throw new Exception("Erro ao chamar API: " + response.ErrorMessage);
        }
    }
}
