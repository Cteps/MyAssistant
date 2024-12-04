using MAlib.Entity.Models._Obj;
using MAlib.Services;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ObjService
{
    private readonly ApiService _client;
    private string _baseEndPoint = "api/Obj";
    public ObjService()
    {
        _client = new ApiService();
    }

    public async Task<List<ObjEsp>> GetObjEspAsync()
    {
        try
        {
            var response = await _client.GetDataAsync<List<ObjEsp>>($"{_baseEndPoint}/Geral");

            return response.Data;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Erro ao obter objetos gerais da API.", ex);
        }
    }
}


