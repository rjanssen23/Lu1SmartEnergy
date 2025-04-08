using System;
using System.Collections.Generic;
using UnityEngine;

public class Progressie1ApiClient : MonoBehaviour
{
    public WebClient webClient;

    public async Awaitable<IWebRequestReponse> ReadProgressies()
    {
        string route = "/api/progressie1"; // Correct route
        IWebRequestReponse webRequestResponse = await webClient.SendGetRequest(route);
        return ParseProgressieListResponse(webRequestResponse);
    }


    public async Awaitable<IWebRequestReponse> CreateProgressie(Progressie1 progressie)
    {
        string route = "/api/progressie1"; // Correct route
        string data = JsonUtility.ToJson(progressie);
        IWebRequestReponse webRequestResponse = await webClient.SendPostRequest(route, data);
        return ParseProgressieResponse(webRequestResponse);
    }

    public async Awaitable<IWebRequestReponse> DeleteProgressie(string progressieId)
    {
        string route = "/api/progressie1/" + progressieId; // Correct route
        return await webClient.SendDeleteRequest(route);
    }

    public async Awaitable<IWebRequestReponse> UpdateProgressiePut(string progressieId, Progressie1 progressie)
    {
        string route = "/api/progressie1/" + progressieId; // Correct route
        string data = JsonUtility.ToJson(progressie);
        IWebRequestReponse webRequestResponse = await webClient.SendPutRequest(route, data);
        return ParseProgressieResponse(webRequestResponse);
    }

    private IWebRequestReponse ParseProgressieResponse(IWebRequestReponse webRequestResponse)
    {
        switch (webRequestResponse)
        {
            case WebRequestData<string> data:
                Debug.Log("Response data raw: " + data.Data);
                Progressie1 progressie = JsonUtility.FromJson<Progressie1>(data.Data);
                WebRequestData<Progressie1> parsedWebRequestData = new WebRequestData<Progressie1>(progressie);
                return parsedWebRequestData;
            default:
                return webRequestResponse;
        }
    }

    private IWebRequestReponse ParseProgressieListResponse(IWebRequestReponse webRequestResponse)
    {
        switch (webRequestResponse)
        {
            case WebRequestData<string> data:
                Debug.Log("Response data raw: " + data.Data);
                List<Progressie1> progressies = JsonHelper.ParseJsonArray<Progressie1>(data.Data);
                WebRequestData<List<Progressie1>> parsedWebRequestData = new WebRequestData<List<Progressie1>>(progressies);
                return parsedWebRequestData;
            default:
                return webRequestResponse;
        }
    }

    public async void GetAllProgressieInfo()
    {
        Debug.LogError("Progressies are being loaded");
        IWebRequestReponse response = await ReadProgressies();
        if (response is WebRequestData<List<Progressie1>> progressiesData)
        {
            List<Progressie1> progressies = progressiesData.Data;
            foreach (var progressie in progressies)
            {
                Debug.Log($"ID: {progressie.id}, NumberCompleet: {progressie.numberCompleet}, Vakje1: {progressie.vakje1}, Vakje2: {progressie.vakje2}, Vakje3: {progressie.vakje3}, Vakje4: {progressie.vakje4}, Vakje5: {progressie.vakje5}, Vakje6: {progressie.vakje6}");
            }
        }
        else
        {
            Debug.LogError("Failed to retrieve progressies.");
        }
    }

}


