using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DagboekScript : MonoBehaviour
{
    public Button DagboekOpen;
    public Button DagboekClose;

    // Dagboek
    [Header("Dagboek")]
    public GameObject Dagboek;
    [SerializeField] private GameObject[] Paginas;
    [SerializeField] private Button[] VolgendeButtons;
    [SerializeField] private Button[] TerugButtons;

    // Dagboek
    [Header("PaginaInhoud")]
    public TextMeshProUGUI[] PaginaInhoud;
    public TMP_InputField[] PaginaInvoer;

    // Api client
    [Header("Api zooi")]
    public DagboekApiClient DagboekApiClient;
    public ProfielManagerScript profielManagerScript;
    public Button FirstSaveButton;
    public Button SaveButton;

    // Class-level variable to store the dagboekId
    private string dagboekId;

    private void Start()
    {
        DagboekOpen.onClick.AddListener(OpenDagboek);
        DagboekClose.onClick.AddListener(CloseDagboek);
        FirstSaveButton.onClick.AddListener(FirstSaveButtonClicked);
        SaveButton.onClick.AddListener(SaveButtonClicked);

        // Add listeners to the buttons
        for (int i = 0; i < VolgendeButtons.Length; i++)
        {
            int index = i; // Capture the current index
            VolgendeButtons[index].onClick.AddListener(() => NextPage(index));
        }
        for (int i = 0; i < TerugButtons.Length; i++)
        {
            int index = i; // Capture the current index
            TerugButtons[index].onClick.AddListener(() => PreviousPage(index));
        }
    }

    private async void OpenDagboek()
    {
        Dagboek.SetActive(true);

        // Get the profielkeuzeId from ProfielManagerScript
        string profielkeuzeId = profielManagerScript.SelectedProfielKeuzeId;
        if (string.IsNullOrEmpty(profielkeuzeId))
        {
            Debug.LogError("Profielkeuze ID is not set.");
            return;
        }

        // Load the data from the API
        Debug.Log($"Requesting dagboeken for profielkeuzeId: {profielkeuzeId}");
        IWebRequestReponse response = await DagboekApiClient.ReadDagboeken(profielkeuzeId);
        Debug.Log($"Received response: {response}");

        if (response is WebRequestData<List<Dagboek>> dagboekenData)
        {
            List<Dagboek> dagboeken = dagboekenData.Data;
            if (dagboeken != null && dagboeken.Count > 0)
            {
                Dagboek dagboek = dagboeken[0];
                Debug.Log($"Loaded Dagboek: {JsonUtility.ToJson(dagboek)}");

                // Store the dagboekId
                dagboekId = dagboek.id;

                // Ensure PaginaInhoud array has enough elements
                if (PaginaInhoud.Length >= 4)
                {
                    // Set text fields
                    PaginaInhoud[0].text = dagboek.dagboekBladzijde1 ?? string.Empty;
                    PaginaInhoud[1].text = dagboek.dagboekBladzijde2 ?? string.Empty;
                    PaginaInhoud[2].text = dagboek.dagboekBladzijde3 ?? string.Empty;
                    PaginaInhoud[3].text = dagboek.dagboekBladzijde4 ?? string.Empty;

                    Debug.Log("Text fields updated successfully.");
                }
                else
                {
                    Debug.LogError("PaginaInhoud array does not have enough elements to display all pages.");
                }

                // Hide input fields
                foreach (var inputField in PaginaInvoer)
                {
                    inputField.gameObject.SetActive(false);
                }

                // Show the Save button and hide the First Save button
                SaveButton.gameObject.SetActive(true);
                FirstSaveButton.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("No dagboeken found or dagboeken list is null.");

                // Show the First Save button and hide the Save button
                FirstSaveButton.gameObject.SetActive(true);
                SaveButton.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.LogError("Failed to retrieve dagboeken. Response is not of expected type.");

            // Show the First Save button and hide the Save button
            FirstSaveButton.gameObject.SetActive(true);
            SaveButton.gameObject.SetActive(false);
        }
    }

    private void CloseDagboek()
    {
        Dagboek.SetActive(false);

        // Hide input fields
        foreach (var inputField in PaginaInvoer)
        {
            inputField.gameObject.SetActive(false);
        }

        // Hide both Save and First Save buttons
        SaveButton.gameObject.SetActive(false);
        FirstSaveButton.gameObject.SetActive(false);

        // Note: Do not clear the text fields here to ensure data is reloaded when reopened
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
        Dagboek newDagboek = new Dagboek
        {
            dagboekBladzijde1 = PaginaInvoer[0].text,
            dagboekBladzijde2 = PaginaInvoer[1].text,
            dagboekBladzijde3 = PaginaInvoer[2].text,
            dagboekBladzijde4 = PaginaInvoer[3].text,
            profielKeuzeId = profielkeuzeId // Ensure the ProfielKeuzeId is set
        };

        // Post method for creating a new dagboek
        Debug.Log($"Creating new dagboek for profielkeuzeId: {profielkeuzeId} with data: {JsonUtility.ToJson(newDagboek)}");
        IWebRequestReponse response = await DagboekApiClient.CreateDagboek(profielkeuzeId, newDagboek);
        Debug.Log($"Received response: {response}");
        if (response is WebRequestData<Dagboek> createdDagboek)
        {
            Debug.Log("Dagboek created successfully.");
        }
        else
        {
            Debug.LogError("Failed to create dagboek.");
        }

        FirstSaveButton.gameObject.SetActive(false);
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

        // Ensure the dagboekId is set
        if (string.IsNullOrEmpty(dagboekId))
        {
            Debug.LogError("Dagboek ID is not set.");
            return;
        }

        // Get the values from the input fields
        Dagboek updatedDagboek = new Dagboek
        {
            dagboekBladzijde1 = PaginaInvoer[0].text,
            dagboekBladzijde2 = PaginaInvoer[1].text,
            dagboekBladzijde3 = PaginaInvoer[2].text,
            dagboekBladzijde4 = PaginaInvoer[3].text,
            profielKeuzeId = profielkeuzeId // Ensure the ProfielKeuzeId is set
        };

        // Put method for updating existing dagboek
        Debug.Log($"Updating dagboek for profielkeuzeId: {profielkeuzeId} with dagboekId: {dagboekId} and data: {JsonUtility.ToJson(updatedDagboek)}");
        IWebRequestReponse response = await DagboekApiClient.UpdateDagboek(dagboekId, updatedDagboek);
        Debug.Log($"Received response: {response}");
        if (response is WebRequestData<Dagboek> updatedDagboekData)
        {
            Debug.Log("Dagboek updated successfully.");
        }
        else
        {
            Debug.LogError("Failed to update dagboek.");
        }

        // Hide input fields
        foreach (var inputField in PaginaInvoer)
        {
            inputField.gameObject.SetActive(false);
        }

        // Set text fields to the updated values
        PaginaInhoud[0].text = updatedDagboek.dagboekBladzijde1;
        PaginaInhoud[1].text = updatedDagboek.dagboekBladzijde2;
        PaginaInhoud[2].text = updatedDagboek.dagboekBladzijde3;
        PaginaInhoud[3].text = updatedDagboek.dagboekBladzijde4;

        // Show text fields
        foreach (var textField in PaginaInhoud)
        {
            textField.gameObject.SetActive(true);
        }
    }

    private void NextPage(int index)
    {
        if (index < Paginas.Length - 1)
        {
            // Deactivate all pages
            for (int i = 0; i < Paginas.Length; i++)
            {
                Paginas[i].SetActive(false);
            }

            // Activate the next page
            Paginas[index + 1].SetActive(true);

            // Update TerugButtons visibility
            for (int i = 0; i < TerugButtons.Length; i++)
            {
                TerugButtons[i].gameObject.SetActive(false);
            }
            TerugButtons[index + 1].gameObject.SetActive(true);
        }
    }

    private void PreviousPage(int index)
    {
        if (index > 0)
        {
            // Deactivate all pages
            for (int i = 0; i < Paginas.Length; i++)
            {
                Paginas[i].SetActive(false);
            }

            // Activate the previous page
            Paginas[index - 1].SetActive(true);

            // Update TerugButtons visibility
            for (int i = 0; i < TerugButtons.Length; i++)
            {
                TerugButtons[i].gameObject.SetActive(false);
            }
            TerugButtons[index - 1].gameObject.SetActive(true);
        }
    }
}
