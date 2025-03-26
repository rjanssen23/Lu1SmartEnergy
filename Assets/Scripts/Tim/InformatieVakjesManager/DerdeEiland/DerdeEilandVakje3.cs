using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DerdeEilandVakje3 : MonoBehaviour
{
    // eilandnaam tekst
    public TextMeshProUGUI EilandNameDerdeEiland;

    // alle vakjes
    public GameObject Vakje3DerdeEiland;

    // alle vakjes die je hebt in dit eiland
    public Button ButtonVakje3DerdeEiland;

    // de buttons die in de vakjes zitten
    public Button ExitVakje3DerdeEiland;
    public Button VerderVakje3DerdeEiland;
    public Button TerugVakje3DerdeEiland;
    public Button AfrondenVakje3DerdeEiland;

    // de verschillende soorten informatie per vakje
    public RawImage ArmInformatieVakje3DerdeEiland;
    public RawImage BeenInformatieVakje3DerdeEiland;

    // Objectfaq GameObject
    public GameObject ObjectfaqDerdeEiland;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje3DerdeEiland.onClick.AddListener(CloseVakje3DerdeEiland);
        VerderVakje3DerdeEiland.onClick.AddListener(ShowBeenInformatieVakje3DerdeEiland);
        TerugVakje3DerdeEiland.onClick.AddListener(ShowArmInformatieVakje3DerdeEiland);
        AfrondenVakje3DerdeEiland.onClick.AddListener(CloseVakje3DerdeEiland);
        ButtonVakje3DerdeEiland.onClick.AddListener(OpenVakje3DerdeEiland);

        // Initialiseer de vakjes en informatie
        ResetVakjesDerdeEiland();
    }

    void ResetVakjesDerdeEiland()
    {
        Vakje3DerdeEiland.SetActive(false);
        ArmInformatieVakje3DerdeEiland.gameObject.SetActive(false);
        BeenInformatieVakje3DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void OpenVakje3DerdeEiland()
    {
        Vakje3DerdeEiland.SetActive(true);
        ArmInformatieVakje3DerdeEiland.gameObject.SetActive(true);
        BeenInformatieVakje3DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void CloseVakje3DerdeEiland()
    {
        Vakje3DerdeEiland.SetActive(false);
        ArmInformatieVakje3DerdeEiland.gameObject.SetActive(false);
        BeenInformatieVakje3DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void ShowBeenInformatieVakje3DerdeEiland()
    {
        ArmInformatieVakje3DerdeEiland.gameObject.SetActive(false);
        BeenInformatieVakje3DerdeEiland.gameObject.SetActive(true);
    }

    void ShowArmInformatieVakje3DerdeEiland()
    {
        ArmInformatieVakje3DerdeEiland.gameObject.SetActive(true);
        BeenInformatieVakje3DerdeEiland.gameObject.SetActive(false);
    }

    void UpdateInfoTextVisibilityDerdeEiland()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje3DerdeEiland.activeSelf;
        EilandNameDerdeEiland.gameObject.SetActive(allVakjesClosed);
        ObjectfaqDerdeEiland.gameObject.SetActive(allVakjesClosed);
    }
}





