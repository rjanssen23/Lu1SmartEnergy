using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProfielManager : MonoBehaviour
{
    // Input fields for profile creation
    public TMP_InputField nameInputField;
    public TMP_InputField ageInputField;

    // Buttons for character selection
    public Button characterButton1;
    public Button characterButton2;

    // Button to create profile
    public Button createProfileButton;

    // Panels for profile creation
    public GameObject profileCreationPanel;
    public GameObject MainMenuButtons;

    // Warning components
    public RawImage warningImage;
    public TextMeshProUGUI warningText;

    public List<Profiel> Profielen = new List<Profiel>();

    private string selectedCharacter = string.Empty;

    private void Start()
    {
        characterButton1.onClick.AddListener(() => SelectCharacter("Character1"));
        characterButton2.onClick.AddListener(() => SelectCharacter("Character2"));
        createProfileButton.onClick.AddListener(CreateProfile);

        // Hide warning components initially
        warningImage.gameObject.SetActive(false);
        warningText.gameObject.SetActive(false);
    }

    private void SelectCharacter(string character)
    {
        selectedCharacter = character;
        Debug.Log("Selected character: " + character);
    }

    private void CreateProfile()
    {
        string name = nameInputField.text;
        string age = ageInputField.text;

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(age) || string.IsNullOrEmpty(selectedCharacter))
        {
            Debug.Log("All fields must be filled. Profile creation failed.");
            warningImage.gameObject.SetActive(true);
            warningText.gameObject.SetActive(true);
            return;
        }

        Profiel profiel = new Profiel
        {
            name = name,
            age = age,
            character = selectedCharacter
        };

        Profielen.Add(profiel);
        Debug.Log("Profile created: " + name);
    }
}

public class Profiel
{
    public string name;
    public string age;
    public string character;
}




