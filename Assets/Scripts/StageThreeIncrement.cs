using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageThreeIncrement : MonoBehaviour
{
    public LevelController controller;

    public void StageThreeIncrementMethod()
    {
        if(controller.waterDropsCount == controller.waterDropLevelMax)
        StartCoroutine(MainScript.Instance.Web.ThirdStageUpdate());
    }
}
