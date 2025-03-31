using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DerdeEilandVakje6 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandNameDerdeEiland;

    // alle vakjes
    public GameObject Vakje6DerdeEiland;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje6DerdeEiland;

    // de buttons die in de vakjes zitten
    public Button ExitVakje6DerdeEiland;
    public Button VerderVakje6DerdeEiland;
    public Button TerugVakje6DerdeEiland;
    public Button VerderNaarTipsDerdeEiland;
    public Button TerugNaarOefeningenDerdeEiland;
    public Button AfrondenVakje6DerdeEiland;

    // de verschillende soorten informatie per vakje
    public RawImage ArmInformatieVakje6DerdeEiland;
    public RawImage BeenInformatieVakje6DerdeEiland;
    public RawImage Tips6;

    // Objectfaq GameObject
    public GameObject ObjectfaqDerdeEiland;

    // ProgressieBalk Manager
    public ProgressieBalkEiland3 progressBarManager;

    // Boolean om bij te houden of het vakje al is afgerond
    private bool isVakjeAfgerond = false;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje6DerdeEiland.onClick.AddListener(CloseVakje6DerdeEiland);
        VerderVakje6DerdeEiland.onClick.AddListener(ShowBeenInformatieVakje6DerdeEiland);
        TerugVakje6DerdeEiland.onClick.AddListener(ShowArmInformatieVakje6DerdeEiland);
        VerderNaarTipsDerdeEiland.onClick.AddListener(ShowTips6);
        TerugNaarOefeningenDerdeEiland.onClick.AddListener(ShowBeenInformatieVakje6DerdeEiland);
        AfrondenVakje6DerdeEiland.onClick.AddListener(CloseVakje6DerdeEiland);
        AfrondenVakje6DerdeEiland.onClick.AddListener(AfrondenVakje6);
        ButtonVakje6DerdeEiland.onClick.AddListener(OpenVakje6DerdeEiland);

        // Initialiseer de vakjes en informatie
        ResetVakjesDerdeEiland();
    }

    void ResetVakjesDerdeEiland()
    {
        Vakje6DerdeEiland.SetActive(false);
        ArmInformatieVakje6DerdeEiland.gameObject.SetActive(false);
        BeenInformatieVakje6DerdeEiland.gameObject.SetActive(false);
        Tips6.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void OpenVakje6DerdeEiland()
    {
        Vakje6DerdeEiland.SetActive(true);
        ArmInformatieVakje6DerdeEiland.gameObject.SetActive(true);
        BeenInformatieVakje6DerdeEiland.gameObject.SetActive(false);
        Tips6.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void CloseVakje6DerdeEiland()
    {
        Vakje6DerdeEiland.SetActive(false);
        ArmInformatieVakje6DerdeEiland.gameObject.SetActive(false);
        BeenInformatieVakje6DerdeEiland.gameObject.SetActive(false);
        Tips6.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void ShowBeenInformatieVakje6DerdeEiland()
    {
        ArmInformatieVakje6DerdeEiland.gameObject.SetActive(false);
        BeenInformatieVakje6DerdeEiland.gameObject.SetActive(true);
        Tips6.gameObject.SetActive(false);
    }

    void ShowArmInformatieVakje6DerdeEiland()
    {
        ArmInformatieVakje6DerdeEiland.gameObject.SetActive(true);
        BeenInformatieVakje6DerdeEiland.gameObject.SetActive(false);
        Tips6.gameObject.SetActive(false);
    }

    void ShowTips6()
    {
        ArmInformatieVakje6DerdeEiland.gameObject.SetActive(false);
        BeenInformatieVakje6DerdeEiland.gameObject.SetActive(false);
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

    void UpdateInfoTextVisibilityDerdeEiland()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje6DerdeEiland.activeSelf;
        EilandNameDerdeEiland.gameObject.SetActive(allVakjesClosed);
        ObjectfaqDerdeEiland.gameObject.SetActive(allVakjesClosed);
    }
}






