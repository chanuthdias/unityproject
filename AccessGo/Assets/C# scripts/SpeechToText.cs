using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class SpeechToTextButton : MonoBehaviour
{
    // Add this script to the GameObject that represents your speech-to-text button


    public Button speechtotext;

    private void Start()
    {
        speechtotext.onClick.AddListener(SpeechToTextScene);
    }

    public void SpeechToTextScene()
    {
        // Load the new scene based on the provided sceneName
        SceneManager.LoadScene("SpeechToTextScene");
    }
}