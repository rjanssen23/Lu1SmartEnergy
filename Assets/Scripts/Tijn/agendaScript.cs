using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

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

    public AgendaApiClient agendaApiClient;

    void Start()
    {
        ResetDagboek();
        terugButton.onClick.AddListener(terugButtonClicked);
        agendaButton.onClick.AddListener(dagboekbutton);
    }

    public void ResetDagboek()
    {
        agenda.SetActive(false);
    }

    public async void dagboekbutton()
    {
        agenda.SetActive(true);
        await LoadAgendaData();
    }

    public void terugButtonClicked()
    {
        ResetDagboek();
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
                Afspraak1Locatie.text = agenda.location1;
                Afspraak1datum.text = agenda.date1;
                Afspraak2Locatie.text = agenda.location2;
                Afspraak2datum.text = agenda.date2;
                Afspraak3Locatie.text = agenda.location3;
                Afspraak3datum.text = agenda.date3;
            }
        }
        else
        {
            Debug.LogError("Failed to retrieve agendas.");
        }
    }
}
