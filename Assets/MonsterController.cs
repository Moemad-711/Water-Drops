using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2; 
    public float speed = 1.0f;
    public LevelController controller;


    void Update()
    {
        transform.position = Vector3.Lerp(pos1.position, pos2.position, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);

        
    }

   

    public void FlipMonster()
    {
        gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, .2f, 1);
        Debug.Log("FlipMonster");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            controller.GameOver();
        }
    }

}
