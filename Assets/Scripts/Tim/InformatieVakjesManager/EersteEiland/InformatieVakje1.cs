using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformatieVakjesManager : MonoBehaviour
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

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje1.onClick.AddListener(CloseVakje1);
        VerderVakje1.onClick.AddListener(ShowVideoInformatieVakje1);
        TerugVakje1.onClick.AddListener(ShowTextInformatieVakje1);
        AfrondenVakje1.onClick.AddListener(CloseVakje1);
        ButtonVakje1.onClick.AddListener(OpenVakje1);

        // Initialiseer de vakjes en informatie
        ResetVakjes();
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

    void UpdateInfoTextVisibility()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje1.activeSelf;
        EilandName.gameObject.SetActive(allVakjesClosed);
        Objectfaq.SetActive(allVakjesClosed);
    }
}

