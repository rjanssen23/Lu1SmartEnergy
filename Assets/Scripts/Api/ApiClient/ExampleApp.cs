using System;
using System.Collections.Generic;
using UnityEngine;

public class ExampleApp : MonoBehaviour
{
    [Header("Test data")]
    public User user;
    public ProfielKeuze profielKeuze;
    public Progressie1 progressie1;

    [Header("Dependencies")]
    public UserApiClient userApiClient;
    public ProfielkeuzeApiClient profielkeuzeApiClient;
    public Progressie1ApiClient progressie1ApiClient;

    #region Login

    [ContextMenu("User/Register")]
    public async void Register()
    {
        IWebRequestReponse webRequestResponse = await userApiClient.Register(user);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                Debug.Log("Register succes!");
                // TODO: Handle succes scenario;
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Register error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("User/Login")]
    public async void Login()
    {
        IWebRequestReponse webRequestResponse = await userApiClient.Login(user);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                Debug.Log("Login succes!");
                // TODO: Todo handle succes scenario.
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Login error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    #endregion

    #region ProfielKeuze

    [ContextMenu("ProfielKeuze/Read all")]
    public async void ReadProfielKeuzes()
    {
        IWebRequestReponse webRequestResponse = await profielkeuzeApiClient.ReadProfielKeuzes();

        switch (webRequestResponse)
        {
            case WebRequestData<List<ProfielKeuze>> dataResponse:
                List<ProfielKeuze> profielKeuzes = dataResponse.Data;
                Debug.Log("List of profielKeuzes: ");
                profielKeuzes.ForEach(pk => Debug.Log(pk.name));
                // TODO: Handle succes scenario.
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Read profielKeuzes error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("ProfielKeuze/Create")]
    public async void CreateProfielKeuze()
    {
        IWebRequestReponse webRequestResponse = await profielkeuzeApiClient.CreateProfielKeuze(profielKeuze);

        switch (webRequestResponse)
        {
            case WebRequestData<ProfielKeuze> dataResponse:
                profielKeuze.id = dataResponse.Data.id;
                Debug.Log("ProfielKeuze created with ID: " + profielKeuze.id);
                // TODO: Handle succes scenario.
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Create profielKeuze error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("ProfielKeuze/Delete")]
    public async void DeleteProfielKeuze()
    {
        IWebRequestReponse webRequestResponse = await profielkeuzeApiClient.DeleteProfielKeuze(profielKeuze.id);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                string responseData = dataResponse.Data;
                Debug.Log("ProfielKeuze deleted: " + responseData);
                // TODO: Handle succes scenario.
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Delete profielKeuze error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    #endregion ProfielKeuze

    #region Progressie1

    [ContextMenu("Progressie1/Read all")]
    public async void ReadProgressies()
    {
        IWebRequestReponse webRequestResponse = await progressie1ApiClient.ReadProgressies();

        switch (webRequestResponse)
        {
            case WebRequestData<List<Progressie1>> dataResponse:
                List<Progressie1> progressies = dataResponse.Data;
                Debug.Log("List of progressies: ");
                progressies.ForEach(p => Debug.Log(p.id));
                // TODO: Handle succes scenario.
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Read progressies error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("Progressie1/Create")]
    public async void CreateProgressie()
    {
        IWebRequestReponse webRequestResponse = await progressie1ApiClient.CreateProgressie(progressie1);

        switch (webRequestResponse)
        {
            case WebRequestData<Progressie1> dataResponse:
                progressie1.id = dataResponse.Data.id;
                Debug.Log("Progressie1 created with ID: " + progressie1.id);
                // TODO: Handle succes scenario.
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Create progressie1 error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("Progressie1/Delete")]
    public async void DeleteProgressie()
    {
        IWebRequestReponse webRequestResponse = await progressie1ApiClient.DeleteProgressie(progressie1.id);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                string responseData = dataResponse.Data;
                Debug.Log("Progressie1 deleted: " + responseData);
                // TODO: Handle succes scenario.
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Delete progressie1 error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    #endregion Progressie1
}
