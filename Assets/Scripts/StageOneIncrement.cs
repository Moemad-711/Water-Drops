using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageOneIncrement : MonoBehaviour
{
    public LevelController controller;


    public void StageOneIncrementMethod()
    {
        if (controller.waterDropsCount == controller.waterDropLevelMax)
            StartCoroutine(MainScript.Instance.Web.FirstStageUpdate());
    }
}
