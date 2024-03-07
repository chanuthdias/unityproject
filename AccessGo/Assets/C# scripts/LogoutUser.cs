using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoutUser : MonoBehaviour
{
    public void LogOut()
    {
        PlayerPrefs.SetString("LoggedUserSession", "false");
        SceneManager.LoadScene("SignupScene");
    }

}
