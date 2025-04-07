using System.Collections.Generic;
using UnityEngine;

public class DagboekApiClient : MonoBehaviour
{
    public WebClient webClient;

    public async Awaitable<IWebRequestReponse> ReadDagboeken(string profielkeuzeid)
    {
        string route = $"/api/dagboek/profielkeuze/{profielkeuzeid}"; // Use profielkeuzeid in the route
        Debug.Log($"Sending GET request to: {route}");
        IWebRequestReponse webRequestResponse = await webClient.SendGetRequest(route);
        Debug.Log($"Received response: {webRequestResponse}");
        return ParseDagboekListResponse(webRequestResponse);
    }

    public async Awaitable<IWebRequestReponse> CreateDagboek(string profielkeuzeid, Dagboek dagboek)
    {
        string route = $"/api/dagboek"; // Use the base route for creating a new dagboek
        string data = JsonUtility.ToJson(dagboek);
        Debug.Log($"Sending POST request to: {route} with data: {data}");
        IWebRequestReponse webRequestResponse = await webClient.SendPostRequest(route, data);
        Debug.Log($"Received response: {webRequestResponse}");
        return ParseDagboekResponse(webRequestResponse);
    }

    public async Awaitable<IWebRequestReponse> DeleteDagboek(string profielkeuzeid, string dagboekId)
    {
        string route = $"/api/dagboek/{dagboekId}"; // Use the base route for deleting a dagboek
        Debug.Log($"Sending DELETE request to: {route}");
        return await webClient.SendDeleteRequest(route);
    }

    public async Awaitable<IWebRequestReponse> UpdateDagboek(string profielkeuzeid, string dagboekId, Dagboek dagboek)
    {
        string route = $"/api/dagboek/{dagboekId}"; // Use the base route for updating a dagboek
        string data = JsonUtility.ToJson(dagboek);
        Debug.Log($"Sending PUT request to: {route} with data: {data}");
        IWebRequestReponse webRequestResponse = await webClient.SendPutRequest(route, data); // Use SendPutRequest instead of SendPostRequest
        Debug.Log($"Received response: {webRequestResponse}");
        return ParseDagboekResponse(webRequestResponse);
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

    public async void GetAllDagboekInfo(string profielkeuzeid)
    {
        Debug.LogError("Dagboeken are being loaded");
        IWebRequestReponse response = await ReadDagboeken(profielkeuzeid);
        if (response is WebRequestData<List<Dagboek>> dagboekenData)
        {
            List<Dagboek> dagboeken = dagboekenData.Data;
            foreach (var dagboek in dagboeken)
            {
                Debug.Log($"Dagboekbladzijde1: {dagboek.Dagboekbladzijde1}, Dagboekbladzijde2: {dagboek.Dagboekbladzijde2}, Dagboekbladzijde3: {dagboek.Dagboekbladzijde3}, Dagboekbladzijde4: {dagboek.Dagboekbladzijde4}");
            }
        }
        else
        {
            Debug.LogError("Failed to retrieve dagboeken.");
        }
    }
}
