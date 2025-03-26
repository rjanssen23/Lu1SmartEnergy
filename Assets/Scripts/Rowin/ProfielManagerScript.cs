using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfielManagerScript : MonoBehaviour
{
    public GameObject ProfielSelectieScherm;
    public GameObject ProfielAanmakenScherm;
    public GameObject VolgendeScene;
    public GameObject textPrefab; // Assign a TMP_Text prefab in the Inspector

    public GameObject[] KindObjecten; // Array voor de 6 verschillende objecten
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

    public void SpawnObject()
    {
        if (spawnIndex >= KindObjecten.Length || spawnIndex >= SpawnPosities.Length)
        {
            Debug.LogWarning("Geen beschikbare objecten of spawnposities meer!");
            return;
        }

        // Instantiate the profile object (profile picture)
        GameObject newObject = Instantiate(KindObjecten[spawnIndex], SpawnPosities[spawnIndex].position, Quaternion.identity);

        Canvas canvas = FindObjectOfType<Canvas>(); // Find an existing canvas
        if (canvas != null)
        {
            newObject.transform.SetParent(canvas.transform, false);
        }
        else
        {
            Debug.LogWarning("No Canvas found! The text might not be visible.");
        }

        // Instantiate the text object (name text)
        if (textPrefab != null)
        {
            GameObject newText = Instantiate(textPrefab, SpawnPosities[spawnIndex].position, Quaternion.identity);

            // Set the text object as a child of the profile object
            newText.transform.SetParent(newObject.transform, false); // This line makes the text a child of the profile object

            TMP_Text textComponent = newText.GetComponent<TMP_Text>();
            if (textComponent != null)
            {
                textComponent.text = ProfielNaam.text; // Set the name text

                // Position the text below the profile image
                newText.transform.localPosition = new Vector3(0, -73, 0); // Adjust the Y position to be below the image
                textComponent.fontSize = 50; // Adjust this value as needed

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

        spawnIndex = (spawnIndex + 1) % KindObjecten.Length; // Update the spawnIndex for the next profile

    }
}





