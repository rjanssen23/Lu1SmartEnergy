using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DerdeEilandVakje1 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandNameDerdeEiland;

    // alle vakjes
    public GameObject Vakje1DerdeEiland;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje1DerdeEiland;

    // de buttons die in de vakjes zitten
    public Button ExitVakje1DerdeEiland;
    public Button VerderVakje1DerdeEiland;
    public Button TerugVakje1DerdeEiland;
    public Button AfrondenVakje1DerdeEiland;

    // de verschillende soorten informatie per vakje
    public RawImage TextInformatieVakje1DerdeEiland;
    public RawImage VideoInformatieVakje1DerdeEiland;

    // Objectfaq GameObject
    public GameObject ObjectfaqDerdeEiland;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje1DerdeEiland.onClick.AddListener(CloseVakje1DerdeEiland);
        VerderVakje1DerdeEiland.onClick.AddListener(ShowVideoInformatieVakje1DerdeEiland);
        TerugVakje1DerdeEiland.onClick.AddListener(ShowTextInformatieVakje1DerdeEiland);
        AfrondenVakje1DerdeEiland.onClick.AddListener(CloseVakje1DerdeEiland);
        ButtonVakje1DerdeEiland.onClick.AddListener(OpenVakje1DerdeEiland);

        // Initialiseer de vakjes en informatie
        ResetVakjesDerdeEiland();
    }

    void ResetVakjesDerdeEiland()
    {
        Vakje1DerdeEiland.SetActive(false);
        TextInformatieVakje1DerdeEiland.gameObject.SetActive(false);
        VideoInformatieVakje1DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void OpenVakje1DerdeEiland()
    {
        Vakje1DerdeEiland.SetActive(true);
        TextInformatieVakje1DerdeEiland.gameObject.SetActive(true);
        VideoInformatieVakje1DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void CloseVakje1DerdeEiland()
    {
        Vakje1DerdeEiland.SetActive(false);
        TextInformatieVakje1DerdeEiland.gameObject.SetActive(false);
        VideoInformatieVakje1DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void ShowVideoInformatieVakje1DerdeEiland()
    {
        TextInformatieVakje1DerdeEiland.gameObject.SetActive(false);
        VideoInformatieVakje1DerdeEiland.gameObject.SetActive(true);
    }

    void ShowTextInformatieVakje1DerdeEiland()
    {
        TextInformatieVakje1DerdeEiland.gameObject.SetActive(true);
        VideoInformatieVakje1DerdeEiland.gameObject.SetActive(false);
    }

    void UpdateInfoTextVisibilityDerdeEiland()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje1DerdeEiland.activeSelf;
        EilandNameDerdeEiland.gameObject.SetActive(allVakjesClosed);
        ObjectfaqDerdeEiland.gameObject.SetActive(allVakjesClosed);
    }
}




