using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //SerializeFields sind private, tauchen allerdings trotzdem im Inspector in Unity auf

    [SerializeField]
    Transform player;

    [SerializeField]
    private float agroRange;

    [SerializeField]
    private float MoveSpeed;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Abstand zur Spielfigur
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if(distToPlayer < agroRange)
        {
            ChasePlayer();
        } else
        {
            StopChasingPlayer();
        }

    }

    void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            //Der Gegner ist links neben dem Spieler, also bewegt er sich nach rechts
            rb.velocity = new Vector2(MoveSpeed, 0);

            //Gegner wird der Bewegung entsprechend gedreht
            transform.localScale = new Vector2(1, 1);
        }
        else if(transform.position.x > player.position.x)
        {
            //Der Gegner ist rechts neben dem Spieler, also bewegt er sich nach links
            rb.velocity = new Vector2(-MoveSpeed, 0);

            //Gegner wird der Bewegung entsprechend gedreht
            transform.localScale = new Vector2(-1, 1);
        }
    }

    void StopChasingPlayer()
    {
        //Geschwindigkeit des Gegners auf null setzen
        rb.velocity = Vector2.zero;
    }
}
