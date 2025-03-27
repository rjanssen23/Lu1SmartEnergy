using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformatieVakje5 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandName;

    // alle vakjes
    public GameObject Vakje5;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje5;

    // de buttons die in de vakjes zitten
    public Button ExitVakje5;
    public Button InformatieTekstVerder;
    public Button InformatieVideoTerug;
    public Button InformatieVideoVerder;
    public Button QuizTerug;
    public Button QuizAfronden;

    // de verschillende soorten informatie per vakje
    public RawImage TextInformatieVakje5;
    public RawImage VideoInformatieVakje5;
    public RawImage QuizInformatieVakje5;

    // Objectfaq GameObject
    public GameObject Objectfaq;

    // ProgressieBalkManager
    public ProgressBarManager progressBarManager;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje5.onClick.AddListener(CloseVakje5);
        InformatieTekstVerder.onClick.AddListener(ShowVideoInformatieVakje5);
        InformatieVideoTerug.onClick.AddListener(ShowTextInformatieVakje5);
        InformatieVideoVerder.onClick.AddListener(ShowQuizInformatieVakje5);
        QuizTerug.onClick.AddListener(ShowVideoInformatieVakje5);
        QuizAfronden.onClick.AddListener(CloseVakje5);
        QuizAfronden.onClick.AddListener(progressBarManager.VakjeAfronden);
        ButtonVakje5.onClick.AddListener(OpenVakje5);

        // Initialiseer de vakjes en informatie
        ResetVakjes();
    }

    void ResetVakjes()
    {
        Vakje5.SetActive(false);
        TextInformatieVakje5.gameObject.SetActive(false);
        VideoInformatieVakje5.gameObject.SetActive(false);
        QuizInformatieVakje5.gameObject.SetActive(false);
        UpdateInfoTextVisibility();
    }

    void OpenVakje5()
    {
        Vakje5.SetActive(true);
        TextInformatieVakje5.gameObject.SetActive(true);
        VideoInformatieVakje5.gameObject.SetActive(false);
        QuizInformatieVakje5.gameObject.SetActive(false);
        UpdateInfoTextVisibility();
    }

    void CloseVakje5()
    {
        Vakje5.SetActive(false);
        TextInformatieVakje5.gameObject.SetActive(false);
        VideoInformatieVakje5.gameObject.SetActive(false);
        QuizInformatieVakje5.gameObject.SetActive(false);
        UpdateInfoTextVisibility();
    }

    void ShowVideoInformatieVakje5()
    {
        TextInformatieVakje5.gameObject.SetActive(false);
        VideoInformatieVakje5.gameObject.SetActive(true);
        QuizInformatieVakje5.gameObject.SetActive(false);
    }

    void ShowTextInformatieVakje5()
    {
        TextInformatieVakje5.gameObject.SetActive(true);
        VideoInformatieVakje5.gameObject.SetActive(false);
        QuizInformatieVakje5.gameObject.SetActive(false);
    }

    void ShowQuizInformatieVakje5()
    {
        TextInformatieVakje5.gameObject.SetActive(false);
        VideoInformatieVakje5.gameObject.SetActive(false);
        QuizInformatieVakje5.gameObject.SetActive(true);
    }

    void UpdateInfoTextVisibility()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje5.activeSelf;
        EilandName.gameObject.SetActive(allVakjesClosed);
        Objectfaq.SetActive(allVakjesClosed);
    }
}



