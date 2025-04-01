using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DerdeEilandVakje7 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandNameDerdeEiland;

    // alle vakjes
    public GameObject Vakje7DerdeEiland;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje7DerdeEiland;

    // de buttons die in de vakjes zitten
    public Button ExitVakje7DerdeEiland;
    public Button InformatieTekstVerderDerdeEiland;
    public Button InformatieVideoTerugDerdeEiland;
    public Button InformatieVideoVerderDerdeEiland;
    public Button QuizTerugDerdeEiland;
    public Button QuizAfrondenDerdeEiland;

    // de verschillende soorten informatie per vakje
    public RawImage TextInformatieVakje7DerdeEiland;
    public RawImage VideoInformatieVakje7DerdeEiland;
    public RawImage QuizInformatieVakje7DerdeEiland;

    // Objectfaq GameObject
    public GameObject ObjectfaqDerdeEiland;

    // ProgressieBalk Manager
    public ProgressieBalkEiland3 progressBarManager;

    // Boolean om bij te houden of het vakje al is afgerond
    private bool isVakjeAfgerond = false;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje7DerdeEiland.onClick.AddListener(CloseVakje7DerdeEiland);
        InformatieTekstVerderDerdeEiland.onClick.AddListener(ShowVideoInformatieVakje7DerdeEiland);
        InformatieVideoTerugDerdeEiland.onClick.AddListener(ShowTextInformatieVakje7DerdeEiland);
        InformatieVideoVerderDerdeEiland.onClick.AddListener(ShowQuizInformatieVakje7DerdeEiland);
        QuizTerugDerdeEiland.onClick.AddListener(ShowVideoInformatieVakje7DerdeEiland);
        QuizAfrondenDerdeEiland.onClick.AddListener(CloseVakje7DerdeEiland);
        QuizAfrondenDerdeEiland.onClick.AddListener(AfrondenVakje7);
        ButtonVakje7DerdeEiland.onClick.AddListener(OpenVakje7DerdeEiland);

        // Initialiseer de vakjes en informatie
        ResetVakjesDerdeEiland();
    }

    void ResetVakjesDerdeEiland()
    {
        Vakje7DerdeEiland.SetActive(false);
        TextInformatieVakje7DerdeEiland.gameObject.SetActive(false);
        VideoInformatieVakje7DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje7DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void OpenVakje7DerdeEiland()
    {
        Vakje7DerdeEiland.SetActive(true);
        TextInformatieVakje7DerdeEiland.gameObject.SetActive(true);
        VideoInformatieVakje7DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje7DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void CloseVakje7DerdeEiland()
    {
        Vakje7DerdeEiland.SetActive(false);
        TextInformatieVakje7DerdeEiland.gameObject.SetActive(false);
        VideoInformatieVakje7DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje7DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void ShowVideoInformatieVakje7DerdeEiland()
    {
        TextInformatieVakje7DerdeEiland.gameObject.SetActive(false);
        VideoInformatieVakje7DerdeEiland.gameObject.SetActive(true);
        QuizInformatieVakje7DerdeEiland.gameObject.SetActive(false);
    }

    void ShowTextInformatieVakje7DerdeEiland()
    {
        TextInformatieVakje7DerdeEiland.gameObject.SetActive(true);
        VideoInformatieVakje7DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje7DerdeEiland.gameObject.SetActive(false);
    }

    void ShowQuizInformatieVakje7DerdeEiland()
    {
        TextInformatieVakje7DerdeEiland.gameObject.SetActive(false);
        VideoInformatieVakje7DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje7DerdeEiland.gameObject.SetActive(true);
    }

    void AfrondenVakje7()
    {
        if (!isVakjeAfgerond)
        {
            isVakjeAfgerond = true;
            progressBarManager.VakjeAfronden(6); // 6 is de index voor Vakje7
        }
    }

    void UpdateInfoTextVisibilityDerdeEiland()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje7DerdeEiland.activeSelf;
        EilandNameDerdeEiland.gameObject.SetActive(allVakjesClosed);
        ObjectfaqDerdeEiland.gameObject.SetActive(allVakjesClosed);
    }
}






