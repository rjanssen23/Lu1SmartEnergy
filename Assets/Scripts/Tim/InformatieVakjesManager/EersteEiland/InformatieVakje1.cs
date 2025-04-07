using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

public class InformatieVakje1 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandName;

    // alle vakjes
    public GameObject Vakje1;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje1;

    // de buttons die in de vakjes zitten
    public Button ExitVakje1;
    public Button VerderVakje1;
    public Button TerugVakje1;
    public Button AfrondenVakje1;

    // de verschillende soorten informatie per vakje
    public RawImage TextInformatieVakje1;
    public RawImage VideoInformatieVakje1;

    // Objectfaq GameObject
    public GameObject Objectfaq;

    // ProgressieBalk Manager
    public ProgressBarManager progressBarManager;

    // Boolean om bij te houden of het vakje al is afgerond
    private bool isVakjeAfgerond = false;

    // Progressie1ApiClient
    public Progressie1ApiClient progressie1ApiClient;

    // Profielkeuze ID
    public string profielKeuzeId;

    // Progressie1 ID
    private string progressie1Id;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje1.onClick.AddListener(CloseVakje1);
        VerderVakje1.onClick.AddListener(ShowVideoInformatieVakje1);
        TerugVakje1.onClick.AddListener(ShowTextInformatieVakje1);
        AfrondenVakje1.onClick.AddListener(CloseVakje1);
        AfrondenVakje1.onClick.AddListener(AfrondenVakje1Handler);
        ButtonVakje1.onClick.AddListener(OpenVakje1);

        // Initialiseer de vakjes en informatie
        ResetVakjes();
    }

    public void SetProfielKeuzeId(string id)
    {
        profielKeuzeId = id;
    }

    public void SetProgressie1Id(string id)
    {
        progressie1Id = id;
    }

    void ResetVakjes()
    {
        Vakje1.SetActive(false);
        TextInformatieVakje1.gameObject.SetActive(false);
        VideoInformatieVakje1.gameObject.SetActive(false);
        UpdateInfoTextVisibility();
    }

    void OpenVakje1()
    {
        Vakje1.SetActive(true);
        TextInformatieVakje1.gameObject.SetActive(true);
        VideoInformatieVakje1.gameObject.SetActive(false);
        UpdateInfoTextVisibility();
    }

    void CloseVakje1()
    {
        Vakje1.SetActive(false);
        TextInformatieVakje1.gameObject.SetActive(false);
        VideoInformatieVakje1.gameObject.SetActive(false);
        UpdateInfoTextVisibility();
    }

    void ShowVideoInformatieVakje1()
    {
        TextInformatieVakje1.gameObject.SetActive(false);
        VideoInformatieVakje1.gameObject.SetActive(true);
    }

    void ShowTextInformatieVakje1()
    {
        TextInformatieVakje1.gameObject.SetActive(true);
        VideoInformatieVakje1.gameObject.SetActive(false);
    }

    async void AfrondenVakje1Handler()
    {
        if (!isVakjeAfgerond)
        {
            isVakjeAfgerond = true;
            progressBarManager.VakjeAfronden(0); // 0 is de index voor Vakje1

            // Update vakje1 status in the database
            Progressie1 progressie = new Progressie1
            {
                id = progressie1Id,
                vakje1 = true,
                profielKeuzeId = profielKeuzeId
            };

            IWebRequestReponse updateResponse = await progressie1ApiClient.UpdateProgressie(progressie1Id, progressie);

            if (updateResponse is WebRequestError errorResponse)
            {
                Debug.LogError("Failed to update vakje1 status: " + errorResponse.ErrorMessage);
            }
            else
            {
                Debug.Log("Vakje1 status updated successfully.");
            }
        }
    }

    void UpdateInfoTextVisibility()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje1.activeSelf;
        EilandName.gameObject.SetActive(allVakjesClosed);
        Objectfaq.SetActive(allVakjesClosed);
    }
}









