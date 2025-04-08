using System.Collections.Generic;
using UnityEngine;

public class DagboekApiClient : MonoBehaviour
{
    public WebClient webClient;

    public async Awaitable<IWebRequestReponse> ReadDagboeken(string profielKeuzeId)
    {
        string route = $"/api/dagboeken/profielkeuze/{profielKeuzeId}"; // Use profielKeuzeId in the route
        Debug.Log($"Sending GET request to: {route}");
        IWebRequestReponse webRequestResponse = await webClient.SendGetRequest(route);
        Debug.Log($"Received response: {webRequestResponse}");
        return ParseDagboekListResponse(webRequestResponse);
    }

    public async Awaitable<IWebRequestReponse> CreateDagboek(string profielKeuzeId, Dagboek dagboek)
    {
        string route = $"/api/dagboeken"; // Use the base route for creating a new dagboek
        string data = JsonUtility.ToJson(dagboek);
        Debug.Log($"Sending POST request to: {route} with data: {data}");
        IWebRequestReponse webRequestResponse = await webClient.SendPostRequest(route, data);
        Debug.Log($"Received response: {webRequestResponse}");
        return ParseDagboekResponse(webRequestResponse);
    }

    public async Awaitable<IWebRequestReponse> DeleteDagboek(string dagboekId)
    {
        string route = $"/api/dagboeken/{dagboekId}"; // Use the base route for deleting a dagboek
        Debug.Log($"Sending DELETE request to: {route}");
        return await webClient.SendDeleteRequest(route);
    }

    public async Awaitable<IWebRequestReponse> UpdateDagboek(string dagboekId, Dagboek dagboek)
    {
        string route = $"/api/dagboeken/{dagboekId}"; // Use the base route for updating a dagboek
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

    public async void GetAllDagboekInfo(string profielKeuzeId)
    {
        Debug.LogError("Dagboeken are being loaded");
        IWebRequestReponse response = await ReadDagboeken(profielKeuzeId);
        if (response is WebRequestData<List<Dagboek>> dagboekenData)
        {
            List<Dagboek> dagboeken = dagboekenData.Data;
            foreach (var dagboek in dagboeken)
            {
                Debug.Log($"Dagboekbladzijde1: {dagboek.dagboekBladzijde1}, Dagboekbladzijde2: {dagboek.dagboekBladzijde2}, Dagboekbladzijde3: {dagboek.dagboekBladzijde3}, Dagboekbladzijde4: {dagboek.dagboekBladzijde4}");
            }
        }
        else
        {
            Debug.LogError("Failed to retrieve dagboeken.");
        }
    }
}
