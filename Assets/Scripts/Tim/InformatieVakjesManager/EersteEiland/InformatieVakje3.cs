using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformatieVakje3 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandName;

    // alle vakjes
    public GameObject Vakje3;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje3;

    // de buttons die in de vakjes zitten
    public Button ExitVakje3;
    public Button InformatieTekstVerder;
    public Button InformatieVideoTerug;
    public Button InformatieVideoVerder;
    public Button QuizTerug;
    public Button QuizAfronden;

    // de verschillende soorten informatie per vakje
    public RawImage TextInformatieVakje3;
    public RawImage VideoInformatieVakje3;
    public RawImage QuizInformatieVakje3;

    // Objectfaq GameObject
    public GameObject Objectfaq;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje3.onClick.AddListener(CloseVakje3);
        InformatieTekstVerder.onClick.AddListener(ShowVideoInformatieVakje3);
        InformatieVideoTerug.onClick.AddListener(ShowTextInformatieVakje3);
        InformatieVideoVerder.onClick.AddListener(ShowQuizInformatieVakje3);
        QuizTerug.onClick.AddListener(ShowVideoInformatieVakje3);
        QuizAfronden.onClick.AddListener(CloseVakje3);
        ButtonVakje3.onClick.AddListener(OpenVakje3);

        // Initialiseer de vakjes en informatie
        ResetVakjes();
    }

    void ResetVakjes()
    {
        Vakje3.SetActive(false);
        TextInformatieVakje3.gameObject.SetActive(false);
        VideoInformatieVakje3.gameObject.SetActive(false);
        QuizInformatieVakje3.gameObject.SetActive(false);
        UpdateInfoTextVisibility();
    }

    void OpenVakje3()
    {
        Vakje3.SetActive(true);
        TextInformatieVakje3.gameObject.SetActive(true);
        VideoInformatieVakje3.gameObject.SetActive(false);
        QuizInformatieVakje3.gameObject.SetActive(false);
        UpdateInfoTextVisibility();
    }

    void CloseVakje3()
    {
        Vakje3.SetActive(false);
        TextInformatieVakje3.gameObject.SetActive(false);
        VideoInformatieVakje3.gameObject.SetActive(false);
        QuizInformatieVakje3.gameObject.SetActive(false);
        UpdateInfoTextVisibility();
    }

    void ShowVideoInformatieVakje3()
    {
        TextInformatieVakje3.gameObject.SetActive(false);
        VideoInformatieVakje3.gameObject.SetActive(true);
        QuizInformatieVakje3.gameObject.SetActive(false);
    }

    void ShowTextInformatieVakje3()
    {
        TextInformatieVakje3.gameObject.SetActive(true);
        VideoInformatieVakje3.gameObject.SetActive(false);
        QuizInformatieVakje3.gameObject.SetActive(false);
    }

    void ShowQuizInformatieVakje3()
    {
        TextInformatieVakje3.gameObject.SetActive(false);
        VideoInformatieVakje3.gameObject.SetActive(false);
        QuizInformatieVakje3.gameObject.SetActive(true);
    }

    void UpdateInfoTextVisibility()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje3.activeSelf;
        EilandName.gameObject.SetActive(allVakjesClosed);
        Objectfaq.SetActive(allVakjesClosed);
    }
}



