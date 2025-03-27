using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DerdeEilandVakje5 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandNameDerdeEiland;

    // alle vakjes
    public GameObject Vakje5DerdeEiland;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje5DerdeEiland;

    // de buttons die in de vakjes zitten
    public Button ExitVakje5DerdeEiland;
    public Button InformatieTekstVerderDerdeEiland;
    public Button InformatieVideoTerugDerdeEiland;
    public Button InformatieVideoVerderDerdeEiland;
    public Button QuizTerugDerdeEiland;
    public Button QuizAfrondenDerdeEiland;

    // de verschillende soorten informatie per vakje
    public RawImage TextInformatieVakje5DerdeEiland;
    public RawImage VideoInformatieVakje5DerdeEiland;
    public RawImage QuizInformatieVakje5DerdeEiland;

    // Objectfaq GameObject
    public GameObject ObjectfaqDerdeEiland;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje5DerdeEiland.onClick.AddListener(CloseVakje5DerdeEiland);
        InformatieTekstVerderDerdeEiland.onClick.AddListener(ShowVideoInformatieVakje5DerdeEiland);
        InformatieVideoTerugDerdeEiland.onClick.AddListener(ShowTextInformatieVakje5DerdeEiland);
        InformatieVideoVerderDerdeEiland.onClick.AddListener(ShowQuizInformatieVakje5DerdeEiland);
        QuizTerugDerdeEiland.onClick.AddListener(ShowVideoInformatieVakje5DerdeEiland);
        QuizAfrondenDerdeEiland.onClick.AddListener(CloseVakje5DerdeEiland);
        ButtonVakje5DerdeEiland.onClick.AddListener(OpenVakje5DerdeEiland);

        // Initialiseer de vakjes en informatie
        ResetVakjesDerdeEiland();
    }

    void ResetVakjesDerdeEiland()
    {
        Vakje5DerdeEiland.SetActive(false);
        TextInformatieVakje5DerdeEiland.gameObject.SetActive(false);
        VideoInformatieVakje5DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje5DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void OpenVakje5DerdeEiland()
    {
        Vakje5DerdeEiland.SetActive(true);
        TextInformatieVakje5DerdeEiland.gameObject.SetActive(true);
        VideoInformatieVakje5DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje5DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void CloseVakje5DerdeEiland()
    {
        Vakje5DerdeEiland.SetActive(false);
        TextInformatieVakje5DerdeEiland.gameObject.SetActive(false);
        VideoInformatieVakje5DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje5DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void ShowVideoInformatieVakje5DerdeEiland()
    {
        TextInformatieVakje5DerdeEiland.gameObject.SetActive(false);
        VideoInformatieVakje5DerdeEiland.gameObject.SetActive(true);
        QuizInformatieVakje5DerdeEiland.gameObject.SetActive(false);
    }

    void ShowTextInformatieVakje5DerdeEiland()
    {
        TextInformatieVakje5DerdeEiland.gameObject.SetActive(true);
        VideoInformatieVakje5DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje5DerdeEiland.gameObject.SetActive(false);
    }

    void ShowQuizInformatieVakje5DerdeEiland()
    {
        TextInformatieVakje5DerdeEiland.gameObject.SetActive(false);
        VideoInformatieVakje5DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje5DerdeEiland.gameObject.SetActive(true);
    }

    void UpdateInfoTextVisibilityDerdeEiland()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje5DerdeEiland.activeSelf;
        EilandNameDerdeEiland.gameObject.SetActive(allVakjesClosed);
        ObjectfaqDerdeEiland.gameObject.SetActive(allVakjesClosed);
    }
}






