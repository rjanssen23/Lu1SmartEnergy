using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TweedeEilandVakje3 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandNameTweedeEiland;

    // alle vakjes
    public GameObject Vakje3TweedeEiland;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje3TweedeEiland;

    // de buttons die in de vakjes zitten
    public Button ExitVakje3TweedeEiland;
    public Button InformatieTekstVerderTweedeEiland;
    public Button InformatieVideoTerugTweedeEiland;
    public Button InformatieVideoVerderTweedeEiland;
    public Button QuizTerugTweedeEiland;
    public Button QuizAfrondenTweedeEiland;

    // de verschillende soorten informatie per vakje
    public RawImage TextInformatieVakje3TweedeEiland;
    public RawImage VideoInformatieVakje3TweedeEiland;
    public RawImage QuizInformatieVakje3TweedeEiland;

    // Objectfaq GameObject
    public GameObject ObjectfaqTweedeEiland;

    // ProgressieBalk Manager
    public ProgressieBalkEiland2 progressBarManager;

    // Boolean om bij te houden of het vakje al is afgerond
    private bool isVakjeAfgerond = false;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje3TweedeEiland.onClick.AddListener(CloseVakje3TweedeEiland);
        InformatieTekstVerderTweedeEiland.onClick.AddListener(ShowVideoInformatieVakje3TweedeEiland);
        InformatieVideoTerugTweedeEiland.onClick.AddListener(ShowTextInformatieVakje3TweedeEiland);
        InformatieVideoVerderTweedeEiland.onClick.AddListener(ShowQuizInformatieVakje3TweedeEiland);
        QuizTerugTweedeEiland.onClick.AddListener(ShowVideoInformatieVakje3TweedeEiland);
        QuizAfrondenTweedeEiland.onClick.AddListener(CloseVakje3TweedeEiland);
        QuizAfrondenTweedeEiland.onClick.AddListener(AfrondenVakje3);
        ButtonVakje3TweedeEiland.onClick.AddListener(OpenVakje3TweedeEiland);

        // Initialiseer de vakjes en informatie
        ResetVakjesTweedeEiland();
    }

    void ResetVakjesTweedeEiland()
    {
        Vakje3TweedeEiland.SetActive(false);
        TextInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void OpenVakje3TweedeEiland()
    {
        Vakje3TweedeEiland.SetActive(true);
        TextInformatieVakje3TweedeEiland.gameObject.SetActive(true);
        VideoInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void CloseVakje3TweedeEiland()
    {
        Vakje3TweedeEiland.SetActive(false);
        TextInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void ShowVideoInformatieVakje3TweedeEiland()
    {
        TextInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje3TweedeEiland.gameObject.SetActive(true);
        QuizInformatieVakje3TweedeEiland.gameObject.SetActive(false);
    }

    void ShowTextInformatieVakje3TweedeEiland()
    {
        TextInformatieVakje3TweedeEiland.gameObject.SetActive(true);
        VideoInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje3TweedeEiland.gameObject.SetActive(false);
    }

    void ShowQuizInformatieVakje3TweedeEiland()
    {
        TextInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje3TweedeEiland.gameObject.SetActive(true);
    }

    void AfrondenVakje3()
    {
        if (!isVakjeAfgerond)
        {
            isVakjeAfgerond = true;
            progressBarManager.VakjeAfronden(2); // 2 is de index voor Vakje3
        }
    }

    void UpdateInfoTextVisibilityTweedeEiland()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje3TweedeEiland.activeSelf;
        EilandNameTweedeEiland.gameObject.SetActive(allVakjesClosed);
        ObjectfaqTweedeEiland.gameObject.SetActive(allVakjesClosed);
    }
}


