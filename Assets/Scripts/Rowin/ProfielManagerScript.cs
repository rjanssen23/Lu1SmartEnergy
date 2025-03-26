using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfielManagerScript : MonoBehaviour
{
    public GameObject ProfielSelectieScherm;
    public GameObject ProfielAanmakenScherm;
    public GameObject VolgendeScene;

    public GameObject[] KindObjecten; // Array voor de 6 verschillende objecten
    public TMP_Text[] KindTeksten; // Array voor de 6 tekstvelden
    public Transform[] SpawnPosities; // Array voor de 6 spawn posities

    public TMP_InputField ProfielNaam;
    public TMP_InputField ProfielLeeftijd;

    public Button ProfielToevoegenButton;
    public Button NaarProfielSelectieButton;
    public Button MaakProfielButton;

    public Button[] KindKnoppen; // Array voor de 6 profielknoppen

    private int spawnIndex = 0; // Houdt bij welk object als volgende moet spawnen

    void Start()
    {
        // Zet de UI naar de startstaat
        Reset();

        // Voeg listeners toe aan de knoppen
        ProfielToevoegenButton.onClick.AddListener(ProfielToevoegenScene);
        NaarProfielSelectieButton.onClick.AddListener(NaarProfielSelectie);
        MaakProfielButton.onClick.AddListener(MaakProfiel);

        // Voeg de SpawnObject-functie toe aan de MaakProfielButton
        MaakProfielButton.onClick.AddListener(SpawnObject);

        // Voeg listeners toe aan de profielknoppen
        foreach (Button knop in KindKnoppen)
        {
            knop.onClick.AddListener(ProfielGeselecteerd);
        }

        // Update de tekst live als de naam wordt ingevoerd
        ProfielNaam.onValueChanged.AddListener(UpdateTextLive);
    }

    public void Reset()
    {
        ProfielSelectieScherm.SetActive(true);
        ProfielAanmakenScherm.SetActive(false);
        VolgendeScene.SetActive(false);
    }

    public void ProfielToevoegenScene()
    {
        ProfielSelectieScherm.SetActive(false);
        ProfielAanmakenScherm.SetActive(true);
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
        ProfielSelectieScherm.SetActive(true);
        ProfielAanmakenScherm.SetActive(false);
        Debug.Log("Profiel Aangemaakt");
    }

    public void UpdateTextLive(string nieuweNaam)
    {
        if (spawnIndex < KindTeksten.Length)
        {
            KindTeksten[spawnIndex].text = nieuweNaam;
        }
    }

    public void SpawnObject()
    {
        if (spawnIndex >= KindObjecten.Length || spawnIndex >= SpawnPosities.Length)
        {
            Debug.LogWarning("Geen beschikbare objecten of spawnposities meer!");
            return;
        }

        // Instantiate prefab
        GameObject newObject = Instantiate(KindObjecten[spawnIndex], SpawnPosities[spawnIndex].position, Quaternion.identity);

        // Make sure it spawns inside the KindProfielen container (if applicable)
        

        // Find and update the text inside the spawned object
        TMP_Text textComponent = newObject.GetComponentInChildren<TMP_Text>();
        if (textComponent != null)
        {
            textComponent.text = ProfielNaam.text; // Set the text to the entered name
        }
        else
        {
            Debug.LogWarning("Geen TMP_Text gevonden in prefab " + KindObjecten[spawnIndex].name);
        }

        spawnIndex = (spawnIndex + 1) % KindObjecten.Length;
    }


}




