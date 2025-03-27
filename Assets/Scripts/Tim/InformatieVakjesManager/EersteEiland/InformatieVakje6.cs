using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformatieVakje6 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandName;

    // alle vakjes
    public GameObject Vakje6;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje6;

    // de buttons die in de vakjes zitten
    public Button ExitVakje6;
    public Button InformatieTekstVerder;
    public Button InformatieVideoTerug;
    public Button InformatieVideoVerder;
    public Button QuizTerug;
    public Button QuizAfronden;

    // de verschillende soorten informatie per vakje
    public RawImage TextInformatieVakje6;
    public RawImage VideoInformatieVakje6;
    public RawImage QuizInformatieVakje6;

    // Objectfaq GameObject
    public GameObject Objectfaq;

    // ProgressieBalkManager
    public ProgressBarManager progressBarManager;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje6.onClick.AddListener(CloseVakje6);
        InformatieTekstVerder.onClick.AddListener(ShowVideoInformatieVakje6);
        InformatieVideoTerug.onClick.AddListener(ShowTextInformatieVakje6);
        InformatieVideoVerder.onClick.AddListener(ShowQuizInformatieVakje6);
        QuizTerug.onClick.AddListener(ShowVideoInformatieVakje6);
        QuizAfronden.onClick.AddListener(CloseVakje6);
        QuizAfronden.onClick.AddListener(progressBarManager.VakjeAfronden);
        ButtonVakje6.onClick.AddListener(OpenVakje6);

        // Initialiseer de vakjes en informatie
        ResetVakjes();
    }

    void ResetVakjes()
    {
        Vakje6.SetActive(false);
        TextInformatieVakje6.gameObject.SetActive(false);
        VideoInformatieVakje6.gameObject.SetActive(false);
        QuizInformatieVakje6.gameObject.SetActive(false);
        UpdateInfoTextVisibility();
    }

    void OpenVakje6()
    {
        Vakje6.SetActive(true);
        TextInformatieVakje6.gameObject.SetActive(true);
        VideoInformatieVakje6.gameObject.SetActive(false);
        QuizInformatieVakje6.gameObject.SetActive(false);
        UpdateInfoTextVisibility();
    }

    void CloseVakje6()
    {
        Vakje6.SetActive(false);
        TextInformatieVakje6.gameObject.SetActive(false);
        VideoInformatieVakje6.gameObject.SetActive(false);
        QuizInformatieVakje6.gameObject.SetActive(false);
        UpdateInfoTextVisibility();
    }

    void ShowVideoInformatieVakje6()
    {
        TextInformatieVakje6.gameObject.SetActive(false);
        VideoInformatieVakje6.gameObject.SetActive(true);
        QuizInformatieVakje6.gameObject.SetActive(false);
    }

    void ShowTextInformatieVakje6()
    {
        TextInformatieVakje6.gameObject.SetActive(true);
        VideoInformatieVakje6.gameObject.SetActive(false);
        QuizInformatieVakje6.gameObject.SetActive(false);
    }

    void ShowQuizInformatieVakje6()
    {
        TextInformatieVakje6.gameObject.SetActive(false);
        VideoInformatieVakje6.gameObject.SetActive(false);
        QuizInformatieVakje6.gameObject.SetActive(true);
    }

    void UpdateInfoTextVisibility()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje6.activeSelf;
        EilandName.gameObject.SetActive(allVakjesClosed);
        Objectfaq.SetActive(allVakjesClosed);
    }
}
