using BrainCheck;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextToSpeechHandler : MonoBehaviour
{
    public InputField textToSpeech;
    DemoScript demoScript;

    // Start is called before the first frame update
    void Start()
    {
        demoScript = GetComponent<DemoScript>();
    }

    // Update is called once per frame
    void Update()
    {
        demoScript.textToConvet = textToSpeech.text;
    }
}
