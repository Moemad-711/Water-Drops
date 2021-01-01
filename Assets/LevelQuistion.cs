using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelQuistion : MonoBehaviour
{
    public GameObject holder;
    public GameObject levelEndBody;
    public TMPro.TextMeshProUGUI quistion;
    public string[] quizStirngs;
    public bool[] quizAnswers;
    public Button trueButton;
    public Button falseButton;
    private int shownQuizIndex;

    public void SetQuistion()
    {
        
            shownQuizIndex = Random.Range(0, quizStirngs.Length);
            quistion.text = quizStirngs[shownQuizIndex];

    }

    public void CheckAnswer(bool answer)
    {
        if (answer == quizAnswers[shownQuizIndex])
        {
            levelEndBody.SetActive(false);
        }
        else
        {
            holder.SetActive(true);
        }
        trueButton.interactable = false;
        falseButton.interactable = false;

    }
}
