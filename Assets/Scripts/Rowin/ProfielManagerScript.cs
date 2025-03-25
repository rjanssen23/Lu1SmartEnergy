using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfielManagerScript : MonoBehaviour
{
    public GameObject ProfielSelectieScherm;
    public GameObject ProfielAanmakenScherm;
    public GameObject VolgendeScene;

    public GameObject Kind1Object;
    public GameObject Kind2Object;
    public GameObject Kind3Object;
    public GameObject Kind4Object;
    public GameObject Kind5Object;
    public GameObject Kind6Object;

    public Transform SpawnPosition1;
    public Transform SpawnPosition2;
    public Transform SpawnPosition3;
    public Transform SpawnPosition4;
    public Transform SpawnPosition5;
    public Transform SpawnPosition6;

    public GameObject[] spawnObjects; // Hier wijs je 6 objecten toe in de Inspector
    public Transform[] spawnPositions;    // De positie waar het object moet verschijnen

    public TMPro.TMP_InputField ProfielNaam;
    public TMPro.TMP_InputField ProfielLeeftijd;

    public Button ProfielToevoegenButton;

    public Button NaarProfielSelectieButton;

    public Button MaakProfielButton;

    public Button Kind1;
    public Button Kind2;
    public Button Kind3;
    public Button Kind4;
    public Button Kind5;
    public Button Kind6;

    private int spawnIndex = 0; // Houdt bij welk object als volgende moet spawnen




    void Start()
    {
        // Zet de UI naar de startstaat
        Reset();

        // Voeg listeners toe aan de knoppen
        ProfielToevoegenButton.onClick.AddListener(ProfielToevoegenScene);

        NaarProfielSelectieButton.onClick.AddListener(NaarProfielSelectie);

        MaakProfielButton.onClick.AddListener(NaarProfielSelectie);

        MaakProfielButton.onClick.AddListener(SpawnObject); // Correcte manier om de klikfunctie toe te voegen!


        Kind1.onClick.AddListener(ProfielGeselecteerd);
        Kind2.onClick.AddListener(ProfielGeselecteerd);
        Kind3.onClick.AddListener(ProfielGeselecteerd);
        Kind4.onClick.AddListener(ProfielGeselecteerd);
        Kind5.onClick.AddListener(ProfielGeselecteerd);
        Kind6.onClick.AddListener(ProfielGeselecteerd);



    }

    public void Reset()
    {
        ProfielSelectieScherm.SetActive(true);
        ProfielAanmakenScherm.SetActive(false);
        VolgendeScene.SetActive(false);

        Kind1Object.SetActive(true);
        Kind2Object.SetActive(true);
        Kind3Object.SetActive(true);
        Kind4Object.SetActive(true);
        Kind5Object.SetActive(true);
        Kind6Object.SetActive(true);
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

        Kind1Object.SetActive(true);

        Debug.Log("Profiel Aangemaakt");
    }

    public void SpawnObject()
    {
        switch (spawnIndex)
        {
            case 0:
                Instantiate(Kind1Object, SpawnPosition1.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(Kind2Object, SpawnPosition2.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(Kind3Object, SpawnPosition3.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(Kind4Object, SpawnPosition4.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(Kind5Object, SpawnPosition5.position, Quaternion.identity);
                break;
            case 5:
                Instantiate(Kind6Object, SpawnPosition6.position, Quaternion.identity);
                break;
        }
        spawnIndex = (spawnIndex + 1) % 6;
    }
}
