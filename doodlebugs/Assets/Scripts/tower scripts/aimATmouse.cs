using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimATmouse : MonoBehaviour
{
    //haha good thing i needed this exact thing for traffic rush
    private Camera cam;
    private Vector2 diffPos;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        diffPos = Input.mousePosition - cam.WorldToScreenPoint(this.transform.position);

        var angle = Mathf.Atan2(diffPos.y, diffPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
