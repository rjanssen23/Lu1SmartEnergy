using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TweedeEilandVakje3 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandNameTweedeEiland;

    // alle vakjes
    public GameObject Vakje3TweedeEiland;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje3TweedeEiland;

    // de buttons die in de vakjes zitten
    public Button ExitVakje3TweedeEiland;
    public Button VerderVakje3TweedeEiland;
    public Button TerugVakje3TweedeEiland;
    public Button AfrondenVakje3TweedeEiland;

    // de verschillende soorten informatie per vakje
    public RawImage ArmInformatieVakje3TweedeEiland;
    public RawImage BeenInformatieVakje3TweedeEiland;

    // Objectfaq GameObject
    public GameObject ObjectfaqTweedeEiland;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje3TweedeEiland.onClick.AddListener(CloseVakje3TweedeEiland);
        VerderVakje3TweedeEiland.onClick.AddListener(ShowBeenInformatieVakje3TweedeEiland);
        TerugVakje3TweedeEiland.onClick.AddListener(ShowArmInformatieVakje3TweedeEiland);
        AfrondenVakje3TweedeEiland.onClick.AddListener(CloseVakje3TweedeEiland);
        ButtonVakje3TweedeEiland.onClick.AddListener(OpenVakje3TweedeEiland);

        // Initialiseer de vakjes en informatie
        ResetVakjesTweedeEiland();
    }

    void ResetVakjesTweedeEiland()
    {
        Vakje3TweedeEiland.SetActive(false);
        ArmInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        BeenInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void OpenVakje3TweedeEiland()
    {
        Vakje3TweedeEiland.SetActive(true);
        ArmInformatieVakje3TweedeEiland.gameObject.SetActive(true);
        BeenInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void CloseVakje3TweedeEiland()
    {
        Vakje3TweedeEiland.SetActive(false);
        ArmInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        BeenInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void ShowBeenInformatieVakje3TweedeEiland()
    {
        ArmInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        BeenInformatieVakje3TweedeEiland.gameObject.SetActive(true);
    }

    void ShowArmInformatieVakje3TweedeEiland()
    {
        ArmInformatieVakje3TweedeEiland.gameObject.SetActive(true);
        BeenInformatieVakje3TweedeEiland.gameObject.SetActive(false);
    }

    void UpdateInfoTextVisibilityTweedeEiland()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje3TweedeEiland.activeSelf;
        EilandNameTweedeEiland.gameObject.SetActive(allVakjesClosed);
        ObjectfaqTweedeEiland.gameObject.SetActive(allVakjesClosed);
    }
}





