using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformatieVakje4 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandName;

    // alle vakjes
    public GameObject Vakje4;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje4;

    // de buttons die in de vakjes zitten
    public Button ExitVakje4;
    public Button InformatieTekstVerder;
    public Button InformatieVideoTerug;
    public Button InformatieVideoVerder;
    public Button QuizTerug;
    public Button QuizAfronden;

    // de verschillende soorten informatie per vakje
    public RawImage TextInformatieVakje4;
    public RawImage VideoInformatieVakje4;
    public RawImage QuizInformatieVakje4;

    // Objectfaq GameObject
    public GameObject Objectfaq;

    // ProgressieBalk Manager
    public ProgressBarManager progressBarManager;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje4.onClick.AddListener(CloseVakje4);
        InformatieTekstVerder.onClick.AddListener(ShowVideoInformatieVakje4);
        InformatieVideoTerug.onClick.AddListener(ShowTextInformatieVakje4);
        InformatieVideoVerder.onClick.AddListener(ShowQuizInformatieVakje4);
        QuizTerug.onClick.AddListener(ShowVideoInformatieVakje4);
        QuizAfronden.onClick.AddListener(CloseVakje4);
        QuizAfronden.onClick.AddListener(progressBarManager.VakjeAfronden);
        ButtonVakje4.onClick.AddListener(OpenVakje4);

        // Initialiseer de vakjes en informatie
        ResetVakjes();
    }

    void ResetVakjes()
    {
        Vakje4.SetActive(false);
        TextInformatieVakje4.gameObject.SetActive(false);
        VideoInformatieVakje4.gameObject.SetActive(false);
        QuizInformatieVakje4.gameObject.SetActive(false);
        UpdateInfoTextVisibility();
    }

    void OpenVakje4()
    {
        Vakje4.SetActive(true);
        TextInformatieVakje4.gameObject.SetActive(true);
        VideoInformatieVakje4.gameObject.SetActive(false);
        QuizInformatieVakje4.gameObject.SetActive(false);
        UpdateInfoTextVisibility();
    }

    void CloseVakje4()
    {
        Vakje4.SetActive(false);
        TextInformatieVakje4.gameObject.SetActive(false);
        VideoInformatieVakje4.gameObject.SetActive(false);
        QuizInformatieVakje4.gameObject.SetActive(false);
        UpdateInfoTextVisibility();
    }

    void ShowVideoInformatieVakje4()
    {
        TextInformatieVakje4.gameObject.SetActive(false);
        VideoInformatieVakje4.gameObject.SetActive(true);
        QuizInformatieVakje4.gameObject.SetActive(false);
    }

    void ShowTextInformatieVakje4()
    {
        TextInformatieVakje4.gameObject.SetActive(true);
        VideoInformatieVakje4.gameObject.SetActive(false);
        QuizInformatieVakje4.gameObject.SetActive(false);
    }

    void ShowQuizInformatieVakje4()
    {
        TextInformatieVakje4.gameObject.SetActive(false);
        VideoInformatieVakje4.gameObject.SetActive(false);
        QuizInformatieVakje4.gameObject.SetActive(true);
    }

    void UpdateInfoTextVisibility()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje4.activeSelf;
        EilandName.gameObject.SetActive(allVakjesClosed);
        Objectfaq.SetActive(allVakjesClosed);
    }
}
