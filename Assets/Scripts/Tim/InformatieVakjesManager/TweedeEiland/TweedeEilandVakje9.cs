using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TweedeEilandVakje9 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandNameTweedeEiland;

    // alle vakjes
    public GameObject Vakje9TweedeEiland;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje9TweedeEiland;

    // de buttons die in de vakjes zitten
    public Button ExitVakje9TweedeEiland;
    public Button InformatieTekstVerderTweedeEiland;
    public Button InformatieVideoTerugTweedeEiland;
    public Button InformatieVideoVerderTweedeEiland;
    public Button QuizTerugTweedeEiland;
    public Button QuizAfrondenTweedeEiland;

    // de verschillende soorten informatie per vakje
    public RawImage TextInformatieVakje9TweedeEiland;
    public RawImage VideoInformatieVakje9TweedeEiland;
    public RawImage QuizInformatieVakje9TweedeEiland;

    // Objectfaq GameObject
    public GameObject ObjectfaqTweedeEiland;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje9TweedeEiland.onClick.AddListener(CloseVakje9TweedeEiland);
        InformatieTekstVerderTweedeEiland.onClick.AddListener(ShowVideoInformatieVakje9TweedeEiland);
        InformatieVideoTerugTweedeEiland.onClick.AddListener(ShowTextInformatieVakje9TweedeEiland);
        InformatieVideoVerderTweedeEiland.onClick.AddListener(ShowQuizInformatieVakje9TweedeEiland);
        QuizTerugTweedeEiland.onClick.AddListener(ShowVideoInformatieVakje9TweedeEiland);
        QuizAfrondenTweedeEiland.onClick.AddListener(CloseVakje9TweedeEiland);
        ButtonVakje9TweedeEiland.onClick.AddListener(OpenVakje9TweedeEiland);

        // Initialiseer de vakjes en informatie
        ResetVakjesTweedeEiland();
    }

    void ResetVakjesTweedeEiland()
    {
        Vakje9TweedeEiland.SetActive(false);
        TextInformatieVakje9TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje9TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje9TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void OpenVakje9TweedeEiland()
    {
        Vakje9TweedeEiland.SetActive(true);
        TextInformatieVakje9TweedeEiland.gameObject.SetActive(true);
        VideoInformatieVakje9TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje9TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void CloseVakje9TweedeEiland()
    {
        Vakje9TweedeEiland.SetActive(false);
        TextInformatieVakje9TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje9TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje9TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void ShowVideoInformatieVakje9TweedeEiland()
    {
        TextInformatieVakje9TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje9TweedeEiland.gameObject.SetActive(true);
        QuizInformatieVakje9TweedeEiland.gameObject.SetActive(false);
    }

    void ShowTextInformatieVakje9TweedeEiland()
    {
        TextInformatieVakje9TweedeEiland.gameObject.SetActive(true);
        VideoInformatieVakje9TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje9TweedeEiland.gameObject.SetActive(false);
    }

    void ShowQuizInformatieVakje9TweedeEiland()
    {
        TextInformatieVakje9TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje9TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje9TweedeEiland.gameObject.SetActive(true);
    }

    void UpdateInfoTextVisibilityTweedeEiland()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje9TweedeEiland.activeSelf;
        EilandNameTweedeEiland.gameObject.SetActive(allVakjesClosed);
        ObjectfaqTweedeEiland.gameObject.SetActive(allVakjesClosed);
    }
}





