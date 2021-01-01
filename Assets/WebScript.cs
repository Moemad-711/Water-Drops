using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class WebScript : MonoBehaviour
{
    public GameObject errorText;

    void Start()
    {
        errorText.SetActive(false);
    }

    public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("login_user", username);
        form.AddField("login_password", password);

        using (UnityWebRequest www = UnityWebRequest.Post("https://waterdrops1.000webhostapp.com/game/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                if (www.isNetworkError)
                {
                    errorText.GetComponent<TMPro.TextMeshProUGUI>().text = "No Internet Connection";
                    errorText.SetActive(true);
                }
                if(www.isHttpError)
                {
                    errorText.GetComponent<TMPro.TextMeshProUGUI>().text = "Invalid Username Or Password";
                    errorText.SetActive(true);
                }
            }

            else
            {
                Debug.Log(www.downloadHandler.text);
                string[] stages =  www.downloadHandler.text.Split(' ','-','\n');
                Debug.Log("stage1: " + stages[0] + " stage2: " + stages[1] + " stage3:" + stages[2]);
                PlayerPrefs.SetString("Username", username);
                PlayerPrefs.SetString("stage1", stages[0]);
                PlayerPrefs.SetString("stage2", stages[1]);
                PlayerPrefs.SetString("stage3", stages[2]);
                PlayerPrefs.Save();
                Debug.Log("stage1: " + PlayerPrefs.GetString("stage1") + " stage2: " + PlayerPrefs.GetString("stage2") + " stage3:" + PlayerPrefs.GetString("stage3"));

                SceneManager.LoadScene(3);

            }
        }
    }


    public IEnumerator Register(string username, string password)
    {

        WWWForm form = new WWWForm();
        form.AddField("login_user", username);
        form.AddField("login_password", password);

        using (UnityWebRequest www = UnityWebRequest.Post("https://waterdrops1.000webhostapp.com/game/signup.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                Debug.Log("WWW Error");
                if (www.isNetworkError)
                {
                    errorText.GetComponent<TMPro.TextMeshProUGUI>().text = "No Internet Connection";
                    errorText.SetActive(true);
                }
                if (www.isHttpError)
                {
                    errorText.GetComponent<TMPro.TextMeshProUGUI>().text = "Username already exits";
                    errorText.SetActive(true);
                }
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                Debug.Log("Registered");
               
                SceneManager.LoadScene(0);
            }
        }
    }
    public IEnumerator Logout()
    {
        WWWForm form = new WWWForm();

        using (UnityWebRequest www = UnityWebRequest.Post("https://waterdrops1.000webhostapp.com/game/logout.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                if (www.isNetworkError)
                {
                    errorText.GetComponent<TMPro.TextMeshProUGUI>().text = "No Internet Connection";
                    errorText.SetActive(true);
                }
                /*if (www.isHttpError)
                {
                    errorText.GetComponent<TMPro.TextMeshProUGUI>().text = "Invalid Username Or Password";
                    errorText.SetActive(true);
                }*/
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                SceneManager.LoadScene(0);
            }
        }
    }

    public IEnumerator FirstStageUpdate()
    {
        WWWForm form = new WWWForm();

        using (UnityWebRequest www = UnityWebRequest.Post("https://waterdrops1.000webhostapp.com/game/stage_one_increment_level.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                if (www.isNetworkError)
                {
                    errorText.GetComponent<TMPro.TextMeshProUGUI>().text = "No Internet Connection";
                    errorText.SetActive(true);
                }
                if (www.isHttpError)
                {
                    // LoginError.errorText.text = "Invalid Username or Password";
                    //LoginError.ShowErrorText();
                }
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                PlayerPrefs.SetString("Stage1", www.downloadHandler.text);
                PlayerPrefs.Save();
                SceneManager.LoadScene(0);
            }
        }
    }


    public IEnumerator SecondStageUpdate()
    {
        WWWForm form = new WWWForm();

        using (UnityWebRequest www = UnityWebRequest.Post("https://waterdrops1.000webhostapp.com/game/stage_two_increment_level.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                if (www.isNetworkError)
                {
                    errorText.GetComponent<TMPro.TextMeshProUGUI>().text = "No Internet Connection";
                    errorText.SetActive(true);
                }
                if (www.isHttpError)
                {
                    // LoginError.errorText.text = "Invalid Username or Password";
                    //LoginError.ShowErrorText();
                }
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                PlayerPrefs.SetString("Stage2", www.downloadHandler.text);
                PlayerPrefs.Save();
                SceneManager.LoadScene(0);
            }
        }
    }

    public IEnumerator ThirdStageUpdate()
    {
        WWWForm form = new WWWForm();

        using (UnityWebRequest www = UnityWebRequest.Post("https://waterdrops1.000webhostapp.com/game/stage_three_increment_level.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                if (www.isNetworkError)
                {
                    errorText.GetComponent<TMPro.TextMeshProUGUI>().text = "No Internet Connection";
                    errorText.SetActive(true);
                }
                if (www.isHttpError)
                {
                    // LoginError.errorText.text = "Invalid Username or Password";
                    //LoginError.ShowErrorText();
                }
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                PlayerPrefs.SetString("Stage3", www.downloadHandler.text);
                PlayerPrefs.Save();
                SceneManager.LoadScene(0);
            }
        }
    }
}
