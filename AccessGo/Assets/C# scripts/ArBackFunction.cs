using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArBackFunction : MonoBehaviour
{
    public Button ARBackButton;

    private void Start()
    {
        // Log information for debugging
        Debug.Log("Start method of ContinueButtonController is called.");

        // Check if the continueButton is not null before adding a listener
        if (ARBackButton != null)
        {
            // Log information for debugging
            Debug.Log("continueButton is not null. Adding a listener.");

            // Add a listener to the button click event
            ARBackButton.onClick.AddListener(LoadARBackScene);
        }
        else
        {
            // Log an error or handle the situation where the continueButton is null
            Debug.LogError("continueButton is not assigned in the Unity Editor.");
        }
    }

    private void LoadARBackScene()
    {
        // Log information for debugging
        Debug.Log("LoadSignupScene method is called.");

        // Load the "SignupScene" when the button is clicked
        SceneManager.LoadScene("MainScene");
    }
}
