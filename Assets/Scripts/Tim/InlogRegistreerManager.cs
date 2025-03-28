using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InlogRegistreerManager : MonoBehaviour
{
    // scenes
    public GameObject Scene1;
    public GameObject Scene2;

    // Input fields for registration
    public TMP_InputField registerEmailInputField;
    public TMP_InputField registerPasswordInputField;

    // Input fields for login
    public TMP_InputField loginEmailInputField;
    public TMP_InputField loginPasswordInputField;

    public Button loginExit;
    public Button registerExit;

    public Button registerButton;
    public Button loginButton;

    public Button gaTerug;
    public Button gaDoorZonderAccount;
    public Toggle showPasswordToggleInlog; // Toggle om het wachtwoord te verbergen of weer te geven
    public Toggle showPasswordToggleRegister;
    //public UserApiClient userApiClient;

    // Buttons to switch between login and register screens
    public Button switchToLoginButton;
    public Button switchToRegisterButton;
    public Button StartGame;

    // Panels for login and registration
    public GameObject loginPanel;
    public GameObject registerPanel;
    public GameObject MainMenuButtons;
    public GameObject NotLoggedInWarning;

    // Warning components
    public RawImage passwordWarningImage;
    public TextMeshProUGUI passwordWarningText;

    public List<User> Users = new List<User>();

    private bool isLoggedIn = false;

    private void Start()
    {
        registerButton.onClick.AddListener(Register);
        loginButton.onClick.AddListener(Login);
        showPasswordToggleInlog.onValueChanged.AddListener(TogglePasswordVisibilityInlog);
        showPasswordToggleRegister.onValueChanged.AddListener(TogglePasswordVisibilityRegister);
        loginPasswordInputField.contentType = TMP_InputField.ContentType.Password; // Standaard wachtwoord verbergen
        registerPasswordInputField.contentType = TMP_InputField.ContentType.Password; // Standaard wachtwoord verbergen

        switchToLoginButton.onClick.AddListener(ShowLoginPanel);
        switchToRegisterButton.onClick.AddListener(ShowRegisterPanel);

        loginExit.onClick.AddListener(HideLoginPanel);
        registerExit.onClick.AddListener(HideRegisterPanel);

        StartGame.onClick.AddListener(StartGameHandler);
        gaTerug.onClick.AddListener(HideNotLoggedInWarning);
        gaDoorZonderAccount.onClick.AddListener(ProceedWithoutAccount);

        registerPasswordInputField.onValueChanged.AddListener(ValidateRegisterPassword);
        ValidateRegisterPassword(registerPasswordInputField.text); // Initial validation

        // Hide warning components initially
        passwordWarningImage.gameObject.SetActive(false);
        passwordWarningText.gameObject.SetActive(false);
    }

    private void Register()
    {
        string email = registerEmailInputField.text;
        string password = registerPasswordInputField.text;

        if (password.Length < 1 || password.Length > 16)
        {
            Debug.Log("Password must be between 1 and 16 characters. Registration failed.");
            passwordWarningImage.gameObject.SetActive(true);
            passwordWarningText.gameObject.SetActive(true);
            return;
        }

        User user = new User
        {
            email = email,
            password = password
        };

        Users.Add(user);
        Debug.Log("User registered: " + email);
    }

    private void Login()
    {
        string email = loginEmailInputField.text;
        string password = loginPasswordInputField.text;

        User user = Users.Find(u => u.email == email && u.password == password);

        if (user != null)
        {
            isLoggedIn = true;
            Debug.Log("Login success!");
        }
        else
        {
            Debug.Log("Login failed: Invalid email or password");
        }
    }

    private void ShowLoginPanel()
    {
        Debug.Log("Showing login panel");
        loginPanel.SetActive(true);
        registerPanel.SetActive(false);
        MainMenuButtons.SetActive(false);
    }

    private void ShowRegisterPanel()
    {
        Debug.Log("Showing register panel");
        loginPanel.SetActive(false);
        registerPanel.SetActive(true);
        MainMenuButtons.SetActive(false);
    }

    private void HideLoginPanel()
    {
        Debug.Log("Hiding login panel");
        loginPanel.SetActive(false);
        MainMenuButtons.SetActive(true);
    }

    private void HideRegisterPanel()
    {
        Debug.Log("Hiding register panel");
        registerPanel.SetActive(false);
        MainMenuButtons.SetActive(true);
    }

    private void ShowNotLoggedInWarning()
    {
        Debug.Log("Showing not logged in warning");
        NotLoggedInWarning.SetActive(true);
    }

    private void HideNotLoggedInWarning()
    {
        Debug.Log("Hiding not logged in warning");
        NotLoggedInWarning.SetActive(false);
    }

    private void ProceedWithoutAccount()
    {
        Debug.Log("Proceeding without account");
        Scene1.SetActive(false);
        Scene2.SetActive(true);
    }

    private void ProceedWithAccount()
    {
        Debug.Log("Proceeding with account");
        Scene1.SetActive(false);
        Scene2.SetActive(true);
    }

    private void StartGameHandler()
    {
        if (isLoggedIn)
        {
            ProceedWithAccount();
        }
        else
        {
            ShowNotLoggedInWarning();
        }
    }

    private void TogglePasswordVisibilityInlog(bool isVisible)
    {
        loginPasswordInputField.contentType = isVisible ? TMP_InputField.ContentType.Standard : TMP_InputField.ContentType.Password;
        loginPasswordInputField.ForceLabelUpdate(); // Forceer een update om de wijziging door te voeren
    }

    private void TogglePasswordVisibilityRegister(bool isVisible)
    {
        registerPasswordInputField.contentType = isVisible ? TMP_InputField.ContentType.Standard : TMP_InputField.ContentType.Password;
        registerPasswordInputField.ForceLabelUpdate(); // Forceer een update om de wijziging door te voeren
    }

    private void ValidateRegisterPassword(string password)
    {
        if (password.Length < 1 || password.Length > 16)
        {
            passwordWarningImage.gameObject.SetActive(true);
            passwordWarningText.gameObject.SetActive(true);
        }
        else
        {
            passwordWarningImage.gameObject.SetActive(false);
            passwordWarningText.gameObject.SetActive(false);
        }
    }
}

