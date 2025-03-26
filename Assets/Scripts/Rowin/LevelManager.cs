using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject Scene2;
    public GameObject Scene3;
    public GameObject Scene4;

    public Button StartButton;
    public Button BackButton;

    void Start()
    {
        // Voeg event listeners toe aan de knoppen
        StartButton.onClick.AddListener(ChangeSceneToStart);
        BackButton.onClick.AddListener(ChangeSceneToBack);

        // Initialiseer de scenes
        ResetScenes();
    }

    void ResetScenes()
    {
        Scene2.SetActive(true);
        Scene3.SetActive(false);
        Scene4.SetActive(false);
    }

    public void ChangeSceneToBack()
    {
        Scene2.SetActive(true);
        Scene3.SetActive(false);
        Scene4.SetActive(false);
    }

    public void ChangeSceneToStart()
    {
        Scene2.SetActive(false);
        Scene3.SetActive(false);
        Scene4.SetActive(true);
    }
}




