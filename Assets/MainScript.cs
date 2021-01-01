using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public static MainScript Instance;
    public WebScript Web;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Web = GetComponent<WebScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
