using UnityEngine;
using UnityEngine.UI;

public class InformatieSchermController : MonoBehaviour
{
    // alle scenes
    public GameObject scene2;
    public GameObject scene3; 
    public GameObject scene4;

    public Button TerugNaarScene1;
    public Button NaarVideo;
    public Button TerugNaarTekst;
    public Button NaarScene4;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        TerugNaarScene1.onClick.AddListener(ShowScene2);
        NaarVideo.onClick.AddListener(ShowScene3);
        TerugNaarTekst.onClick.AddListener(ShowScene2);
        NaarScene4.onClick.AddListener(ShowScene4);

        // Initialiseer de scenes
        ShowScene2();
    }

    void ShowScene2()
    {
        scene2.SetActive(true);
        scene3.SetActive(false);
        scene4.SetActive(false);
    }

    void ShowScene3()
    {
        scene2.SetActive(false);
        scene3.SetActive(true);
        scene4.SetActive(false);
    }

    void ShowScene4()
    {
        scene2.SetActive(false);
        scene3.SetActive(false);
        scene4.SetActive(true);
    }
}
