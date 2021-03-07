using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eneMovement : MonoBehaviour
{
    public float speed = 1;

    private Transform target;
    private int wayptIndex = 0;

    private void Start()
    {
        target = WayPointerA.waypts[0];
    }

    private void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, target.position) <= 0.2)
        {
            NextPoint();
        }
    }

    void NextPoint()
    {
        if(wayptIndex >= WayPointerA.waypts.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wayptIndex++;
        target = WayPointerA.waypts[wayptIndex];
    }
}
