using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DerdeEilandVakje4 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandNameDerdeEiland;

    // alle vakjes
    public GameObject Vakje4DerdeEiland;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje4DerdeEiland;

    // de buttons die in de vakjes zitten
    public Button ExitVakje4DerdeEiland;
    public Button InformatieTekstVerderDerdeEiland;
    public Button InformatieVideoTerugDerdeEiland;
    public Button InformatieVideoVerderDerdeEiland;
    public Button QuizTerugDerdeEiland;
    public Button QuizAfrondenDerdeEiland;

    // de verschillende soorten informatie per vakje
    public RawImage TextInformatieVakje4DerdeEiland;
    public RawImage VideoInformatieVakje4DerdeEiland;
    public RawImage QuizInformatieVakje4DerdeEiland;

    // Objectfaq GameObject
    public GameObject ObjectfaqDerdeEiland;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje4DerdeEiland.onClick.AddListener(CloseVakje4DerdeEiland);
        InformatieTekstVerderDerdeEiland.onClick.AddListener(ShowVideoInformatieVakje4DerdeEiland);
        InformatieVideoTerugDerdeEiland.onClick.AddListener(ShowTextInformatieVakje4DerdeEiland);
        InformatieVideoVerderDerdeEiland.onClick.AddListener(ShowQuizInformatieVakje4DerdeEiland);
        QuizTerugDerdeEiland.onClick.AddListener(ShowVideoInformatieVakje4DerdeEiland);
        QuizAfrondenDerdeEiland.onClick.AddListener(CloseVakje4DerdeEiland);
        ButtonVakje4DerdeEiland.onClick.AddListener(OpenVakje4DerdeEiland);

        // Initialiseer de vakjes en informatie
        ResetVakjesDerdeEiland();
    }

    void ResetVakjesDerdeEiland()
    {
        Vakje4DerdeEiland.SetActive(false);
        TextInformatieVakje4DerdeEiland.gameObject.SetActive(false);
        VideoInformatieVakje4DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje4DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void OpenVakje4DerdeEiland()
    {
        Vakje4DerdeEiland.SetActive(true);
        TextInformatieVakje4DerdeEiland.gameObject.SetActive(true);
        VideoInformatieVakje4DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje4DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void CloseVakje4DerdeEiland()
    {
        Vakje4DerdeEiland.SetActive(false);
        TextInformatieVakje4DerdeEiland.gameObject.SetActive(false);
        VideoInformatieVakje4DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje4DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void ShowVideoInformatieVakje4DerdeEiland()
    {
        TextInformatieVakje4DerdeEiland.gameObject.SetActive(false);
        VideoInformatieVakje4DerdeEiland.gameObject.SetActive(true);
        QuizInformatieVakje4DerdeEiland.gameObject.SetActive(false);
    }

    void ShowTextInformatieVakje4DerdeEiland()
    {
        TextInformatieVakje4DerdeEiland.gameObject.SetActive(true);
        VideoInformatieVakje4DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje4DerdeEiland.gameObject.SetActive(false);
    }

    void ShowQuizInformatieVakje4DerdeEiland()
    {
        TextInformatieVakje4DerdeEiland.gameObject.SetActive(false);
        VideoInformatieVakje4DerdeEiland.gameObject.SetActive(false);
        QuizInformatieVakje4DerdeEiland.gameObject.SetActive(true);
    }

    void UpdateInfoTextVisibilityDerdeEiland()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje4DerdeEiland.activeSelf;
        EilandNameDerdeEiland.gameObject.SetActive(allVakjesClosed);
        ObjectfaqDerdeEiland.gameObject.SetActive(allVakjesClosed);
    }
}