[Serializable]
public class User
{
    public string email;
    public string password;
}





//public async void Register()
//{
//    string email = emailInputField.text;
//    string password = passwordInputField.text;

//    User user = new User
//    {
//        email = email,
//        password = password
//    };

//    try
//    {
//        IWebRequestReponse webRequestResponse = await userApiClient.Register(user);

//        switch (webRequestResponse)
//        {
//            case WebRequestData<string> dataResponse:
//                Debug.Log("Register success!");
//                break;
//            case WebRequestError errorResponse:
//                string errorMessage = errorResponse.ErrorMessage;
//                Debug.Log("Register error: " + errorMessage);
//                break;
//            default:
//                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
//        }
//    }
//    catch (Exception ex)
//    {
//        Debug.LogError("Register exception: " + ex.Message);
//    }
//}

//public async void Login()
//{
//    string email = emailInputField.text;
//    string password = passwordInputField.text;

//    User user = new User
//    {
//        email = email,
//        password = password
//    };

//    try
//    {
//        IWebRequestReponse webRequestResponse = await userApiClient.Login(user);

//        switch (webRequestResponse)
//        {
//            case WebRequestData<string> dataResponse:
//                Debug.Log("Login success!");
//                SceneLoginRegister.SetActive(false); // Verberg het login/register paneel
//                ChooseEnvironment.SetActive(true);  // Toon het choose environment paneel
//                break;
//            case WebRequestError errorResponse:
//                string errorMessage = errorResponse.ErrorMessage;
//                Debug.Log("Login error: " + errorMessage);
//                break;
//            default:
//                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
//        }
//    }
//    catch (Exception ex)
//    {
//        Debug.LogError("Login exception: " + ex.Message);
//    }
//}
