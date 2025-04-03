//Als de scenes gemerged worden de weggecomenteerde dingen weer terug toevoegen en aan de andere scenes koppelen.

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System;

public class ProfielManagerScript : MonoBehaviour
{
    public GameObject ProfielSelectieScherm;
    public GameObject ProfielAanmakenScherm;
    public GameObject VolgendeScene;
    public GameObject textPrefab;
    public GameObject ProfilePrison;
    public GameObject HoofdMenu;
    public GameObject GeselecteerdeDokter;
    public int aantalProfielenAangemaakt = 0;

    public GameObject MeisjeButtonObject;
    public GameObject JongenButtonObject;

    public GameObject[] JongenObjecten; // Array voor de jongen objecten
    public GameObject[] MeisjeObjecten; // Array voor de meisje objecten
    public Transform[] SpawnPosities;

    public TMP_InputField ProfielNaam;

    public TMP_Text Dokter1Text;
    public TMP_Text Dokter2Text;
    public TMP_Text Dokter3Text;


    public Button ProfielToevoegenButton;
    public Button NaarProfielSelectieButton;
    public Button MaakProfielButton;
    public Button JongenButton;
    public Button MeisjeButton;
    public Button VolgendeSceneButton;
    public Button MeisjePrefab;
    public Button JongenPrefab;
    public Button TerugNaarMenu;

    public Button[] KindKnoppen;

    public TMP_Dropdown dokterDropdown; // Assign this in Unity Inspector


    private int spawnIndex = 0;
    private bool isJongenGekozen = true; // Default to jongen

    void Start()
    {
        Reset();
        ProfielToevoegenButton.onClick.AddListener(ProfielToevoegenScene);
        NaarProfielSelectieButton.onClick.AddListener(NaarProfielSelectie);
        MaakProfielButton.onClick.AddListener(MaakProfiel);
        JongenButton.onClick.AddListener(JongenGekozen);
        MeisjeButton.onClick.AddListener(MeisjeGekozen);
        MaakProfielButton.onClick.AddListener(SpawnObject);
        VolgendeSceneButton.onClick.AddListener(VolgendeSceneSwitch);
        MeisjePrefab.onClick.AddListener(VolgendeSceneSwitch);
        JongenPrefab.onClick.AddListener(VolgendeSceneSwitch);
        TerugNaarMenu.onClick.AddListener(HoofdmenuSwitch);

        dokterDropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dokterDropdown); });

        foreach (Button knop in KindKnoppen)
        {
            knop.onClick.AddListener(ProfielGeselecteerd);
        }
    }

    public void Reset()
    {
        ProfielSelectieScherm.SetActive(true);
        ProfielAanmakenScherm.SetActive(false);
        VolgendeScene.SetActive(false);
    }

    void DropdownItemSelected(TMP_Dropdown dropdown)
    {
        int selectedIndex = dropdown.value; // Get the selected index
        string selectedText = dropdown.options[selectedIndex].text; // Get the selected text

        Debug.Log("Selected: " + selectedText);

        // Update the corresponding text field with the selected name
        if (Dokter1Text != null)
            Dokter1Text.text = selectedText;
        Dokter2Text.text = selectedText;
        Dokter3Text.text = selectedText;
    }


    public void HoofdmenuSwitch()
    {
        ProfielSelectieScherm.SetActive(false);
        ProfielAanmakenScherm.SetActive(false);
        VolgendeScene.SetActive(false);
        HoofdMenu.SetActive(true);
    }
    public void VolgendeSceneSwitch()
    {
        ProfielSelectieScherm.SetActive(false);
        ProfielAanmakenScherm.SetActive(false);
        VolgendeScene.SetActive(true);
    }
    public void ProfielToevoegenScene()
    {
        ProfielSelectieScherm.SetActive(false);
        ProfielAanmakenScherm.SetActive(true);
        MeisjeButtonObject.SetActive(true);
        JongenButtonObject.SetActive(true);
    }

    public void ProfielGeselecteerd()
    {
        VolgendeScene.SetActive(true);
        ProfielSelectieScherm.SetActive(false);
        ProfielAanmakenScherm.SetActive(false);
    }

    public void NaarProfielSelectie()
    {
        ProfielSelectieScherm.SetActive(true);
        ProfielAanmakenScherm.SetActive(false);
    }

    public void MaakProfiel()
    {
        // If we reach this point, the age is valid, so create the profile
        ProfielSelectieScherm.SetActive(true);
        ProfielAanmakenScherm.SetActive(false);
        Debug.Log("Profiel Aangemaakt");
    }


    public void JongenGekozen()
    {
        isJongenGekozen = true;
        MeisjeButtonObject.SetActive(false);
        JongenButtonObject.SetActive(true);
        Debug.Log("Jongen is gekozen");
    }

    public void MeisjeGekozen()
    {
        isJongenGekozen = false;
        JongenButtonObject.SetActive(false);
        MeisjeButtonObject.SetActive(true);
        Debug.Log("Meisje is gekozen");
    }

    public void SpawnObject()
    {
        GameObject[] gekozenObjecten = isJongenGekozen ? JongenObjecten : MeisjeObjecten;

        if (aantalProfielenAangemaakt == 6)
        {
            Debug.LogWarning("Geen beschikbare objecten of spawnposities meer!");
            return;
        }

        GameObject newObject = Instantiate(gekozenObjecten[spawnIndex], SpawnPosities[spawnIndex].position, Quaternion.identity);

        if (ProfilePrison != null)
        {
            newObject.transform.SetParent(ProfilePrison.transform, false);
        }
        else
        {
            Debug.LogWarning("ProfilePrison is not assigned in the Inspector!");
        }

        if (textPrefab != null)
        {
            GameObject newText = Instantiate(textPrefab, SpawnPosities[spawnIndex].position, Quaternion.identity);
            newText.transform.SetParent(newObject.transform, false);

            TMP_Text textComponent = newText.GetComponent<TMP_Text>();
            if (textComponent != null)
            {
                textComponent.text = ProfielNaam.text;
                newText.transform.localPosition = new Vector3(0, -73, 0);
                textComponent.fontSize = 50;
            }
            else
            {
                Debug.LogWarning("Text prefab has no TMP_Text component!");
            }
        }
        else
        {
            Debug.LogWarning("Text prefab is not assigned!");
        }

        spawnIndex = (spawnIndex + 1) % gekozenObjecten.Length;
        aantalProfielenAangemaakt++;
    }
}




