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
    public Button AfrondenVakje6DerdeEiland;

    // de verschillende soorten informatie per vakje
    public RawImage ArmInformatieVakje6DerdeEiland;
    public RawImage BeenInformatieVakje6DerdeEiland;

    // Objectfaq GameObject
    public GameObject ObjectfaqDerdeEiland;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        ExitVakje6DerdeEiland.onClick.AddListener(CloseVakje6DerdeEiland);
        VerderVakje6DerdeEiland.onClick.AddListener(ShowBeenInformatieVakje6DerdeEiland);
        TerugVakje6DerdeEiland.onClick.AddListener(ShowArmInformatieVakje6DerdeEiland);
        AfrondenVakje6DerdeEiland.onClick.AddListener(CloseVakje6DerdeEiland);
        ButtonVakje6DerdeEiland.onClick.AddListener(OpenVakje6DerdeEiland);

        // Initialiseer de vakjes en informatie
        ResetVakjesDerdeEiland();
    }

    void ResetVakjesDerdeEiland()
    {
        Vakje6DerdeEiland.SetActive(false);
        ArmInformatieVakje6DerdeEiland.gameObject.SetActive(false);
        BeenInformatieVakje6DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void OpenVakje6DerdeEiland()
    {
        Vakje6DerdeEiland.SetActive(true);
        ArmInformatieVakje6DerdeEiland.gameObject.SetActive(true);
        BeenInformatieVakje6DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void CloseVakje6DerdeEiland()
    {
        Vakje6DerdeEiland.SetActive(false);
        ArmInformatieVakje6DerdeEiland.gameObject.SetActive(false);
        BeenInformatieVakje6DerdeEiland.gameObject.SetActive(false);
        UpdateInfoTextVisibilityDerdeEiland();
    }

    void ShowBeenInformatieVakje6DerdeEiland()
    {
        ArmInformatieVakje6DerdeEiland.gameObject.SetActive(false);
        BeenInformatieVakje6DerdeEiland.gameObject.SetActive(true);
    }

    void ShowArmInformatieVakje6DerdeEiland()
    {
        ArmInformatieVakje6DerdeEiland.gameObject.SetActive(true);
        BeenInformatieVakje6DerdeEiland.gameObject.SetActive(false);
    }

    void UpdateInfoTextVisibilityDerdeEiland()
    {
        // Controleer of alle vakjes gesloten zijn
        bool allVakjesClosed = !Vakje6DerdeEiland.activeSelf;
        EilandNameDerdeEiland.gameObject.SetActive(allVakjesClosed);
        ObjectfaqDerdeEiland.gameObject.SetActive(allVakjesClosed);
    }
}






