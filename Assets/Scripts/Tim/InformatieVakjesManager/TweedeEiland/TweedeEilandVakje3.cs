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
    public Button HandEnArmVolgendeTweedeEiland;
    public Button VoetEnBeenTerugTweedeEiland;
    public Button VoetEnBeenVerderTweedeEiland;
    public Button TerugNaarOefeningenTweedeEiland;
    public Button Vakje3AfrondenTweedeEiland;

    // de verschillende soorten informatie per vakje
    public RawImage HandEnArmInformatieVakje3TweedeEiland;
    public RawImage VoetEnBeenInformatieVakje3TweedeEiland;
    public RawImage Tips3;

    // Objectfaq GameObject
    public GameObject ObjectfaqTweedeEiland;

    // ProgressieBalk Manager
    public ProgressieBalkEiland2 progressBarManager;

    // Boolean om bij te houden of het vakje al is afgerond
    private bool isVakjeAfgerond = false;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje3TweedeEiland.onClick.AddListener(CloseVakje3TweedeEiland);
        HandEnArmVolgendeTweedeEiland.onClick.AddListener(ShowVoetEnBeenInformatieVakje3TweedeEiland);
        VoetEnBeenTerugTweedeEiland.onClick.AddListener(ShowHandEnArmInformatieVakje3TweedeEiland);
        VoetEnBeenVerderTweedeEiland.onClick.AddListener(ShowTips3);
        TerugNaarOefeningenTweedeEiland.onClick.AddListener(ShowVoetEnBeenInformatieVakje3TweedeEiland);
        Vakje3AfrondenTweedeEiland.onClick.AddListener(CloseVakje3TweedeEiland);
        Vakje3AfrondenTweedeEiland.onClick.AddListener(AfrondenVakje3);
        ButtonVakje3TweedeEiland.onClick.AddListener(OpenVakje3TweedeEiland);

        // Initialiseer de vakjes en informatie
        ResetVakjesTweedeEiland();
    }

    void ResetVakjesTweedeEiland()
    {
        Vakje3TweedeEiland.SetActive(false);
        HandEnArmInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        VoetEnBeenInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        Tips3.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void OpenVakje3TweedeEiland()
    {
        Vakje3TweedeEiland.SetActive(true);
        HandEnArmInformatieVakje3TweedeEiland.gameObject.SetActive(true);
        VoetEnBeenInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        Tips3.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void CloseVakje3TweedeEiland()
    {
        Vakje3TweedeEiland.SetActive(false);
        HandEnArmInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        VoetEnBeenInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        Tips3.gameObject.SetActive(false);
        UpdateInfoTextVisibilityTweedeEiland();
    }

    void ShowHandEnArmInformatieVakje3TweedeEiland()
    {
        HandEnArmInformatieVakje3TweedeEiland.gameObject.SetActive(true);
        VoetEnBeenInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        Tips3.gameObject.SetActive(false);
    }

    void ShowVoetEnBeenInformatieVakje3TweedeEiland()
    {
        HandEnArmInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        VoetEnBeenInformatieVakje3TweedeEiland.gameObject.SetActive(true);
        Tips3.gameObject.SetActive(false);
    }

    void ShowTips3()
    {
        HandEnArmInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        VoetEnBeenInformatieVakje3TweedeEiland.gameObject.SetActive(false);
        Tips3.gameObject.SetActive(true);
    }

    void AfrondenVakje3()
    {
        if (!isVakjeAfgerond)
        {
            isVakjeAfgerond = true;
            progressBarManager.VakjeAfronden(2); // 2 is de index voor Vakje3
        }
    }

    void UpdateInfoTextVisibilityTweedeEiland()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje3TweedeEiland.activeSelf;
        EilandNameTweedeEiland.gameObject.SetActive(allVakjesClosed);
        ObjectfaqTweedeEiland.gameObject.SetActive(allVakjesClosed);
    }
}

