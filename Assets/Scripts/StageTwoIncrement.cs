using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTwoIncrement : MonoBehaviour
{
    public LevelController controller;

    public void StageTwoIncrementMethod()
    {
        if (controller.waterDropsCount == controller.waterDropLevelMax)
            StartCoroutine(MainScript.Instance.Web.SecondStageUpdate());
    }
}
