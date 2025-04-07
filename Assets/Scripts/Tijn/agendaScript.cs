using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class agendascript : MonoBehaviour
{
    public GameObject agenda;

    //Buttons
    public Button agendaButton;
    public Button terugButton;
    public Button FirstSaveButton;
    public Button SaveButton;

    //Input fields
    public TMP_InputField Afspraak1LocatieInput;
    public TMP_InputField Afspraak1datumInput;
    public TMP_InputField Afspraak2LocatieInput;
    public TMP_InputField Afspraak2datumInput;
    public TMP_InputField Afspraak3LocatieInput;
    public TMP_InputField Afspraak3datumInput;

    //Text fields
    public TMP_Text Afspraak1LocatieText;
    public TMP_Text Afspraak1datumText;
    public TMP_Text Afspraak2LocatieText;
    public TMP_Text Afspraak2datumText;
    public TMP_Text Afspraak3LocatieText;
    public TMP_Text Afspraak3datumText;

    //Api client
    public AgendaApiClient agendaApiClient;

    // Reference to ProfielManagerScript
    public ProfielManagerScript profielManagerScript;

    void Start()
    {
        // Hide the agenda at the start
        agenda.SetActive(false);
        terugButton.onClick.AddListener(Sluiten);
        agendaButton.onClick.AddListener(Agendabutton);
        FirstSaveButton.onClick.AddListener(FirstSaveButtonClicked);
        SaveButton.onClick.AddListener(SaveButtonClicked);
    }

    public async void Agendabutton()
    {
        agenda.SetActive(true);
        // Get the profielkeuzeId from ProfielManagerScript
        string profielkeuzeId = profielManagerScript.SelectedProfielKeuzeId;
        if (string.IsNullOrEmpty(profielkeuzeId))
        {
            Debug.LogError("Profielkeuze ID is not set.");
            return;
        }

        // Load the data from the API
        Debug.Log($"Requesting agendas for profielkeuzeId: {profielkeuzeId}");
        IWebRequestReponse response = await agendaApiClient.ReadAgendas(profielkeuzeId);
        Debug.Log($"Received response: {response}");
        if (response is WebRequestData<List<Agenda>> agendasData)
        {
            List<Agenda> agendas = agendasData.Data;
            if (agendas != null && agendas.Count > 0)
            {
                Agenda agenda = agendas[0];
                Debug.Log(agenda.date1);
                Debug.Log(agenda.location1);
                Debug.Log(agenda.date2);
                Debug.Log(agenda.location2);
                Debug.Log(agenda.date3);
                Debug.Log(agenda.location3);

                Afspraak1LocatieText.text = agenda.location1;
                Afspraak1datumText.text = agenda.date1;
                Afspraak2LocatieText.text = agenda.location2;
                Afspraak2datumText.text = agenda.date2;
                Afspraak3LocatieText.text = agenda.location3;
                Afspraak3datumText.text = agenda.date3;

                // Set input fields to not active
                Afspraak1LocatieInput.gameObject.SetActive(false);
                Afspraak1datumInput.gameObject.SetActive(false);
                Afspraak2LocatieInput.gameObject.SetActive(false);
                Afspraak2datumInput.gameObject.SetActive(false);
                Afspraak3LocatieInput.gameObject.SetActive(false);
                Afspraak3datumInput.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("No agendas found or agendas list is null.");
            }
        }
        else
        {
            Debug.LogError("Failed to retrieve agendas.");
        }
    }

    public void Sluiten()
    {
        agenda.SetActive(false);

        // Clear text fields
        Afspraak1LocatieText.text = string.Empty;
        Afspraak1datumText.text = string.Empty;
        Afspraak2LocatieText.text = string.Empty;
        Afspraak2datumText.text = string.Empty;
        Afspraak3LocatieText.text = string.Empty;
        Afspraak3datumText.text = string.Empty;

        // Set input fields to active
        Afspraak1LocatieInput.gameObject.SetActive(true);
        Afspraak1datumInput.gameObject.SetActive(true);
        Afspraak2LocatieInput.gameObject.SetActive(true);
        Afspraak2datumInput.gameObject.SetActive(true);
        Afspraak3LocatieInput.gameObject.SetActive(true);
        Afspraak3datumInput.gameObject.SetActive(true);
    }

    public void ResetDagboek()
    {
        agenda.SetActive(false);
    }

    private async void FirstSaveButtonClicked()
    {
        // Get the profielkeuzeId from ProfielManagerScript
        string profielkeuzeId = profielManagerScript.SelectedProfielKeuzeId;
        if (string.IsNullOrEmpty(profielkeuzeId))
        {
            Debug.LogError("Profielkeuze ID is not set.");
            return;
        }

        // Get the values from the input fields
        Agenda newAgenda = new Agenda
        {
            date1 = Afspraak1datumInput.text,
            location1 = Afspraak1LocatieInput.text,
            date2 = Afspraak2datumInput.text,
            location2 = Afspraak2LocatieInput.text,
            date3 = Afspraak3datumInput.text,
            location3 = Afspraak3LocatieInput.text,
            ProfielKeuzeId = profielkeuzeId // Ensure the ProfielKeuzeId is set
        };

        // Post method for creating a new agenda
        Debug.Log($"Creating new agenda for profielkeuzeId: {profielkeuzeId} with data: {JsonUtility.ToJson(newAgenda)}");
        IWebRequestReponse response = await agendaApiClient.CreateAgenda(profielkeuzeId, newAgenda);
        Debug.Log($"Received response: {response}");
        if (response is WebRequestData<Agenda> createdAgenda)
        {
            Debug.Log("Agenda created successfully.");
        }
        else
        {
            Debug.LogError("Failed to create agenda.");
        }

        FirstSaveButton.gameObject.SetActive(false); // Fix: Use gameObject.SetActive(false) instead of SetActive(false)
    }

    private async void SaveButtonClicked()
    {
        // Get the profielkeuzeId from ProfielManagerScript
        string profielkeuzeId = profielManagerScript.SelectedProfielKeuzeId;
        if (string.IsNullOrEmpty(profielkeuzeId))
        {
            Debug.LogError("Profielkeuze ID is not set.");
            return;
        }

        // Get the values from the input fields
        Agenda updatedAgenda = new Agenda
        {
            date1 = Afspraak1datumInput.text,
            location1 = Afspraak1LocatieInput.text,
            date2 = Afspraak2datumInput.text,
            location2 = Afspraak2LocatieInput.text,
            date3 = Afspraak3datumInput.text,
            location3 = Afspraak3LocatieInput.text,
            ProfielKeuzeId = profielkeuzeId // Ensure the ProfielKeuzeId is set
        };

        // Put method for updating existing agenda
        string agendaId = "some-agenda-id"; // Replace with actual agenda ID
        Debug.Log($"Updating agenda for profielkeuzeId: {profielkeuzeId} with agendaId: {agendaId} and data: {JsonUtility.ToJson(updatedAgenda)}");
        IWebRequestReponse response = await agendaApiClient.UpdateAgenda(profielkeuzeId, agendaId, updatedAgenda);
        Debug.Log($"Received response: {response}");
        if (response is WebRequestData<Agenda> updatedAgendaData)
        {
            Debug.Log("Agenda updated successfully.");
        }
        else
        {
            Debug.LogError("Failed to update agenda.");
        }
    }
}
