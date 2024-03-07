using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToHome : MonoBehaviour
{
    public Button backButton;

    private void Start()
    {
        // Log information for debugging
        Debug.Log("Start method of ContinueButtonController is called.");

        // Check if the continueButton is not null before adding a listener
        if (backButton != null)
        {
            // Log information for debugging
            Debug.Log("continueButton is not null. Adding a listener.");

            // Add a listener to the button click event
            backButton.onClick.AddListener(LoadMainScene);
        }
        else
        {
            // Log an error or handle the situation where the continueButton is null
            Debug.LogError("continueButton is not assigned in the Unity Editor.");
        }
    }

    private void LoadMainScene()
    {
        // Log information for debugging
        Debug.Log("LoadSignupScene method is called.");

        // Load the "SignupScene" when the button is clicked
        SceneManager.LoadScene("MainScene");
    }
}
