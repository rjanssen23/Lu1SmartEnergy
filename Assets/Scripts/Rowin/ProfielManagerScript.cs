using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProfielManagerScript : MonoBehaviour
{
    public GameObject ProfielSelectieScherm;
    public GameObject ProfielAanmakenScherm;
    public GameObject VolgendeScene;
    public GameObject textPrefab;
    public GameObject ProfilePrison;
    public GameObject HoofdMenu;
    public int aantalProfielenAangemaakt = 0;

    public GameObject MeisjeButtonObject;
    public GameObject JongenButtonObject;

    public GameObject[] JongenObjecten; // Array voor de jongen objecten
    public GameObject[] MeisjeObjecten; // Array voor de meisje objecten
    public Transform[] SpawnPosities;

    public TMP_InputField ProfielNaam;
    public TMP_InputField GeboorteDatumInput;

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

    public ProfielkeuzeApiClient profielkeuzeApiClient; // Inject the API client

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

        if (GeboorteDatumInput == null)
        {
            Debug.LogError("GeboorteDatumInput is NULL at Start! Make sure it's assigned in the Inspector.");
        }

        foreach (Button knop in KindKnoppen)
        {
            knop.onClick.AddListener(ProfielGeselecteerd);
        }

        // Fetch profiles when the script starts
        FetchProfiles();
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
        FetchProfiles(); // Fetch profiles when navigating to profile selection
    }

    public async void MaakProfiel()
    {
        Debug.Log("MaakProfiel() function started!");

        // Check if important objects are null before proceeding
        if (ProfielNaam == null) { Debug.LogError("ProfielNaam is NULL!"); return; }
        if (GeboorteDatumInput == null) { Debug.LogError("GeboorteDatumInput is NULL!"); return; }
        if (dokterDropdown == null) { Debug.LogError("dokterDropdown is NULL!"); return; }
        if (dokterDropdown.options == null || dokterDropdown.options.Count == 0)
        {
            Debug.LogError("dokterDropdown.options is NULL or empty!");
            return;
        }
        if (profielkeuzeApiClient == null) { Debug.LogError("profielkeuzeApiClient is NULL!"); return; }

        ProfielKeuze newProfielKeuze = new ProfielKeuze
        {
            name = ProfielNaam.text,
            geboorteDatum = GeboorteDatumInput.text,
            arts = dokterDropdown.options[dokterDropdown.value].text,
            avatar = isJongenGekozen ? "Jongen" : "Meisje",
        };

        IWebRequestReponse webRequestResponse = await profielkeuzeApiClient.CreateProfielKeuze(newProfielKeuze);

        switch (webRequestResponse)
        {
            case WebRequestData<ProfielKeuze> dataResponse:
                //Debug.Log("Profiel Aangemaakt: " + dataResponse.Data.id);
                break;
            case WebRequestError errorResponse:
                Debug.LogError("Create profielKeuze error: " + errorResponse.ErrorMessage);
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }

        Debug.Log($"ProfielNaam: {ProfielNaam}, GeboorteDatumInput: {GeboorteDatumInput}, dokterDropdown: {dokterDropdown}");

        ProfielSelectieScherm.SetActive(true);
        ProfielAanmakenScherm.SetActive(false);
        FetchProfiles(); // Refresh profiles after creating a new one
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

    public async void FetchProfiles()
    {
        Debug.Log("Fetching profiles...");

        IWebRequestReponse webRequestResponse = await profielkeuzeApiClient.ReadProfielKeuzes();

        switch (webRequestResponse)
        {
            case WebRequestData<List<ProfielKeuze>> dataResponse:
                List<ProfielKeuze> profielKeuzes = dataResponse.Data;
                DisplayProfiles(profielKeuzes);
                break;
            case WebRequestError errorResponse:
                Debug.LogError("Read profielKeuzes error: " + errorResponse.ErrorMessage);
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    private void DisplayProfiles(List<ProfielKeuze> profielKeuzes)
    {
        // Clear existing profile buttons
        foreach (Transform child in ProfilePrison.transform)
        {
            Destroy(child.gameObject);
        }

        // Create a button for each profile
        foreach (ProfielKeuze profiel in profielKeuzes)
        {
            GameObject newButton = Instantiate(textPrefab, ProfilePrison.transform);
            TMP_Text textComponent = newButton.GetComponent<TMP_Text>();
            if (textComponent != null)
            {
                textComponent.text = profiel.name;
            }
            else
            {
                Debug.LogWarning("Text prefab has no TMP_Text component!");
            }

            Button buttonComponent = newButton.GetComponent<Button>();
            if (buttonComponent != null)
            {
                buttonComponent.onClick.AddListener(() => SelectProfile(profiel));
            }
            else
            {
                Debug.LogWarning("Text prefab has no Button component!");
            }
        }
    }

    private void SelectProfile(ProfielKeuze profiel)
    {
        Debug.Log("Selected profile: " + profiel.name);
        // Handle profile selection logic here
    }
}





