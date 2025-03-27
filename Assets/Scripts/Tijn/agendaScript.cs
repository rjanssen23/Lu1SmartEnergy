using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class agendascript : MonoBehaviour
{
    public GameObject agenda;


   public Button agendaButton;
   public Button terugButton;


     public TMP_InputField Afspraak1Locatie;
     public TMP_InputField Afspraak1datum;
     public TMP_InputField Afspraak2Locatie;
     public TMP_InputField Afspraak2datum;
     public TMP_InputField Afspraak3Locatie;
     public TMP_InputField Afspraak3datum;




    void Start()
    {
        ResetDagboek();

        terugButton.onClick.AddListener(terugButtonClicked);
    }


    public void ResetDagboek()
    {
        agenda.SetActive(false);

    }
    public void dagboekbutton()
    {
        agenda.SetActive(true);
    }

    public void terugButtonClicked() 
    {
        ResetDagboek();
    }



       // bladzijdes.SetActive(true);



}
