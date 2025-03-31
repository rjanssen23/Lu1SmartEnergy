using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DerdeEilandVakje8 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandNameDerdeEiland;

    // alle vakjes
    public GameObject Vakje8DerdeEiland;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje8DerdeEiland;

    // de buttons die in de vakjes zitten
    public Button ExitVakje8DerdeEiland;
    public Button InformatieTekstVerderDerdeEiland;
    public Button InformatieVideoTerugDerdeEiland;
    public Button InformatieVideoVerderDerdeEiland;
    public Button QuizTerugDerdeEiland;
    public Button QuizAfrondenDerdeEiland;

    // de verschillende soorten informatie per vakje
    public RawImage TextInformatieVakje8DerdeEiland;
    public RawImage VideoInformatieVakje8DerdeEiland;
    public RawImage QuizInformatieVakje8DerdeEiland;

    // Objectfaq GameObject
    public GameObject ObjectfaqDerdeEiland;

    // ProgressieBalk Manager
    public ProgressieBalkEiland3 progressBarManager;

    // Boolean om bij te houden of het vakje al is afgerond
    private bool isVakjeAfgerond = false;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje8DerdeEiland.onClick.AddListener(CloseVakje8DerdeEiland);
        InformatieTekstVerderDerdeEiland.onClick.AddListener(ShowVideoInformatieVakje8DerdeEiland);
        InformatieVideoTerugDerdeEiland.onClick.AddListener(ShowTextInformatieVakje8DerdeEiland);
        InformatieVideoVerderDerdeEiland.onClick.AddListener(ShowQuizInformatieVakje8DerdeEiland);
        QuizTerugDerdeEiland.onClick.AddListener(ShowVideoInformatieVakje8DerdeEiland);
        QuizAfrondenDerdeEiland.onClick.AddListener(CloseVakje8DerdeEiland);
        QuizAfrondenDerdeEiland.onClick.AddListener(AfrondenVakje8);
        ButtonVakje8DerdeEiland.onClick.AddListener(OpenVakje8DerdeEiland);

        // Initialiseer de vakjes en informatie
        ResetVakjesDerdeEiland();
    }

    void ResetVakjesDerdeEiland()
    {
        Vakje8DerdeEiland.SetActive(false);
        TextInformatieVakje8DerdeEiland.gameObject.SetActive(false);
        VideoInformatieVakje8DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje8DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void OpenVakje8DerdeEiland()
    {
        Vakje8DerdeEiland.SetActive(true);
        TextInformatieVakje8DerdeEiland.gameObject.SetActive(true);
        VideoInformatieVakje8DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje8DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void CloseVakje8DerdeEiland()
    {
        Vakje8DerdeEiland.SetActive(false);
        TextInformatieVakje8DerdeEiland.gameObject.SetActive(false);
        VideoInformatieVakje8DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje8DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void ShowVideoInformatieVakje8DerdeEiland()
    {
        TextInformatieVakje8DerdeEiland.gameObject.SetActive(false);
        VideoInformatieVakje8DerdeEiland.gameObject.SetActive(true);
        QuizInformatieVakje8DerdeEiland.gameObject.SetActive(false);
    }

    void ShowTextInformatieVakje8DerdeEiland()
    {
        TextInformatieVakje8DerdeEiland.gameObject.SetActive(true);
        VideoInformatieVakje8DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje8DerdeEiland.gameObject.SetActive(false);
    }

    void ShowQuizInformatieVakje8DerdeEiland()
    {
        TextInformatieVakje8DerdeEiland.gameObject.SetActive(false);
        VideoInformatieVakje8DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje8DerdeEiland.gameObject.SetActive(true);
    }

    void AfrondenVakje8()
    {
        if (!isVakjeAfgerond)
        {
            isVakjeAfgerond = true;
            progressBarManager.VakjeAfronden(7); // 7 is de index voor Vakje8
        }
    }

    void UpdateInfoTextVisibilityDerdeEiland()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje8DerdeEiland.activeSelf;
        EilandNameDerdeEiland.gameObject.SetActive(allVakjesClosed);
        ObjectfaqDerdeEiland.gameObject.SetActive(allVakjesClosed);
    }
}
