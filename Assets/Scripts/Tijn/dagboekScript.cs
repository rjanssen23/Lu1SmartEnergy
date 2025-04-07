using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

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

    private const string InputField1Key = "InputField1";
    private const string InputField2Key = "InputField2";
    private const string InputField3Key = "InputField3";
    private const string InputField4Key = "InputField4";

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

        // Load saved data
        LoadData();
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

    private void OnApplicationQuit()
    {
        SaveData();
    }

    private void SaveData()
    {
        PlayerPrefs.SetString(InputField1Key, inputField1.text);
        PlayerPrefs.SetString(InputField2Key, inputField2.text);
        PlayerPrefs.SetString(InputField3Key, inputField3.text);
        PlayerPrefs.SetString(InputField4Key, inputField4.text);
        PlayerPrefs.Save();
    }

    private void LoadData()
    {
        if (PlayerPrefs.HasKey(InputField1Key))
        {
            inputField1.text = PlayerPrefs.GetString(InputField1Key);
        }
        if (PlayerPrefs.HasKey(InputField2Key))
        {
            inputField2.text = PlayerPrefs.GetString(InputField2Key);
        }
        if (PlayerPrefs.HasKey(InputField3Key))
        {
            inputField3.text = PlayerPrefs.GetString(InputField3Key);
        }
        if (PlayerPrefs.HasKey(InputField4Key))
        {
            inputField4.text = PlayerPrefs.GetString(InputField4Key);
        }
    }
}

