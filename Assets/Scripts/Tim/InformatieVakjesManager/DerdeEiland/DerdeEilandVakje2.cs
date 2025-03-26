using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DerdeEilandVakje2 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandNameDerdeEiland;

    // alle vakjes
    public GameObject Vakje2DerdeEiland;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje2DerdeEiland;

    // de buttons die in de vakjes zitten
    public Button ExitVakje2DerdeEiland;
    public Button InformatieTekstVerderDerdeEiland;
    public Button InformatieVideoTerugDerdeEiland;
    public Button InformatieVideoVerderDerdeEiland;
    public Button QuizTerugDerdeEiland;
    public Button QuizAfrondenDerdeEiland;

    // de verschillende soorten informatie per vakje
    public RawImage TextInformatieVakje2DerdeEiland;
    public RawImage VideoInformatieVakje2DerdeEiland;
    public RawImage QuizInformatieVakje2DerdeEiland;

    // Objectfaq GameObject
    public GameObject ObjectfaqDerdeEiland;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje2DerdeEiland.onClick.AddListener(CloseVakje2DerdeEiland);
        InformatieTekstVerderDerdeEiland.onClick.AddListener(ShowVideoInformatieVakje2DerdeEiland);
        InformatieVideoTerugDerdeEiland.onClick.AddListener(ShowTextInformatieVakje2DerdeEiland);
        InformatieVideoVerderDerdeEiland.onClick.AddListener(ShowQuizInformatieVakje2DerdeEiland);
        QuizTerugDerdeEiland.onClick.AddListener(ShowVideoInformatieVakje2DerdeEiland);
        QuizAfrondenDerdeEiland.onClick.AddListener(CloseVakje2DerdeEiland);
        ButtonVakje2DerdeEiland.onClick.AddListener(OpenVakje2DerdeEiland);

        // Initialiseer de vakjes en informatie
        ResetVakjesDerdeEiland();
    }

    void ResetVakjesDerdeEiland()
    {
        Vakje2DerdeEiland.SetActive(false);
        TextInformatieVakje2DerdeEiland.gameObject.SetActive(false);
        VideoInformatieVakje2DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje2DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void OpenVakje2DerdeEiland()
    {
        Vakje2DerdeEiland.SetActive(true);
        TextInformatieVakje2DerdeEiland.gameObject.SetActive(true);
        VideoInformatieVakje2DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje2DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void CloseVakje2DerdeEiland()
    {
        Vakje2DerdeEiland.SetActive(false);
        TextInformatieVakje2DerdeEiland.gameObject.SetActive(false);
        VideoInformatieVakje2DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje2DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void ShowVideoInformatieVakje2DerdeEiland()
    {
        TextInformatieVakje2DerdeEiland.gameObject.SetActive(false);
        VideoInformatieVakje2DerdeEiland.gameObject.SetActive(true);
        QuizInformatieVakje2DerdeEiland.gameObject.SetActive(false);
    }

    void ShowTextInformatieVakje2DerdeEiland()
    {
        TextInformatieVakje2DerdeEiland.gameObject.SetActive(true);
        VideoInformatieVakje2DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje2DerdeEiland.gameObject.SetActive(false);
    }

    void ShowQuizInformatieVakje2DerdeEiland()
    {
        TextInformatieVakje2DerdeEiland.gameObject.SetActive(false);
        VideoInformatieVakje2DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje2DerdeEiland.gameObject.SetActive(true);
    }

    void UpdateInfoTextVisibilityDerdeEiland()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje2DerdeEiland.activeSelf;
        EilandNameDerdeEiland.gameObject.SetActive(allVakjesClosed);
        ObjectfaqDerdeEiland.gameObject.SetActive(allVakjesClosed);
    }
}






