using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redcheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("checked");
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyScript>().RedCheck();
        }
    }
}
