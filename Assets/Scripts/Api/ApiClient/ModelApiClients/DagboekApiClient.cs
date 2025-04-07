using System;
using System.Collections.Generic;
using UnityEngine;

public class DagboekApiClient : MonoBehaviour
{
    public WebClient webClient;

    [Serializable]
    public class Dagboek
    {
        public string id;
        public string profielId;
        public string pagina1;
        public string pagina2;
        public string pagina3;
        public string pagina4;
    }
    public async Awaitable<IWebRequestReponse> ReadDagboeken()
    {
        string route = "/api/dagboek";
        IWebRequestReponse webRequestResponse = await webClient.SendGetRequest(route);
        return ParseDagboekListResponse(webRequestResponse);
    }

    public async Awaitable<IWebRequestReponse> CreateDagboek(Dagboek dagboek)
    {
        string route = "/api/dagboek";
        string data = JsonUtility.ToJson(dagboek);
        IWebRequestReponse webRequestResponse = await webClient.SendPostRequest(route, data);
        return ParseDagboekResponse(webRequestResponse);
    }

    public async Awaitable<IWebRequestReponse> DeleteDagboek(string dagboekId)
    {
        string route = "/api/dagboek/" + dagboekId;
        return await webClient.SendDeleteRequest(route);
    }

    private IWebRequestReponse ParseDagboekResponse(IWebRequestReponse webRequestResponse)
    {
        switch (webRequestResponse)
        {
            case WebRequestData<string> data:
                Debug.Log("Response data raw: " + data.Data);
                Dagboek dagboek = JsonUtility.FromJson<Dagboek>(data.Data);
                WebRequestData<Dagboek> parsedWebRequestData = new WebRequestData<Dagboek>(dagboek);
                return parsedWebRequestData;
            default:
                return webRequestResponse;
        }
    }

    private IWebRequestReponse ParseDagboekListResponse(IWebRequestReponse webRequestResponse)
    {
        switch (webRequestResponse)
        {
            case WebRequestData<string> data:
                Debug.Log("Response data raw: " + data.Data);
                List<Dagboek> dagboeken = JsonHelper.ParseJsonArray<Dagboek>(data.Data);
                WebRequestData<List<Dagboek>> parsedWebRequestData = new WebRequestData<List<Dagboek>>(dagboeken);
                return parsedWebRequestData;
            default:
                return webRequestResponse;
        }
    }

    public async void GetAllDagboekInfo()
    {
        Debug.LogError("Dagboeken worden geladen");
        IWebRequestReponse response = await ReadDagboeken();
        if (response is WebRequestData<List<Dagboek>> dagboekenData)
        {
            List<Dagboek> dagboeken = dagboekenData.Data;
            foreach (var dagboek in dagboeken)
            {
                Debug.Log($"Pagina1: {dagboek.pagina1}, Pagina2: {dagboek.pagina2}, Pagina3: {dagboek.pagina3}, Pagina4: {dagboek.pagina4}");
            }
        }
        else
        {
            Debug.LogError("Dagboeken ophalen mislukt.");
        }
    }
}

