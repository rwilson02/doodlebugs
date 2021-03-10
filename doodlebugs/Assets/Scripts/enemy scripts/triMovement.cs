using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triMovement : MonoBehaviour
{
    public float speed = 1;

    private Transform target, point1, point2;
    private int wayptIndex = 0;
    private Transform[] path, pointsA, pointsB;

    private void Start()
    {
        pointsA = WayPointerB.pointsA;
        pointsB = WayPointerB.pointsB;

        point1 = pointsA[Random.Range(0, pointsA.Length)];
        point2 = pointsB[Random.Range(0, pointsB.Length)];

        path = new Transform[] { point1, point2, WayPointerB.end };
        target = path[0];
    }

    private void Update()
    {
        Vector2 moveDir = target.position - transform.position;
        //hey figure out how ot make the rotations work kthxbai

        float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
        
        transform.Translate(moveDir.normalized * speed * Time.deltaTime);
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Vector2.Distance(transform.position, target.position) <= 0.2)
        {
            NextPoint();
        }
    }

    void NextPoint()
    {
        if (wayptIndex >= path.Length - 1)
        {
            life.playerHP.DMG();
            Destroy(gameObject);
            return;
        }

        wayptIndex++;
        target = path[wayptIndex];
    }
}
