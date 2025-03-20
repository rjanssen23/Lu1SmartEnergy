using UnityEngine;
using UnityEngine.UI;

public class PapegaaiScript : MonoBehaviour
{
    //public GameObject PapegaaiFAQ;
    //public GameObject antwoordenFAQ;
    //public GameObject antwoord1;
    //public GameObject antwoord2;
    //public GameObject antwoord3;
    public GameObject FaqStap1;
    public GameObject FaqStap2;
    public GameObject FaqStap3;

    public Button papegaaiButton;
    public Button vraag1;
    public Button vraag2;
    public Button vraag3;
    public Button Terug1;
    public Button Terug2;

    public RawImage antwoord1Image;
    public RawImage antwoord2Image;
    public RawImage antwoord3Image;

    void Start()
    {
        Reset();
        FaqStap1.SetActive(true); // Alleen FaqStap1 moet actief zijn bij het starten

        papegaaiButton.onClick.AddListener(PapegaaiButtonClicked);
        vraag1.onClick.AddListener(Vraag1Clicked);
        vraag2.onClick.AddListener(Vraag2Clicked);
        vraag3.onClick.AddListener(Vraag3Clicked);
        Terug1.onClick.AddListener(Terug1Clicked);
        Terug2.onClick.AddListener(Terug2Clicked);
    }

    public void Reset()
    {
        FaqStap1.SetActive(false);
        FaqStap2.SetActive(false);
        FaqStap3.SetActive(false);
        antwoord1Image.gameObject.SetActive(false);
        antwoord2Image.gameObject.SetActive(false);
        antwoord3Image.gameObject.SetActive(false);
    }

    public void PapegaaiButtonClicked()
    {
        FaqStap2.SetActive(true);
    }

    public void Vraag1Clicked()
    {
        FaqStap2.SetActive(false);
        FaqStap3.SetActive(true);
        antwoord1Image.gameObject.SetActive(true);
        antwoord2Image.gameObject.SetActive(false);
        antwoord3Image.gameObject.SetActive(false);
    }

    public void Vraag2Clicked()
    {
        FaqStap2.SetActive(false);
        FaqStap3.SetActive(true);
        antwoord1Image.gameObject.SetActive(false);
        antwoord2Image.gameObject.SetActive(true);
        antwoord3Image.gameObject.SetActive(false);
    }

    public void Vraag3Clicked()
    {
        FaqStap2.SetActive(false);
        FaqStap3.SetActive(true);
        antwoord1Image.gameObject.SetActive(false);
        antwoord2Image.gameObject.SetActive(false);
        antwoord3Image.gameObject.SetActive(true);
    }

    public void Terug1Clicked()
    {
        FaqStap2.SetActive(false);
        FaqStap3.SetActive(false);
        FaqStap1.SetActive(true);
    }

    public void Terug2Clicked()
    {
        FaqStap3.SetActive(false);
        FaqStap2.SetActive(true);
    }
}

