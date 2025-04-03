using System;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ProfielkeuzeApiClient : MonoBehaviour
{
    public WebClient webClient;

    public async Awaitable<IWebRequestReponse> ReadProfielKeuzes()
    {
        string route = "/profielkeuzes";

        IWebRequestReponse webRequestResponse = await webClient.SendGetRequest(route);
        return ParseProfielKeuzeListResponse(webRequestResponse);
    }

    public async Awaitable<IWebRequestReponse> CreateProfielKeuze(ProfielKeuze profielKeuze)
    {
        string route = "/profielkeuzes";
        string data = JsonUtility.ToJson(profielKeuze);

        IWebRequestReponse webRequestResponse = await webClient.SendPostRequest(route, data);
        return ParseProfielKeuzeResponse(webRequestResponse);
    }

    public async Awaitable<IWebRequestReponse> DeleteProfielKeuze(string profielKeuzeId)
    {
        string route = "/profielkeuzes/" + profielKeuzeId;
        return await webClient.SendDeleteRequest(route);
    }

    private IWebRequestReponse ParseProfielKeuzeResponse(IWebRequestReponse webRequestResponse)
    {
        switch (webRequestResponse)
        {
            case WebRequestData<string> data:
                Debug.Log("Response data raw: " + data.Data);
                ProfielKeuze profielKeuze = JsonUtility.FromJson<ProfielKeuze>(data.Data);
                WebRequestData<ProfielKeuze> parsedWebRequestData = new WebRequestData<ProfielKeuze>(profielKeuze);
                return parsedWebRequestData;
            default:
                return webRequestResponse;
        }
    }

    private IWebRequestReponse ParseProfielKeuzeListResponse(IWebRequestReponse webRequestResponse)
    {
        switch (webRequestResponse)
        {
            case WebRequestData<string> data:
                Debug.Log("Response data raw: " + data.Data);
                List<ProfielKeuze> profielKeuzes = JsonHelper.ParseJsonArray<ProfielKeuze>(data.Data);
                WebRequestData<List<ProfielKeuze>> parsedWebRequestData = new WebRequestData<List<ProfielKeuze>>(profielKeuzes);
                return parsedWebRequestData;
            default:
                return webRequestResponse;
        }
    }
}


