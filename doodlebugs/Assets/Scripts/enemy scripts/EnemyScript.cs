﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int hp, bounty;
    public bool red = false;
    public eneMovement move = null;
    public triMovement trimove = null;
    public SpriteRenderer img;
    public Sprite[] sprites;
    public Animator anim;
    bool isTri;

    public ParticleSystem die;

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
        anim = GetComponentInChildren<Animator>();
    }

    public void Kill()
    {
        Debug.Log("ded");
        currenScript.playerCash.Kill(bounty);
        Instantiate(die, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void RedCheck()
    {
        if (red)
        {
            hp = Mathf.CeilToInt(hp * 1.5f);
            bounty = Mathf.CeilToInt(bounty * 1.5f);
            anim.enabled = false;

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
}
