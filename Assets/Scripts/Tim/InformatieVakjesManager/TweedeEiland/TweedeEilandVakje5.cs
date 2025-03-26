using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TweedeEilandVakje5 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandNameTweedeEiland;

    // alle vakjes
    public GameObject Vakje5TweedeEiland;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje5TweedeEiland;

    // de buttons die in de vakjes zitten
    public Button ExitVakje5TweedeEiland;
    public Button InformatieTekstVerderTweedeEiland;
    public Button InformatieVideoTerugTweedeEiland;
    public Button InformatieVideoVerderTweedeEiland;
    public Button QuizTerugTweedeEiland;
    public Button QuizAfrondenTweedeEiland;

    // de verschillende soorten informatie per vakje
    public RawImage TextInformatieVakje5TweedeEiland;
    public RawImage VideoInformatieVakje5TweedeEiland;
    public RawImage QuizInformatieVakje5TweedeEiland;

    // Objectfaq GameObject
    public GameObject ObjectfaqTweedeEiland;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje5TweedeEiland.onClick.AddListener(CloseVakje5TweedeEiland);
        InformatieTekstVerderTweedeEiland.onClick.AddListener(ShowVideoInformatieVakje5TweedeEiland);
        InformatieVideoTerugTweedeEiland.onClick.AddListener(ShowTextInformatieVakje5TweedeEiland);
        InformatieVideoVerderTweedeEiland.onClick.AddListener(ShowQuizInformatieVakje5TweedeEiland);
        QuizTerugTweedeEiland.onClick.AddListener(ShowVideoInformatieVakje5TweedeEiland);
        QuizAfrondenTweedeEiland.onClick.AddListener(CloseVakje5TweedeEiland);
        ButtonVakje5TweedeEiland.onClick.AddListener(OpenVakje5TweedeEiland);

        // Initialiseer de vakjes en informatie
        ResetVakjesTweedeEiland();
    }

    void ResetVakjesTweedeEiland()
    {
        Vakje5TweedeEiland.SetActive(false);
        TextInformatieVakje5TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje5TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje5TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void OpenVakje5TweedeEiland()
    {
        Vakje5TweedeEiland.SetActive(true);
        TextInformatieVakje5TweedeEiland.gameObject.SetActive(true);
        VideoInformatieVakje5TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje5TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void CloseVakje5TweedeEiland()
    {
        Vakje5TweedeEiland.SetActive(false);
        TextInformatieVakje5TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje5TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje5TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void ShowVideoInformatieVakje5TweedeEiland()
    {
        TextInformatieVakje5TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje5TweedeEiland.gameObject.SetActive(true);
        QuizInformatieVakje5TweedeEiland.gameObject.SetActive(false);
    }

    void ShowTextInformatieVakje5TweedeEiland()
    {
        TextInformatieVakje5TweedeEiland.gameObject.SetActive(true);
        VideoInformatieVakje5TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje5TweedeEiland.gameObject.SetActive(false);
    }

    void ShowQuizInformatieVakje5TweedeEiland()
    {
        TextInformatieVakje5TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje5TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje5TweedeEiland.gameObject.SetActive(true);
    }

    void UpdateInfoTextVisibilityTweedeEiland()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje5TweedeEiland.activeSelf;
        EilandNameTweedeEiland.gameObject.SetActive(allVakjesClosed);
        ObjectfaqTweedeEiland.gameObject.SetActive(allVakjesClosed);
    }
}




