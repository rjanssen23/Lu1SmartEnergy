using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class agendascript : MonoBehaviour
{
    public GameObject agendaboek;
    public GameObject inputfield1datum;
    public GameObject inputfield1locatie;
    public GameObject inputfield2datum;
    public GameObject inputfield2locatie;
    public GameObject inputfield3datum;
    public GameObject inputfield3locatie;




    public Button agendaButton;
    public Button terugButton;
    public Button FirstSaveButton;
    public Button SaveButton;

    
    public TMP_InputField Afspraak1LocatieInput;
    public TMP_InputField Afspraak1datumInput;
    public TMP_InputField Afspraak2LocatieInput;
    public TMP_InputField Afspraak2datumInput;
    public TMP_InputField Afspraak3LocatieInput;
    public TMP_InputField Afspraak3datumInput;

 
    public TMP_Text Afspraak1LocatieText;
    public TMP_Text Afspraak1datumText;
    public TMP_Text Afspraak2LocatieText;
    public TMP_Text Afspraak2datumText;
    public TMP_Text Afspraak3LocatieText;
    public TMP_Text Afspraak3datumText;

    public AgendaApiClient agendaApiClient;

    void Start()
    {
        // Hide the agenda at the start
        agendaboek.SetActive(false);
        terugButton.onClick.AddListener(Sluiten);
        agendaButton.onClick.AddListener(Agendabutton);
        FirstSaveButton.onClick.AddListener(FirstSaveButtonClicked);
        SaveButton.onClick.AddListener(SaveButtonClicked);
    }

    public async void Agendabutton()
    {
        agendaboek.SetActive(true);
        await LoadAgendaData();
    }

    public void Sluiten()
    {
        agendaboek.SetActive(false);
    }

    public void ResetDagboek()
    {
        agendaboek.SetActive(false);
    }

    private void FirstSaveButtonClicked()
    {
        // Create a new agenda object
        Agenda newAgenda = new Agenda
        {
            date1 = Afspraak1datumInput.text,
            location1 = Afspraak1LocatieInput.text,
            date2 = Afspraak2datumInput.text,
            location2 = Afspraak2LocatieInput.text,
            date3 = Afspraak3datumInput.text,
            location3 = Afspraak3LocatieInput.text
        };

        // Save the new agenda
        Awaitable<IWebRequestReponse> awaitable = agendaApiClient.CreateAgenda(newAgenda);
        Debug.Log("Agenda created: " + newAgenda.ToString());
        FirstSaveButton.gameObject.SetActive(false); // Fix: Use gameObject.SetActive(false) instead of SetActive(false)
    }

    private void SaveButtonClicked()
    {
        // update agenda object button logic here
    }




    private async System.Threading.Tasks.Task LoadAgendaData()
    {
        IWebRequestReponse response = await agendaApiClient.ReadAgendas();
        if (response is WebRequestData<List<Agenda>> agendasData)
        {
            List<Agenda> agendas = agendasData.Data;
            if (agendas.Count > 0)
            {
                Agenda agenda = agendas[0];
                Afspraak1LocatieText.text = agenda.location1;
                Afspraak1datumText.text = agenda.date1;
                Afspraak2LocatieText.text = agenda.location2;
                Afspraak2datumText.text = agenda.date2;
                Afspraak3LocatieText.text = agenda.location3;
                Afspraak3datumText.text = agenda.date3;

                // Show text fields
                Afspraak1LocatieText.gameObject.SetActive(true);
                Afspraak1datumText.gameObject.SetActive(true);
                Afspraak2LocatieText.gameObject.SetActive(true);
                Afspraak2datumText.gameObject.SetActive(true);
                Afspraak3LocatieText.gameObject.SetActive(true);
                Afspraak3datumText.gameObject.SetActive(true);

                // Hide input fields
                Afspraak1LocatieInput.gameObject.SetActive(false);
                Afspraak1datumInput.gameObject.SetActive(false);
                Afspraak2LocatieInput.gameObject.SetActive(false);
                Afspraak2datumInput.gameObject.SetActive(false);
                Afspraak3LocatieInput.gameObject.SetActive(false);
                Afspraak3datumInput.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.LogError("Failed to retrieve agendas.");
        }
    }

}
