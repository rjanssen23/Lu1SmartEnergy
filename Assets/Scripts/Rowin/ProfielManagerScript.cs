using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ProfielManagerScript : MonoBehaviour
{
    public GameObject ProfielSelectieScherm;
    public GameObject ProfielAanmakenScherm;
    public GameObject VolgendeScene;
    public GameObject textPrefab;
    public GameObject ProfilePrison;
    public GameObject HoofdMenu;

    public GameObject MeisjeButtonObject;
    public GameObject JongenButtonObject;

    public GameObject[] JongenObjecten; // Array voor de jongen objecten
    public GameObject[] MeisjeObjecten; // Array voor de meisje objecten
    public Transform[] SpawnPosities;

    public TMP_InputField ProfielNaam;
    public TMP_InputField ProfielLeeftijd;

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

    public Dropdown DokterSelectie;

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

        DokterSelectie.onValueChanged.AddListener(OnDropdownValueChanged);

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

    void OnDropdownValueChanged(int index)
    {
        string selectedOption = DokterSelectie.options[index].text;

        switch (selectedOption)
        {
            case "Optie 1":
                // Voeg hier de logica toe voor optie 1
                Debug.Log("dr. Doofenschmirtz");
                break;

            case "Optie 2":
                // Voeg hier de logica toe voor optie 2
                Debug.Log("dr. Ooststad geselecteerd");
                break;

            case "Optie 3":
                // Voeg hier de logica toe voor optie 3
                Debug.Log("dr. Castalot geselecteerd");
                break;

            case "optie 4":
                Debug.Log("Geen dokter Geselecteerd!");
                break;

            default:
                Debug.Log("Onbekende optie geselecteerd");
                break;
        }
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
        string naam = ProfielNaam.text.Trim();
        int leeftijd;

        // Controleer of leeftijd een geldig getal is
        if (!int.TryParse(ProfielLeeftijd.text, out leeftijd) || leeftijd < 4 || leeftijd > 12)
        {
            Debug.LogError("Leeftijd moet tussen de 4 en 12 jaar zijn!");
            return;
        }

        // Controleer de lengte van de naam
        if (naam.Length > 15)
        {
            Debug.LogError("Naam mag maximaal 15 karakters lang zijn!");
            return;
        }

        ProfielSelectieScherm.SetActive(true);
        ProfielAanmakenScherm.SetActive(false);
        Debug.Log("Profiel Aangemaakt: " + naam + ", Leeftijd: " + leeftijd);
    }


    public void JongenGekozen()
    {
        isJongenGekozen = true;
        MeisjeButtonObject.SetActive(false);
        JongenButtonObject.SetActive(true);
    }

    public void MeisjeGekozen()
    {
        isJongenGekozen = false;
        JongenButtonObject.SetActive(false);
        MeisjeButtonObject.SetActive(true);
    }

    public void SpawnObject()
    {
        GameObject[] gekozenObjecten = isJongenGekozen ? JongenObjecten : MeisjeObjecten;

        if (spawnIndex >= gekozenObjecten.Length || spawnIndex >= SpawnPosities.Length)
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
    }
}





