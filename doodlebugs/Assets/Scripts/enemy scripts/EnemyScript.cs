using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int hp, bounty;
    public bool red = false;
    eneMovement move = null;
    triMovement trimove = null;
    public SpriteRenderer img;
    public Sprite[] sprites;
    bool isTri;

    private void Awake()
    {
        if(TryGetComponent(out eneMovement gotMoveA)){
            move = gotMoveA;
            isTri = false;
        }
        if (TryGetComponent(out triMovement gotMoveB))
        {
            trimove = gotMoveB;
            isTri = true;
        }

        if (red)
        {
            hp = Mathf.CeilToInt(hp * 1.5f);
            bounty = Mathf.CeilToInt(bounty * 1.5f);

            if (isTri)
            {
                trimove.speed *= 0.75f;
            }
            else move.speed *= 0.75f;

            img.sprite = sprites[1];
        }
        else
        {
            img.sprite = sprites[0];
        }
    }

    public void Kill()
    {
        Debug.Log("ded");
        currenScript.playerCash.Kill(bounty);
        //some other stuff, like a sound
        Destroy(gameObject);
    }
}
