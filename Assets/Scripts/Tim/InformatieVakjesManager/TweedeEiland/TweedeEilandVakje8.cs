using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TweedeEilandVakje8 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandNameTweedeEiland;

    // alle vakjes
    public GameObject Vakje8TweedeEiland;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje8TweedeEiland;

    // de buttons die in de vakjes zitten
    public Button ExitVakje8TweedeEiland;
    public Button InformatieTekstVerderTweedeEiland;
    public Button InformatieVideoTerugTweedeEiland;
    public Button InformatieVideoVerderTweedeEiland;
    public Button QuizTerugTweedeEiland;
    public Button QuizAfrondenTweedeEiland;

    // de verschillende soorten informatie per vakje
    public RawImage TextInformatieVakje8TweedeEiland;
    public RawImage VideoInformatieVakje8TweedeEiland;
    public RawImage QuizInformatieVakje8TweedeEiland;

    // Objectfaq GameObject
    public GameObject ObjectfaqTweedeEiland;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje8TweedeEiland.onClick.AddListener(CloseVakje8TweedeEiland);
        InformatieTekstVerderTweedeEiland.onClick.AddListener(ShowVideoInformatieVakje8TweedeEiland);
        InformatieVideoTerugTweedeEiland.onClick.AddListener(ShowTextInformatieVakje8TweedeEiland);
        InformatieVideoVerderTweedeEiland.onClick.AddListener(ShowQuizInformatieVakje8TweedeEiland);
        QuizTerugTweedeEiland.onClick.AddListener(ShowVideoInformatieVakje8TweedeEiland);
        QuizAfrondenTweedeEiland.onClick.AddListener(CloseVakje8TweedeEiland);
        ButtonVakje8TweedeEiland.onClick.AddListener(OpenVakje8TweedeEiland);

        // Initialiseer de vakjes en informatie
        ResetVakjesTweedeEiland();
    }

    void ResetVakjesTweedeEiland()
    {
        Vakje8TweedeEiland.SetActive(false);
        TextInformatieVakje8TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje8TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje8TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void OpenVakje8TweedeEiland()
    {
        Vakje8TweedeEiland.SetActive(true);
        TextInformatieVakje8TweedeEiland.gameObject.SetActive(true);
        VideoInformatieVakje8TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje8TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void CloseVakje8TweedeEiland()
    {
        Vakje8TweedeEiland.SetActive(false);
        TextInformatieVakje8TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje8TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje8TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void ShowVideoInformatieVakje8TweedeEiland()
    {
        TextInformatieVakje8TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje8TweedeEiland.gameObject.SetActive(true);
        QuizInformatieVakje8TweedeEiland.gameObject.SetActive(false);
    }

    void ShowTextInformatieVakje8TweedeEiland()
    {
        TextInformatieVakje8TweedeEiland.gameObject.SetActive(true);
        VideoInformatieVakje8TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje8TweedeEiland.gameObject.SetActive(false);
    }

    void ShowQuizInformatieVakje8TweedeEiland()
    {
        TextInformatieVakje8TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje8TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje8TweedeEiland.gameObject.SetActive(true);
    }

    void UpdateInfoTextVisibilityTweedeEiland()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje8TweedeEiland.activeSelf;
        EilandNameTweedeEiland.gameObject.SetActive(allVakjesClosed);
        ObjectfaqTweedeEiland.gameObject.SetActive(allVakjesClosed);
    }
}





