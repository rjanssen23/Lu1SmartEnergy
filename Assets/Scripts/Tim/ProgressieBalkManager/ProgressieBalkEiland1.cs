using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks; // Add this for async/await
using static ExampleApp;
using TMPro;

public class ProgressBarManager : MonoBehaviour
{
    public Slider progressBar;
    public Image[] bolletjes;
    public int totalVakjes = 6;
    private int completedVakjes = 0;
    private bool[] vakjesAfrondStatus;
    private Color[] origineleKleuren;
    public SchatkistAnimatieController schatkistAnimatieController;

    void Start()
    {
        // Initialiseer de slider
        progressBar.maxValue = totalVakjes;
        progressBar.value = completedVakjes;
        vakjesAfrondStatus = new bool[totalVakjes];
        origineleKleuren = new Color[bolletjes.Length];

        // Sla de oorspronkelijke kleuren van de bolletjes op
        for (int i = 0; i < bolletjes.Length; i++)
        {
            origineleKleuren[i] = bolletjes[i].color;
        }

        UpdateBolletjes();
    }

    public async Task CreateAndLoadAgenda(string profielkeuzeId, TMP_InputField Afspraak1datumInput, TMP_InputField Afspraak1LocatieInput, TMP_InputField Afspraak2datumInput, TMP_InputField Afspraak2LocatieInput, TMP_InputField Afspraak3datumInput, TMP_InputField Afspraak3LocatieInput, TMP_Text Afspraak1LocatieText, TMP_Text Afspraak1datumText, TMP_Text Afspraak2LocatieText, TMP_Text Afspraak2datumText, TMP_Text Afspraak3LocatieText, TMP_Text Afspraak3datumText, Button FirstSaveButton, AgendaApiClient agendaApiClient)
    {
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
            string agendaId = createdAgenda.Data.id;
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

                // Store the agendaId
                string agendaId = agenda.id;

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

    public void VakjeAfronden(int vakjeIndex)
    {
        if (vakjeIndex < 0 || vakjeIndex >= totalVakjes)
        {
            Debug.LogError("Ongeldige vakje index");
            return;
        }

        if (!vakjesAfrondStatus[vakjeIndex])
        {
            // Markeer het vakje als afgerond
            vakjesAfrondStatus[vakjeIndex] = true;
            // Verhoog het aantal voltooide vakjes
            completedVakjes++;
            // Update de slider waarde
            progressBar.value = completedVakjes;
            UpdateBolletjes();

            // Verander de kleur van de slider naar groen
            progressBar.fillRect.GetComponent<Image>().color = Color.green;

            // Start de schatkist animatie als het laatste vakje is afgerond
            if (completedVakjes == totalVakjes)
            {
                schatkistAnimatieController.StartAnimatie();
            }
        }
    }

    void UpdateBolletjes()
    {
        for (int i = 0; i < bolletjes.Length; i++)
        {
            if (i < completedVakjes)
            {
                bolletjes[i].color = origineleKleuren[i]; // Zet terug naar oorspronkelijke kleur
            }
            else
            {
                bolletjes[i].color = Color.gray; // Zet naar grijs
            }
        }
    }
}

