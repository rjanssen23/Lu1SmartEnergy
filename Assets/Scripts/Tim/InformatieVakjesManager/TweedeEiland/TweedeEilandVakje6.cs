using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TweedeEilandVakje6 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandNameTweedeEiland;

    // alle vakjes
    public GameObject Vakje6TweedeEiland;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje6TweedeEiland;

    // de buttons die in de vakjes zitten
    public Button ExitVakje6TweedeEiland;
    public Button VerderVakje6TweedeEiland;
    public Button TerugVakje6TweedeEiland;
    public Button AfrondenVakje6TweedeEiland;

    // de verschillende soorten informatie per vakje
    public RawImage ArmInformatieVakje6TweedeEiland;
    public RawImage BeenInformatieVakje6TweedeEiland;

    // Objectfaq GameObject
    public GameObject ObjectfaqTweedeEiland;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje6TweedeEiland.onClick.AddListener(CloseVakje6TweedeEiland);
        VerderVakje6TweedeEiland.onClick.AddListener(ShowBeenInformatieVakje6TweedeEiland);
        TerugVakje6TweedeEiland.onClick.AddListener(ShowArmInformatieVakje6TweedeEiland);
        AfrondenVakje6TweedeEiland.onClick.AddListener(CloseVakje6TweedeEiland);
        ButtonVakje6TweedeEiland.onClick.AddListener(OpenVakje6TweedeEiland);

        // Initialiseer de vakjes en informatie
        ResetVakjesTweedeEiland();
    }

    void ResetVakjesTweedeEiland()
    {
        Vakje6TweedeEiland.SetActive(false);
        ArmInformatieVakje6TweedeEiland.gameObject.SetActive(false);
        BeenInformatieVakje6TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void OpenVakje6TweedeEiland()
    {
        Vakje6TweedeEiland.SetActive(true);
        ArmInformatieVakje6TweedeEiland.gameObject.SetActive(true);
        BeenInformatieVakje6TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void CloseVakje6TweedeEiland()
    {
        Vakje6TweedeEiland.SetActive(false);
        ArmInformatieVakje6TweedeEiland.gameObject.SetActive(false);
        BeenInformatieVakje6TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void ShowBeenInformatieVakje6TweedeEiland()
    {
        ArmInformatieVakje6TweedeEiland.gameObject.SetActive(false);
        BeenInformatieVakje6TweedeEiland.gameObject.SetActive(true);
    }

    void ShowArmInformatieVakje6TweedeEiland()
    {
        ArmInformatieVakje6TweedeEiland.gameObject.SetActive(true);
        BeenInformatieVakje6TweedeEiland.gameObject.SetActive(false);
    }

    void UpdateInfoTextVisibilityTweedeEiland()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje6TweedeEiland.activeSelf;
        EilandNameTweedeEiland.gameObject.SetActive(allVakjesClosed);
        ObjectfaqTweedeEiland.gameObject.SetActive(allVakjesClosed);
    }
}




