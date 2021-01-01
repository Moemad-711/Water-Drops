using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropTrigger : MonoBehaviour
{
    public LevelController LevelController;


    private void OnTriggerEnter2D(Collider2D other)
    {
        LevelController.Collect(this.gameObject, other);
    }

}
