using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformatieVakje2 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandName;

    // alle vakjes
    public GameObject Vakje2;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje2;

    // de buttons die in de vakjes zitten
    public Button ExitVakje2;
    public Button InformatieTekstVerder;
    public Button InformatieVideoTerug;
    public Button InformatieVideoVerder;
    public Button QuizTerug;
    public Button QuizAfronden;

    // de verschillende soorten informatie per vakje
    public RawImage TextInformatieVakje2;
    public RawImage VideoInformatieVakje2;
    public RawImage QuizInformatieVakje2;

    // Objectfaq GameObject
    public GameObject Objectfaq;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje2.onClick.AddListener(CloseVakje2);
        InformatieTekstVerder.onClick.AddListener(ShowVideoInformatieVakje2);
        InformatieVideoTerug.onClick.AddListener(ShowTextInformatieVakje2);
        InformatieVideoVerder.onClick.AddListener(ShowQuizInformatieVakje2);
        QuizTerug.onClick.AddListener(ShowVideoInformatieVakje2);
        QuizAfronden.onClick.AddListener(CloseVakje2);
        ButtonVakje2.onClick.AddListener(OpenVakje2);

        // Initialiseer de vakjes en informatie
        ResetVakjes();
    }

    void ResetVakjes()
    {
        Vakje2.SetActive(false);
        TextInformatieVakje2.gameObject.SetActive(false);
        VideoInformatieVakje2.gameObject.SetActive(false);
        QuizInformatieVakje2.gameObject.SetActive(false);
        UpdateInfoTextVisibility();
    }

    void OpenVakje2()
    {
        Vakje2.SetActive(true);
        TextInformatieVakje2.gameObject.SetActive(true);
        VideoInformatieVakje2.gameObject.SetActive(false);
        QuizInformatieVakje2.gameObject.SetActive(false);
        UpdateInfoTextVisibility();
    }

    void CloseVakje2()
    {
        Vakje2.SetActive(false);
        TextInformatieVakje2.gameObject.SetActive(false);
        VideoInformatieVakje2.gameObject.SetActive(false);
        QuizInformatieVakje2.gameObject.SetActive(false);
        UpdateInfoTextVisibility();
    }

    void ShowVideoInformatieVakje2()
    {
        TextInformatieVakje2.gameObject.SetActive(false);
        VideoInformatieVakje2.gameObject.SetActive(true);
        QuizInformatieVakje2.gameObject.SetActive(false);
    }

    void ShowTextInformatieVakje2()
    {
        TextInformatieVakje2.gameObject.SetActive(true);
        VideoInformatieVakje2.gameObject.SetActive(false);
        QuizInformatieVakje2.gameObject.SetActive(false);
    }

    void ShowQuizInformatieVakje2()
    {
        TextInformatieVakje2.gameObject.SetActive(false);
        VideoInformatieVakje2.gameObject.SetActive(false);
        QuizInformatieVakje2.gameObject.SetActive(true);
    }

    void UpdateInfoTextVisibility()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje2.activeSelf;
        EilandName.gameObject.SetActive(allVakjesClosed);
        Objectfaq.SetActive(allVakjesClosed);
    }
}


