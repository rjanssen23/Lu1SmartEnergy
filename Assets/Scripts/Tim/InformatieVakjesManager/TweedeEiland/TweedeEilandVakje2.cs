using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TweedeEilandVakje2 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandNameTweedeEiland;

    // alle vakjes
    public GameObject Vakje2TweedeEiland;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje2TweedeEiland;

    // de buttons die in de vakjes zitten
    public Button ExitVakje2TweedeEiland;
    public Button InformatieTekstVerderTweedeEiland;
    public Button InformatieVideoTerugTweedeEiland;
    public Button InformatieVideoVerderTweedeEiland;
    public Button QuizTerugTweedeEiland;
    public Button QuizAfrondenTweedeEiland;

    // de verschillende soorten informatie per vakje
    public RawImage TextInformatieVakje2TweedeEiland;
    public RawImage VideoInformatieVakje2TweedeEiland;
    public RawImage QuizInformatieVakje2TweedeEiland;

    // Objectfaq GameObject
    public GameObject ObjectfaqTweedeEiland;

    // ProgressieBalk Manager
    public ProgressieBalkEiland2 progressBarManager;

    // Boolean om bij te houden of het vakje al is afgerond
    private bool isVakjeAfgerond = false;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje2TweedeEiland.onClick.AddListener(CloseVakje2TweedeEiland);
        InformatieTekstVerderTweedeEiland.onClick.AddListener(ShowVideoInformatieVakje2TweedeEiland);
        InformatieVideoTerugTweedeEiland.onClick.AddListener(ShowTextInformatieVakje2TweedeEiland);
        InformatieVideoVerderTweedeEiland.onClick.AddListener(ShowQuizInformatieVakje2TweedeEiland);
        QuizTerugTweedeEiland.onClick.AddListener(ShowVideoInformatieVakje2TweedeEiland);
        QuizAfrondenTweedeEiland.onClick.AddListener(CloseVakje2TweedeEiland);
        QuizAfrondenTweedeEiland.onClick.AddListener(AfrondenVakje2);
        ButtonVakje2TweedeEiland.onClick.AddListener(OpenVakje2TweedeEiland);

        // Initialiseer de vakjes en informatie
        ResetVakjesTweedeEiland();
    }

    void ResetVakjesTweedeEiland()
    {
        Vakje2TweedeEiland.SetActive(false);
        TextInformatieVakje2TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje2TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje2TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void OpenVakje2TweedeEiland()
    {
        Vakje2TweedeEiland.SetActive(true);
        TextInformatieVakje2TweedeEiland.gameObject.SetActive(true);
        VideoInformatieVakje2TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje2TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void CloseVakje2TweedeEiland()
    {
        Vakje2TweedeEiland.SetActive(false);
        TextInformatieVakje2TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje2TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje2TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void ShowVideoInformatieVakje2TweedeEiland()
    {
        TextInformatieVakje2TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje2TweedeEiland.gameObject.SetActive(true);
        QuizInformatieVakje2TweedeEiland.gameObject.SetActive(false);
    }

    void ShowTextInformatieVakje2TweedeEiland()
    {
        TextInformatieVakje2TweedeEiland.gameObject.SetActive(true);
        VideoInformatieVakje2TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje2TweedeEiland.gameObject.SetActive(false);
    }

    void ShowQuizInformatieVakje2TweedeEiland()
    {
        TextInformatieVakje2TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje2TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje2TweedeEiland.gameObject.SetActive(true);
    }

    void AfrondenVakje2()
    {
        if (!isVakjeAfgerond)
        {
            isVakjeAfgerond = true;
            progressBarManager.VakjeAfronden(1); // 1 is de index voor Vakje2
        }
    }

    void UpdateInfoTextVisibilityTweedeEiland()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje2TweedeEiland.activeSelf;
        EilandNameTweedeEiland.gameObject.SetActive(allVakjesClosed);
        ObjectfaqTweedeEiland.gameObject.SetActive(allVakjesClosed);
    }
}




