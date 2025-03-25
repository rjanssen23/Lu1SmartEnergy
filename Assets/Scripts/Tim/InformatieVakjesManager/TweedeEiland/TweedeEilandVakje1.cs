using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TweedeEilandVakje1 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandNameTweedeEiland;

    // alle vakjes
    public GameObject Vakje1TweedeEiland;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje1TweedeEiland;

    // de buttons die in de vakjes zitten
    public Button ExitVakje1TweedeEiland;
    public Button VerderVakje1TweedeEiland;
    public Button TerugVakje1TweedeEiland;
    public Button AfrondenVakje1TweedeEiland;

    // de verschillende soorten informatie per vakje
    public RawImage TextInformatieVakje1TweedeEiland;
    public RawImage VideoInformatieVakje1TweedeEiland;

    // Objectfaq GameObject
    public GameObject ObjectfaqTweedeEiland;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje1TweedeEiland.onClick.AddListener(CloseVakje1TweedeEiland);
        VerderVakje1TweedeEiland.onClick.AddListener(ShowVideoInformatieVakje1TweedeEiland);
        TerugVakje1TweedeEiland.onClick.AddListener(ShowTextInformatieVakje1TweedeEiland);
        AfrondenVakje1TweedeEiland.onClick.AddListener(CloseVakje1TweedeEiland);
        ButtonVakje1TweedeEiland.onClick.AddListener(OpenVakje1TweedeEiland);

        // Initialiseer de vakjes en informatie
        ResetVakjesTweedeEiland();
    }

    void ResetVakjesTweedeEiland()
    {
        Vakje1TweedeEiland.SetActive(false);
        TextInformatieVakje1TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje1TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void OpenVakje1TweedeEiland()
    {
        Vakje1TweedeEiland.SetActive(true);
        TextInformatieVakje1TweedeEiland.gameObject.SetActive(true);
        VideoInformatieVakje1TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void CloseVakje1TweedeEiland()
    {
        Vakje1TweedeEiland.SetActive(false);
        TextInformatieVakje1TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje1TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void ShowVideoInformatieVakje1TweedeEiland()
    {
        TextInformatieVakje1TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje1TweedeEiland.gameObject.SetActive(true);
    }

    void ShowTextInformatieVakje1TweedeEiland()
    {
        TextInformatieVakje1TweedeEiland.gameObject.SetActive(true);
        VideoInformatieVakje1TweedeEiland.gameObject.SetActive(false);
    }

    void UpdateInfoTextVisibilityTweedeEiland()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje1TweedeEiland.activeSelf;
        EilandNameTweedeEiland.gameObject.SetActive(allVakjesClosed);
        ObjectfaqTweedeEiland.gameObject.SetActive(allVakjesClosed);
    }
}



