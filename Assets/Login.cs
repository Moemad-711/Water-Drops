using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login : MonoBehaviour
{
    public TMPro.TMP_InputField UsernameInput;
    public TMPro.TMP_InputField PasswordInput;
    // Start is called before the first frame update

    public void LogIn()
    {
        StartCoroutine(MainScript.Instance.Web.Login(UsernameInput.text, PasswordInput.text));
    }
}
