using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelController : MonoBehaviour
{
    public int waterDropLevelMax;
    public TMPro.TextMeshProUGUI ScoreText;

    public int stageIndex;
    public int levelIndex;
    public TMPro.TextMeshProUGUI levelTips;

    public TMPro.TextMeshProUGUI levelEndText;
    public GameObject levelEndBody;
    public LevelQuistion levelQuistion;

    public Button nextButton;

    public int waterDropsCount;


    // Start is called before the first frame update
    void Start()
    {
        nextButton.gameObject.SetActive(false);
        levelQuistion.gameObject.SetActive(false);
        levelEndBody.SetActive(false);
        waterDropsCount = 0;
        if(stageIndex == 1 && levelIndex==1 )
        {
            levelTips.text = " Welcome survivor!\nThis is your journey to take back earth from our invader\nStart by collecting that water Drop";
        }
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = waterDropsCount.ToString();
        if (waterDropsCount == waterDropLevelMax)
        {
            nextButton.gameObject.SetActive(true );
            levelEndText.text = "Congrats!\n you survived for another Day\nYou are one step closer to take back our earth!"; 
            levelEndBody.SetActive(true);

        }
        if (stageIndex == 1 && levelIndex == 1)
        {
            if(waterDropsCount == 1)
            {
                levelTips.text = " well done!\n collect all the water\nto get strong enough for the next one";
            }
        }
    }



    public void  Collect(GameObject waterDrop, Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collected");
            waterDropsCount = waterDropsCount + 1;
            Destroy(waterDrop);
        }
    }


    public void GameOver()
    {
        levelEndText.text = "Game Over\nNo Problem here you will make it the next time";
        levelQuistion.SetQuistion();
        levelQuistion.gameObject.SetActive(true);
        levelEndBody.SetActive(true);
    }

}
