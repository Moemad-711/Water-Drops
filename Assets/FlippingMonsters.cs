using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippingMonsters : MonoBehaviour
{
    public MonsterController monster;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            monster.FlipMonster();
        }
    }
}
