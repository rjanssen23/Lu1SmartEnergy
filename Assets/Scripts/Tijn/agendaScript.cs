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

    //Delete buttons
    public Button DeleteLocatie1;
    public Button DeleteDatum1;
    public Button DeleteLocatie2;
    public Button DeleteDatum2;
    public Button DeleteLocatie3;
    public Button DeleteDatum3;

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

    // Class-level variable to store the agendaId
    private string agendaId;

    void Start()
    {
        // Hide the agenda at the start
        agenda.SetActive(false);
        terugButton.onClick.AddListener(Sluiten);
        agendaButton.onClick.AddListener(Agendabutton);
        FirstSaveButton.onClick.AddListener(FirstSaveButtonClicked);
        SaveButton.onClick.AddListener(SaveButtonClicked);

        // Add listeners for delete buttons
        DeleteLocatie1.onClick.AddListener(ActivateLocatie1Input);
        DeleteDatum1.onClick.AddListener(ActivateDatum1Input);
        DeleteLocatie2.onClick.AddListener(ActivateLocatie2Input);
        DeleteDatum2.onClick.AddListener(ActivateDatum2Input);
        DeleteLocatie3.onClick.AddListener(ActivateLocatie3Input);
        DeleteDatum3.onClick.AddListener(ActivateDatum3Input);
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
        Afspraak1datumInput.gameObject.SetActive(true);
        Afspraak1LocatieInput.gameObject.SetActive(true);
        Afspraak2datumInput.gameObject.SetActive(true);
        Afspraak2LocatieInput.gameObject.SetActive(true);
        Afspraak3datumInput.gameObject.SetActive(true);
        Afspraak3LocatieInput.gameObject.SetActive(true);

        // Create a new agenda
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
            agendaId = createdAgenda.Data.id;
        }
        else
        {
            Debug.LogError("Failed to create agenda.");
        }

        // Load the data from the API
        Debug.Log($"Requesting agendas for profielkeuzeId: {profielkeuzeId}");
        response = await agendaApiClient.ReadAgendas(profielkeuzeId);
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

                // Store the agendaId
                agendaId = agenda.id;

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
                FirstSaveButton.gameObject.SetActive(false);
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
        Afspraak1LocatieInput.gameObject.SetActive(false);
        Afspraak1datumInput.gameObject.SetActive(false);
        Afspraak2LocatieInput.gameObject.SetActive(false);
        Afspraak2datumInput.gameObject.SetActive(false);
        Afspraak3LocatieInput.gameObject.SetActive(false);
        Afspraak3datumInput.gameObject.SetActive(false);
    }

    private async void FirstSaveButtonClicked()
    {
        // This method is no longer needed for creating a new agenda
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

        // Ensure the agendaId is set
        if (string.IsNullOrEmpty(agendaId))
        {
            Debug.LogError("Agenda ID is not set.");
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
        // Set input fields to not active
        Afspraak1LocatieInput.gameObject.SetActive(false);
        Afspraak1datumInput.gameObject.SetActive(false);
        Afspraak2LocatieInput.gameObject.SetActive(false);
        Afspraak2datumInput.gameObject.SetActive(false);
        Afspraak3LocatieInput.gameObject.SetActive(false);
        Afspraak3datumInput.gameObject.SetActive(false);
        // Set text fields to the updated values
        Afspraak1LocatieText.text = updatedAgenda.location1;
        Afspraak1datumText.text = updatedAgenda.date1;
        Afspraak2LocatieText.text = updatedAgenda.location2;
        Afspraak2datumText.text = updatedAgenda.date2;
        Afspraak3datumText.text = updatedAgenda.date3;
        Afspraak3LocatieText.text = updatedAgenda.location3;
        // Set the text active
        Afspraak1LocatieText.gameObject.SetActive(true);
        Afspraak1datumText.gameObject.SetActive(true);
        Afspraak2LocatieText.gameObject.SetActive(true);
        Afspraak2datumText.gameObject.SetActive(true);
        Afspraak3LocatieText.gameObject.SetActive(true);
        Afspraak3datumText.gameObject.SetActive(true);
    }

    private void ActivateLocatie1Input()
    {
        Afspraak1LocatieInput.gameObject.SetActive(true);
        Afspraak1LocatieText.gameObject.SetActive(false);
    }

    private void ActivateDatum1Input()
    {
        Afspraak1datumInput.gameObject.SetActive(true);
        Afspraak1datumText.gameObject.SetActive(false);
    }

    private void ActivateLocatie2Input()
    {
        Afspraak2LocatieInput.gameObject.SetActive(true);
        Afspraak2LocatieText.gameObject.SetActive(false);
    }

    private void ActivateDatum2Input()
    {
        Afspraak2datumInput.gameObject.SetActive(true);
        Afspraak2datumText.gameObject.SetActive(false);
    }

    private void ActivateLocatie3Input()
    {
        Afspraak3LocatieInput.gameObject.SetActive(true);
        Afspraak3LocatieText.gameObject.SetActive(false);
    }

    private void ActivateDatum3Input()
    {
        Afspraak3datumInput.gameObject.SetActive(true);
        Afspraak3datumText.gameObject.SetActive(false);
    }
}
