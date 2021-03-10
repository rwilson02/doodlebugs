using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float speed;
    public int hp = 1;
    public float life = 3;
    public AudioSource hit;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        life -= Time.deltaTime;
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            hp--;
            var enem = collision.GetComponent<EnemyScript>();
            enem.hp--;

            if(enem.hp == 0)
            {
                enem.Kill();
            }
            if (hp == 0)
            {
                hit.Play();
                Destroy(gameObject);
            }
        }
    }
}
