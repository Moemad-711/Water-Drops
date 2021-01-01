using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    private string stage1Level;
    private string stage2Level;
    private string stage3Level;

    //private string currentstage;

    public void loadSceneBySceneIndex(int SceneIndex)
    {
        if (SceneIndex == 4 || SceneIndex == 5)
        {
            //stage = "Stage1";
            if(SceneIndex == 4)
            {
                stage1Level = PlayerPrefs.GetString("stage1");
                if (int.Parse(stage1Level) >= 0 )
                {
                    SceneManager.LoadScene(4);

                }

            }

            if (SceneIndex == 5)
            {

                stage1Level = PlayerPrefs.GetString("stage1");

                if (int.Parse(stage1Level) >= 1)
                {
                    SceneManager.LoadScene(5);

                }

            }

        }

        if (SceneIndex == 6 || SceneIndex == 7)
        {
            //stage = "Stage1";
            if (SceneIndex == 6)
            {
                stage1Level = PlayerPrefs.GetString("stage1");
                stage2Level = PlayerPrefs.GetString("stage2");
                if ((int.Parse(stage1Level) >= 2) && (int.Parse(stage2Level) >= 0))
                {
                    //currentstage = "Stage2";

                    SceneManager.LoadScene(6);

                }

            }

            if (SceneIndex == 7)
            {
                if ((int.Parse(PlayerPrefs.GetString("stage1")) >= 2) && (int.Parse(PlayerPrefs.GetString("stage2")) >= 1))
                {
                    SceneManager.LoadScene(7);

                }

            }
        }
            if (SceneIndex == 8 || SceneIndex == 9)
            {
                //stage = "Stage1";
                if (SceneIndex == 8)
                {
                    if ((int.Parse(PlayerPrefs.GetString("stage2")) >= 2) && (int.Parse(PlayerPrefs.GetString("stage3")) >= 0))
                    {
                        //currentstage = "Stage2";

                        SceneManager.LoadScene(8);

                    }

                }

                if (SceneIndex == 9)
                {
                    if ((int.Parse(PlayerPrefs.GetString("stage2")) >= 2) && (int.Parse(PlayerPrefs.GetString("Sstage3")) >= 1))
                    {
                        SceneManager.LoadScene(9);

                    }

                }

            }
        //SceneManager.LoadScene(SceneIndex);
        //StartCoroutine(LoadSceneAsynchronously(SceneIndex));
    }

    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    

    public void LoadWelcomeScene()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadSignUpScene()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLoginScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(3);
    }

    public static void LoadMainMenuStatic()
    {
        SceneManager.LoadScene(3);
    }


}

