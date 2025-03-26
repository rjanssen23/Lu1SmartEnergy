using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TweedeEilandVakje4 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandNameTweedeEiland;

    // alle vakjes
    public GameObject Vakje4TweedeEiland;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje4TweedeEiland;

    // de buttons die in de vakjes zitten
    public Button ExitVakje4TweedeEiland;
    public Button InformatieTekstVerderTweedeEiland;
    public Button InformatieVideoTerugTweedeEiland;
    public Button InformatieVideoVerderTweedeEiland;
    public Button QuizTerugTweedeEiland;
    public Button QuizAfrondenTweedeEiland;

    // de verschillende soorten informatie per vakje
    public RawImage TextInformatieVakje4TweedeEiland;
    public RawImage VideoInformatieVakje4TweedeEiland;
    public RawImage QuizInformatieVakje4TweedeEiland;

    // Objectfaq GameObject
    public GameObject ObjectfaqTweedeEiland;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje4TweedeEiland.onClick.AddListener(CloseVakje4TweedeEiland);
        InformatieTekstVerderTweedeEiland.onClick.AddListener(ShowVideoInformatieVakje4TweedeEiland);
        InformatieVideoTerugTweedeEiland.onClick.AddListener(ShowTextInformatieVakje4TweedeEiland);
        InformatieVideoVerderTweedeEiland.onClick.AddListener(ShowQuizInformatieVakje4TweedeEiland);
        QuizTerugTweedeEiland.onClick.AddListener(ShowVideoInformatieVakje4TweedeEiland);
        QuizAfrondenTweedeEiland.onClick.AddListener(CloseVakje4TweedeEiland);
        ButtonVakje4TweedeEiland.onClick.AddListener(OpenVakje4TweedeEiland);

        // Initialiseer de vakjes en informatie
        ResetVakjesTweedeEiland();
    }

    void ResetVakjesTweedeEiland()
    {
        Vakje4TweedeEiland.SetActive(false);
        TextInformatieVakje4TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje4TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje4TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void OpenVakje4TweedeEiland()
    {
        Vakje4TweedeEiland.SetActive(true);
        TextInformatieVakje4TweedeEiland.gameObject.SetActive(true);
        VideoInformatieVakje4TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje4TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void CloseVakje4TweedeEiland()
    {
        Vakje4TweedeEiland.SetActive(false);
        TextInformatieVakje4TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje4TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje4TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void ShowVideoInformatieVakje4TweedeEiland()
    {
        TextInformatieVakje4TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje4TweedeEiland.gameObject.SetActive(true);
        QuizInformatieVakje4TweedeEiland.gameObject.SetActive(false);
    }

    void ShowTextInformatieVakje4TweedeEiland()
    {
        TextInformatieVakje4TweedeEiland.gameObject.SetActive(true);
        VideoInformatieVakje4TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje4TweedeEiland.gameObject.SetActive(false);
    }

    void ShowQuizInformatieVakje4TweedeEiland()
    {
        TextInformatieVakje4TweedeEiland.gameObject.SetActive(false);
        VideoInformatieVakje4TweedeEiland.gameObject.SetActive(false);
        QuizInformatieVakje4TweedeEiland.gameObject.SetActive(true);
    }

    void UpdateInfoTextVisibilityTweedeEiland()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje4TweedeEiland.activeSelf;
        EilandNameTweedeEiland.gameObject.SetActive(allVakjesClosed);
        ObjectfaqTweedeEiland.gameObject.SetActive(allVakjesClosed);
    }
}




