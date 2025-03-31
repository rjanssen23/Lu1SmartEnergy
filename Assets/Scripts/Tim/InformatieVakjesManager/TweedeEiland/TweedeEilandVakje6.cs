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
    public Button HandEnArmVolgendeTweedeEiland;
    public Button VoetEnBeenTerugTweedeEiland;
    public Button VoetEnBeenVerderTweedeEiland;
    public Button TerugNaarOefeningenTweedeEiland;
    public Button Vakje6AfrondenTweedeEiland;

    // de verschillende soorten informatie per vakje
    public RawImage HandEnArmInformatieVakje6TweedeEiland;
    public RawImage VoetEnBeenInformatieVakje6TweedeEiland;
    public RawImage Tips6;

    // Objectfaq GameObject
    public GameObject ObjectfaqTweedeEiland;

    // ProgressieBalk Manager
    public ProgressieBalkEiland2 progressBarManager;

    // Boolean om bij te houden of het vakje al is afgerond
    private bool isVakjeAfgerond = false;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje6TweedeEiland.onClick.AddListener(CloseVakje6TweedeEiland);
        HandEnArmVolgendeTweedeEiland.onClick.AddListener(ShowVoetEnBeenInformatieVakje6TweedeEiland);
        VoetEnBeenTerugTweedeEiland.onClick.AddListener(ShowHandEnArmInformatieVakje6TweedeEiland);
        VoetEnBeenVerderTweedeEiland.onClick.AddListener(ShowTips6);
        TerugNaarOefeningenTweedeEiland.onClick.AddListener(ShowVoetEnBeenInformatieVakje6TweedeEiland);
        Vakje6AfrondenTweedeEiland.onClick.AddListener(CloseVakje6TweedeEiland);
        Vakje6AfrondenTweedeEiland.onClick.AddListener(AfrondenVakje6);
        ButtonVakje6TweedeEiland.onClick.AddListener(OpenVakje6TweedeEiland);

        // Initialiseer de vakjes en informatie
        ResetVakjesTweedeEiland();
    }

    void ResetVakjesTweedeEiland()
    {
        Vakje6TweedeEiland.SetActive(false);
        HandEnArmInformatieVakje6TweedeEiland.gameObject.SetActive(false);
        VoetEnBeenInformatieVakje6TweedeEiland.gameObject.SetActive(false);
        Tips6.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void OpenVakje6TweedeEiland()
    {
        Vakje6TweedeEiland.SetActive(true);
        HandEnArmInformatieVakje6TweedeEiland.gameObject.SetActive(true);
        VoetEnBeenInformatieVakje6TweedeEiland.gameObject.SetActive(false);
        Tips6.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void CloseVakje6TweedeEiland()
    {
        Vakje6TweedeEiland.SetActive(false);
        HandEnArmInformatieVakje6TweedeEiland.gameObject.SetActive(false);
        VoetEnBeenInformatieVakje6TweedeEiland.gameObject.SetActive(false);
        Tips6.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void ShowHandEnArmInformatieVakje6TweedeEiland()
    {
        HandEnArmInformatieVakje6TweedeEiland.gameObject.SetActive(true);
        VoetEnBeenInformatieVakje6TweedeEiland.gameObject.SetActive(false);
        Tips6.gameObject.SetActive(false);
    }

    void ShowVoetEnBeenInformatieVakje6TweedeEiland()
    {
        HandEnArmInformatieVakje6TweedeEiland.gameObject.SetActive(false);
        VoetEnBeenInformatieVakje6TweedeEiland.gameObject.SetActive(true);
        Tips6.gameObject.SetActive(false);
    }

    void ShowTips6()
    {
        HandEnArmInformatieVakje6TweedeEiland.gameObject.SetActive(false);
        VoetEnBeenInformatieVakje6TweedeEiland.gameObject.SetActive(false);
        Tips6.gameObject.SetActive(true);
    }

    void AfrondenVakje6()
    {
        if (!isVakjeAfgerond)
        {
            isVakjeAfgerond = true;
            progressBarManager.VakjeAfronden(5); // 5 is de index voor Vakje6
        }
    }

    void UpdateInfoTextVisibilityTweedeEiland()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje6TweedeEiland.activeSelf;
        EilandNameTweedeEiland.gameObject.SetActive(allVakjesClosed);
        ObjectfaqTweedeEiland.gameObject.SetActive(allVakjesClosed);
    }
}




