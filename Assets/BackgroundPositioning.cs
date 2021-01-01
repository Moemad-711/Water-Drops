using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPositioning : MonoBehaviour
{

    public GameObject[] Backgrounds;

    public int BeforeBackgroundIndex;
    public int AfterBackgroundIndex;
    // Start is called before the first frame update
    void Start()
    {
        float backgroundWidth = 29.17962f;
        Backgrounds[0].transform.position = new Vector3(0, 0, 0);
        float scaleX = Backgrounds[0].transform.localScale.x;
        

        for (int i = 1; i < Backgrounds.Length; i++)
        {
            if(i!=BeforeBackgroundIndex && i!= AfterBackgroundIndex)
            Backgrounds[i].transform.position = new Vector3((0 + (i * backgroundWidth)) * scaleX , 0, 0);
            
        }

        Backgrounds[BeforeBackgroundIndex].transform.position = new Vector3((0 -  backgroundWidth) * scaleX, 0, 0);
        Backgrounds[AfterBackgroundIndex].transform.position = Backgrounds[Backgrounds.Length-3].transform.position +  new Vector3(backgroundWidth * scaleX, 0, 0);

    }

    


}
