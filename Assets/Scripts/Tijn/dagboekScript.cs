using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class DagboekScript : MonoBehaviour
{
    public GameObject bladzijdes;
    public GameObject bladzijde1;
    public GameObject bladzijde2;
    public GameObject bladzijde3;
    public GameObject bladzijde4;

    public Button dagboekButton;
    public Button volgende1Button;
    public Button volgende2Button;
    public Button volgende3Button;
    public Button terugButton1;
    public Button terugButton2;
    public Button terugButton3;
    public Button terugButton4;

    public TMP_InputField inputField1;
    public TMP_InputField inputField2;
    public TMP_InputField inputField3;
    public TMP_InputField inputField4;


    void Start()
    {

        // Zet de UI naar de startstaat
        Reset();

        // Voeg listeners toe aan de knoppen
        dagboekButton.onClick.AddListener(DagboekButtonClicked);
        volgende1Button.onClick.AddListener(ButtonVolgende1Clicked);
        volgende2Button.onClick.AddListener(ButtonVolgende2Clicked);
        volgende3Button.onClick.AddListener(ButtonVolgende3Clicked);
        terugButton1.onClick.AddListener(TerugButton1Clicked);
        terugButton2.onClick.AddListener(TerugButton2Clicked);
        terugButton3.onClick.AddListener(TerugButton3Clicked);
        terugButton4.onClick.AddListener(TerugButton4Clicked);
    }

    public void Reset()
    {
        bladzijdes.SetActive(false);
        bladzijde1.SetActive(true);
        bladzijde2.SetActive(true);
        bladzijde3.SetActive(true);
        bladzijde4.SetActive(true);
    }

    public void DagboekButtonClicked()
    {
        bladzijdes.SetActive(true);
    }

    public void ButtonVolgende1Clicked()
    {
        bladzijde1.SetActive(false);
    }

    public void ButtonVolgende2Clicked()
    {
        bladzijde2.SetActive(false);
    }

    public void ButtonVolgende3Clicked()
    {
        bladzijde3.SetActive(false);
    }

    public void TerugButton1Clicked()
    {
        bladzijdes.SetActive(false);
    }

    public void TerugButton2Clicked()
    {
        bladzijde1.SetActive(true);
    }

    public void TerugButton3Clicked()
    {
        bladzijde2.SetActive(true);
    }

    public void TerugButton4Clicked()
    {
        bladzijde3.SetActive(true);
    }
}
