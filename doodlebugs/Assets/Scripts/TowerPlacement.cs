using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    Camera cam;
    public GameObject statTower;
    public GameObject mouseTower;
    int placeStage = 0;
    bool done = false, valid, stat;

    GameObject placing;
    SpriteRenderer placeBase, placeHead;
    aimATmouse lookScript;
    Color ghost, redGhost;
    LayerMask no;

    private void Start()
    {
        cam = Camera.main;
        placing = null;
        ghost = new Color(1, 1, 1, 0.5f);
        redGhost = new Color(1, 0, 0, 0.5f);
        no = LayerMask.NameToLayer("noClicks");
        valid = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(placing != null) //if you are placing something
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            //move the thing around at your mouse
            if (placeStage == 0 && Physics.Raycast(ray, out RaycastHit hit))
            {
                placing.transform.position = new Vector2(hit.point.x, hit.point.y);

                if (hit.transform.gameObject.layer == no)
                {
                    placeBase.color = redGhost;
                    placeHead.color = redGhost;
                    valid = false;
                }
                else
                {
                    placeBase.color = ghost;
                    placeHead.color = ghost;
                    valid = true;
                }
            }

            //once you've placed the base
            if(placeStage >= 1)
            {
                Debug.Log("placed");
                placeBase.color = Color.white;
                lookScript.enabled = true;
                
                if(!stat)
                {
                    done = true;
                }

                //if you've clicked again with a stat tower
                if(placeStage == 2 && stat)
                {
                    Debug.Log("hello");
                    lookScript.enabled = false;
                    placeHead.color = Color.white;
                    done = true;
                }

                if (done)
                {
                    placing.GetComponentInChildren<Fire>().good = true;
                    placing = null;
                    placeStage = 0;
                    done = false;
                }
            }
            
            if (Input.GetMouseButtonDown(0) && valid)
            {
                placeStage++;
            }
        }
    }

    public void PlaceTower(int towerNum)
    {
        switch (towerNum)
        {
            case 0:
                placing = Instantiate(statTower);
                stat = true;
                break;
            case 1:
                placing = Instantiate(mouseTower);
                stat = false;
                break;
        }

        placeBase = placing.GetComponent<SpriteRenderer>();
        placeHead = placing.GetComponentInChildren<SpriteRenderer>();
        lookScript = placing.GetComponentInChildren<aimATmouse>();
        lookScript.enabled = false;

        placeBase.transform.rotation = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward);
        placeBase.color = ghost;
        placeHead.color = ghost;
    }
}
