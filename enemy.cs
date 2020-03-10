﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MovingObjects
{
    public int playerDamage;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform target;
    [SerializeField] private bool skipMove;


    protected override void Start()
    {
        
        target = GameObject.FindGameObjectWithTag("Player").transform;
        base.Start();
    }

    public void Init(Transform Player_trans)
    {

    }

    protected override void AttemptMove<T>(int xDir, int yDir)
    {
     
        if (!skipMove)
        {
            base.AttemptMove<T>(xDir, yDir);
            skipMove = true;
        }

        skipMove = false;
    }


    public void MoveEnemy()
    {
        int xDir = 0;
        int yDir = 0;

        
        if (Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon)
        {

            yDir = target.position.y > transform.position.y ? 1 : -1;
        }
        else
        {

            xDir = target.position.x > transform.position.x ? 1 : -1;
        }
        AttemptMove(xDir, yDir);

    }
    protected override void OnCantMove(GameObject go)
    {
        component = go.getcomponent<Player>();

        playerDamage hitPlayer = component as playerDamage;
        hitPlayer.LoseFood(playerDamage);
    }
}
