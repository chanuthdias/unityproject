using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SignUpLoginFunction : MonoBehaviour
{
    public GameObject loginPanel;
    public InputField loginUsername;
    public InputField loginPassword;

    public GameObject signUpPanel;
    public InputField signUpUsername;
    public InputField signUpPassword;
    public InputField signUpConfirmPassword;
    
    public Text t;
    public Text errorText;

    public void GoToLogin()
    {
        loginPanel.SetActive(true);
        signUpPanel.SetActive(false);
        errorText.text = "";
    }

    public void GoToSignUp()
    {
        loginPanel.SetActive(false);
        signUpPanel.SetActive(true);
        errorText.text = "";
    }

    public void ResetSignUp()
    {
        signUpUsername.text = "";
        signUpPassword.text = "";
        signUpConfirmPassword.text = "";
    }

    public void ResetLogin()
    {
        loginUsername.text = "";
        loginPassword.text = "";
    }

    public void LoggedUserSession()
    {
        PlayerPrefs.SetString("LoggedUserSession", "true");
    }

    public void LogOut() 
    {
        PlayerPrefs.SetString("LoggedUserSession", "false");
        SceneManager.LoadScene("SignupScene");
    }

    public void Start()
    {
        if (PlayerPrefs.GetString("LoggedUserSession") == "true")
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    public void SignUpUser()
    {
        string username = signUpUsername.text;
        string password = signUpPassword.text;
        string confirmPassword = signUpConfirmPassword.text;

        if(username != string.Empty && password != string.Empty && confirmPassword != string.Empty)
        {
            if(password == confirmPassword)
            {
                //save new user here
                PlayerPrefs.SetString("Username", username);
                PlayerPrefs.SetString("Password", password);
                PlayerPrefs.SetString("ConfirmPassword", confirmPassword);
                GoToLogin();
            }
            else
            {
                ResetSignUp();
                errorText.text = "Password Missmatch";
            }
        }
        else
        {
            ResetSignUp();
            errorText.text = "please enter username, password and confirm password";
        }
    }

    public void LoginUser()
    {
        string savedUsername = PlayerPrefs.GetString("Username");
        string savedPassword = PlayerPrefs.GetString("Password");

        string username = loginUsername.text;
        string password = loginPassword.text;
        t.text = savedUsername + savedPassword + username + password;

        if (username != string.Empty && password != string.Empty)
        {
            if (username == savedUsername && password == savedPassword)
            {
                SceneManager.LoadScene("MainScene");
                loginPanel.SetActive(false);
                signUpPanel.SetActive(false);
                LoggedUserSession();
            }
            else
            {
                ResetLogin();
                errorText.text = "Password Missmatch";
            }
        }
        else
        {
            ResetLogin();
            errorText.text = "please enter username and password";
        }
    }
}
