using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TweedeEilandVakje7 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandNameTweedeEiland;

    // alle vakjes
    public GameObject Vakje7TweedeEiland;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje7TweedeEiland;

    // de buttons die in de vakjes zitten
    public Button ExitVakje7TweedeEiland;
    public Button InformatieTekstVerderTweedeEiland;
    public Button InformatieVideoTerugTweedeEiland;
    public Button InformatieVideoVerderTweedeEiland;
    public Button QuizTerugTweedeEiland;
    public Button QuizAfrondenTweedeEiland;

    // de verschillende soorten informatie per vakje
    public RawImage TextInformatieVakje7TweedeEiland;
    public RawImage VideoInformatieVakje7TweedeEiland;
    public RawImage QuizInformatieVakje7TweedeEiland;

    // Objectfaq GameObject
    public GameObject ObjectfaqTweedeEiland;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje7TweedeEiland.onClick.AddListener(CloseVakje7TweedeEiland);
        InformatieTekstVerderTweedeEiland.onClick.AddListener(ShowVideoInformatieVakje7TweedeEiland);
        InformatieVideoTerugTweedeEiland.onClick.AddListener(ShowTextInformatieVakje7TweedeEiland);
        InformatieVideoVerderTweedeEiland.onClick.AddListener(ShowQuizInformatieVakje7TweedeEiland);
        QuizTerugTweedeEiland.onClick.AddListener(ShowVideoInformatieVakje7TweedeEiland);
        QuizAfrondenTweedeEiland.onClick.AddListener(CloseVakje7TweedeEiland);
        ButtonVakje7TweedeEiland.onClick.AddListener(OpenVakje7TweedeEiland);

        // Initialiseer de vakjes en informatie
        ResetVakjesTweedeEiland();
    }

    void ResetVakjesTweedeEiland()
    {
        Vakje7TweedeEiland.SetActive(false);
        TextInformatieVakje7TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje7TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje7TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void OpenVakje7TweedeEiland()
    {
        Vakje7TweedeEiland.SetActive(true);
        TextInformatieVakje7TweedeEiland.gameObject.SetActive(true);
        VideoInformatieVakje7TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje7TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void CloseVakje7TweedeEiland()
    {
        Vakje7TweedeEiland.SetActive(false);
        TextInformatieVakje7TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje7TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje7TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void ShowVideoInformatieVakje7TweedeEiland()
    {
        TextInformatieVakje7TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje7TweedeEiland.gameObject.SetActive(true);
        QuizInformatieVakje7TweedeEiland.gameObject.SetActive(false);
    }

    void ShowTextInformatieVakje7TweedeEiland()
    {
        TextInformatieVakje7TweedeEiland.gameObject.SetActive(true);
        VideoInformatieVakje7TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje7TweedeEiland.gameObject.SetActive(false);
    }

    void ShowQuizInformatieVakje7TweedeEiland()
    {
        TextInformatieVakje7TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje7TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje7TweedeEiland.gameObject.SetActive(true);
    }

    void UpdateInfoTextVisibilityTweedeEiland()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje7TweedeEiland.activeSelf;
        EilandNameTweedeEiland.gameObject.SetActive(allVakjesClosed);
        ObjectfaqTweedeEiland.gameObject.SetActive(allVakjesClosed);
    }
}




