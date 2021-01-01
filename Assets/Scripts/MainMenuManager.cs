using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuManager : MonoBehaviour
{
    public GameObject homeBackground;
    public GameObject playBackground;
    public GameObject learnBackground;
    public GameObject homeButton;
    public GameObject playButton;
    public GameObject learnButton;

    public GameObject sideMenuButton;
    public GameObject sideMenuBackButton;
    public GameObject sideMenuBody;

    public GameObject menuBody;
    public GameObject homeBody;
    public GameObject playBody;
    public GameObject learnBody;

    public TMPro.TextMeshProUGUI tipText;
    public string[] tipsStrings;

    public TMPro.TextMeshProUGUI quistionText;
    public TMPro.TextMeshProUGUI quistionHeader;
    public TMPro.TextMeshProUGUI quistionResult;
    public TMPro.TextMeshProUGUI explantionQuistionText;
    public TMPro.TextMeshProUGUI explanationQuistionHeader;
    public TMPro.TextMeshProUGUI explanation;
    public TMPro.TextMeshProUGUI rightAnswer;

    public string[] quizStirngs;
    public string[] quizHeaders;
    public string[] explanations;
    public bool[] quizAnswers;
    public Button trueButton;
    public Button falseButton;
    private int shownQuizIndex;
    private int quizMaxIndex;
    

    public GameObject sideButtonsMenuBody;
    public GameObject challengesBody;
    public GameObject appearanceBody;
    public GameObject dailyQuizBody;
    public GameObject settingBody;
    public GameObject profileBody;
    public GameObject explanationBody;
    

    public GameObject StagesMap;
    public GameObject UndergroundLevelBody;
    public GameObject CastleLevelBody;
    public GameObject GardenLevelbody;


    public GameObject TopSideButton;
    public GameObject BotSideButton;
    public TMPro.TextMeshProUGUI topSideButtonText;
    public TMPro.TextMeshProUGUI botsSideButtonText;
    public TMPro.TextMeshProUGUI helloToUserText;

    public Image Progress;
    private int progressAvg;

    public float scrollingSpeed;

    


    bool moveToHome;
    bool moveToPlay;
    bool moveToLearn;
    bool atHome;
    bool atPlay;
    bool atLearn;
    bool sideMenuOpened;
    bool topSideButtonClicked;
    bool botSideButtonClicked;
    bool atStagesMap;

    // Start is called before the first frame update
    void Start()
    {
        BackgroundPositioning();
        tipText.text = tipsStrings[Random.Range(0, tipsStrings.Length)];
        StagesMap.SetActive(false);
        atStagesMap = false;
        UndergroundLevelBody.SetActive(false);
        CastleLevelBody.SetActive(false);
        GardenLevelbody.SetActive(false);
        sideButtonsMenuBody.SetActive(false);
        sideMenuBackButton.SetActive(false);
        moveToHome = true;
        moveToLearn = false;
        moveToPlay = false;
        atHome = false;
        atLearn = false;
        atPlay = false;
        sideMenuOpened = false;
        topSideButtonClicked = false;
        botSideButtonClicked = false;
        quistionResult.gameObject.SetActive(false);
        helloToUserText.text = PlayerPrefs.GetString("Username");
        Progress.fillAmount = 0;


    }

    // Update is called once per frame
    void Update()
    {
        //ChangeButtonColor();
        if (moveToHome == true)
        {
            Camera.main.transform.position = Vector3.MoveTowards(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -10.0f), new Vector3(homeBackground.transform.position.x, homeBackground.transform.position.y, -10.0f), scrollingSpeed * Time.deltaTime);
            if (Camera.main.transform.position.x == homeBackground.transform.position.x)
            {
                moveToHome = false;
                atHome = true;
                atLearn = false;
                atPlay = false;
                ActivateHomeBody();
                sideMenuOpened = false;
            }
        }

        if (moveToLearn == true)
        {
            Camera.main.transform.position = Vector3.MoveTowards(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -10.0f), new Vector3(learnBackground.transform.position.x, learnBackground.transform.position.y, -10.0f), scrollingSpeed * Time.deltaTime);
            if (Camera.main.transform.position.x == learnBackground.transform.position.x)
            {
                moveToLearn = false;
                ActivateLearnBody();
                atHome = false;
                atLearn = true;
                atPlay = false;
                sideMenuOpened = false;
            }

        }

        if (moveToPlay == true)
        {
            Camera.main.transform.position = Vector3.MoveTowards(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -10.0f), new Vector3(playBackground.transform.position.x, playBackground.transform.position.y, -10.0f), scrollingSpeed * Time.deltaTime);
            if (Camera.main.transform.position.x == playBackground.transform.position.x)
            {
                moveToPlay = false;
                ActivatePlayBody();
                atHome = false;
                atLearn = false;
                atPlay = true;
                sideMenuOpened = false;
            }
        }

        if (sideMenuOpened == true || topSideButtonClicked == true || botSideButtonClicked == true)
        {
            sideMenuBackButton.SetActive(true);
        }
        else if (sideMenuOpened == false || topSideButtonClicked == false || botSideButtonClicked == false)
        {
            sideMenuBackButton.SetActive(false);
        }

        if(atStagesMap)
        {

        }

        //progressAvg = (int.Parse(PlayerPrefs.GetString("stage1")) + int.Parse(PlayerPrefs.GetString("stage2")) + int.Parse(PlayerPrefs.GetString("stage3"))) / 6;

        //Progress.fillAmount = progressAvg;


    }


    public void BackgroundPositioning()
    {
        float backgroundWidth = homeBackground.GetComponent<BoxCollider2D>().size.x;
        playBackground.transform.position = new Vector2 ((homeBackground.transform.position.x - backgroundWidth)*homeBackground.transform.localScale.x,0.0f);
        learnBackground.transform.position = new Vector2((homeBackground.transform.position.x - (backgroundWidth * 2.0f)) * homeBackground.transform.localScale.x, 0);
    }

    public void MoveToHome()
    {
        tipText.text = tipsStrings[Random.Range(0, tipsStrings.Length)];
        topSideButtonClicked = false;
        botSideButtonClicked = false;
        sideButtonsMenuBody.SetActive(false);
        atPlay = false;
        atLearn = false;
        menuBody.SetActive(false);
        moveToHome = true;
        moveToLearn = false;
        moveToPlay = false;
        TopSideButton.SetActive(false);
        BotSideButton.SetActive(false);
        quistionResult.gameObject.SetActive(false);
        trueButton.interactable = true;
        falseButton.interactable = true;
    }

    public void MoveToPlay()
    {
        topSideButtonClicked = false;
        botSideButtonClicked = false;
        sideButtonsMenuBody.SetActive(false);
        atHome = false;
        atLearn = false;
        menuBody.SetActive(false);
        moveToHome = false;
        moveToLearn = false;
        moveToPlay = true;
        TopSideButton.SetActive(false);
        BotSideButton.SetActive(false);
        quistionResult.gameObject.SetActive(false);
        trueButton.interactable = true;
        falseButton.interactable = true;
    }

    public void MoveToLearn()
    {
        showNewQuiz();
        topSideButtonClicked = false;
        botSideButtonClicked = false;
        sideButtonsMenuBody.SetActive(false);
        atHome = false;
        atPlay = false;
        menuBody.SetActive(false);
        moveToHome = false;
        moveToLearn = true;
        moveToPlay = false;
        TopSideButton.SetActive(false);
        BotSideButton.SetActive(false);


    }

    public void ActivateHomeBody()
    {
        homeBody.SetActive(true);
        playBody.SetActive(false);
        learnBody.SetActive(false);
        sideMenuBody.SetActive(false);
        topSideButtonText.text = "challenges";
        botsSideButtonText.text = "Appearance";
        TopSideButton.SetActive(true);
        BotSideButton.SetActive(true);
        menuBody.SetActive(true);

    }

    public void ActivatePlayBody()
    {
        homeBody.SetActive(false);
        playBody.SetActive(true);
        learnBody.SetActive(false);
        sideMenuBody.SetActive(false);
        topSideButtonText.text = "Play Now";
        //botsSideButtonText.text = "High Score";
        TopSideButton.SetActive(true);
       // BotSideButton.SetActive(true);
        menuBody.SetActive(true);
    }

    public void ActivateLearnBody()
    {
        homeBody.SetActive(false);
        playBody.SetActive(false);
        learnBody.SetActive(true);
        sideMenuBody.SetActive(false);
        topSideButtonText.text = "Daily Quiz";
        //BotSideButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Appearance";
        TopSideButton.SetActive(true);
        //BotSideButton.SetActive(true);
        menuBody.SetActive(true);
    }

    public void OpenSideMenu()
    {
        topSideButtonClicked = false;
        botSideButtonClicked = false;
        sideButtonsMenuBody.SetActive(false);
        homeBody.SetActive(false);
        playBody.SetActive(false);
        learnBody.SetActive(false);
        sideMenuBody.SetActive(true);
        menuBody.SetActive(true);
        sideMenuOpened = true;
    }

    public void CloseSideMenu()
    {
        topSideButtonClicked = false;
        botSideButtonClicked = false;
        if (atHome == true)
        {
            sideButtonsMenuBody.SetActive(false);
            homeBody.SetActive(true);
            playBody.SetActive(false);
            learnBody.SetActive(false);
            sideMenuBody.SetActive(false);
            menuBody.SetActive(true);
            sideMenuOpened = false;
        }
        if (atLearn == true)
        {
            sideButtonsMenuBody.SetActive(false);
            homeBody.SetActive(false);
            playBody.SetActive(false);
            learnBody.SetActive(true);
            sideMenuBody.SetActive(false);
            menuBody.SetActive(true);
            sideMenuOpened = false;
        }
        if(atPlay == true)
        {
            sideButtonsMenuBody.SetActive(false);
            homeBody.SetActive(false);
            playBody.SetActive(true);
            learnBody.SetActive(false);
            sideMenuBody.SetActive(false);
            menuBody.SetActive(true);
            sideMenuOpened = false;
        }

    }

    public void ActivateTopSideButton()
    {
        if (atHome)
        {
            menuBody.SetActive(false);
            dailyQuizBody.SetActive(false);
            appearanceBody.SetActive(false);
            settingBody.SetActive(false);
            profileBody.SetActive(false);
            explanationBody.SetActive(false);
            challengesBody.SetActive(true);
            sideButtonsMenuBody.SetActive(true);
        }
        else if (atLearn)
        {
            menuBody.SetActive(false);
            dailyQuizBody.SetActive(true);
            appearanceBody.SetActive(false);
            settingBody.SetActive(false);
            profileBody.SetActive(false);
            challengesBody.SetActive(false);
            explanationBody.SetActive(false);
            sideButtonsMenuBody.SetActive(true);

        }
        else if(atPlay)
        {
            OpenStagesMap();
        }
        topSideButtonClicked = true;
    }

    public void ActivateBotSideButton()
    {
        if(atHome)
        {
            menuBody.SetActive(false);
            dailyQuizBody.SetActive(false);
            appearanceBody.SetActive(true);
            settingBody.SetActive(false);
            profileBody.SetActive(false);
            challengesBody.SetActive(false);
            explanationBody.SetActive(false);
            sideButtonsMenuBody.SetActive(true);
        }
        botSideButtonClicked = true;
    }

    public void OpenSettingMenu()
    {
        menuBody.SetActive(false);
        dailyQuizBody.SetActive(false);
        appearanceBody.SetActive(false);
        settingBody.SetActive(true);
        profileBody.SetActive(false);
        challengesBody.SetActive(false);
        explanationBody.SetActive(false);
        sideButtonsMenuBody.SetActive(true);
    }

    public void OpenProfileMenu()
    {
        menuBody.SetActive(false);
        dailyQuizBody.SetActive(false);
        appearanceBody.SetActive(false);
        settingBody.SetActive(false);
        profileBody.SetActive(true);
        challengesBody.SetActive(false);
        sideButtonsMenuBody.SetActive(true);
    }

    public void OpenStagesMap()
    {
        UndergroundLevelBody.SetActive(false);
        CastleLevelBody.SetActive(false);
        GardenLevelbody.SetActive(false);
        StagesMap.SetActive(true);
        atStagesMap = true;
        menuBody.SetActive(false);
    }

    public void CloseStagesMap()
    {
        sideButtonsMenuBody.SetActive(false);
        homeBody.SetActive(false);
        playBody.SetActive(true);
        learnBody.SetActive(false);
        sideMenuBody.SetActive(false);
        menuBody.SetActive(true);
        sideMenuOpened = false;
        StagesMap.SetActive(false);
        atStagesMap = false;
    }

    public void OpenUndergroundLevelMap()
    {
        StagesMap.SetActive(false);
        UndergroundLevelBody.SetActive(true);

    }

    public void OpenCaslteLevelMap()
    {
        StagesMap.SetActive(false);
        CastleLevelBody.SetActive(true);
    }

    public void OpenGardenLevelMap()
    {
        StagesMap.SetActive(false);
        GardenLevelbody.SetActive(true);
    }

    public void CheckAnswer(bool answer)
    {
        if(answer == quizAnswers[shownQuizIndex])
        {
            quistionResult.text = "Correct!";
            quistionResult.gameObject.SetActive(true);
        }
        else
        {
            quistionResult.text = "Wrong!";
            quistionResult.gameObject.SetActive(true);
        }
        trueButton.interactable = false;
        falseButton.interactable =false;

    }

    public void ShowQuistionsExplantion(int index)
    {
        explantionQuistionText.text =  quizStirngs[index];
        explanationQuistionHeader.text = quizHeaders[index];
        explanation.text = "Expanation: " + explanations[index];
        rightAnswer.text = "it's " + quizAnswers[index];

        menuBody.SetActive(false);
        dailyQuizBody.SetActive(false);
        appearanceBody.SetActive(false);
        settingBody.SetActive(false);
        profileBody.SetActive(false);
        challengesBody.SetActive(false);
        explanationBody.SetActive(true);
        sideButtonsMenuBody.SetActive(true);


    }

    private void showNewQuiz()
    {
        shownQuizIndex = Random.Range(0, quizHeaders.Length);
        quistionHeader.text = quizHeaders[shownQuizIndex];
        quistionText.text = quizStirngs[shownQuizIndex];
    }



    

}
