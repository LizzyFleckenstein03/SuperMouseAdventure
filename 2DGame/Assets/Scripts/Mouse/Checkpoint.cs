using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointManager cm;
    private Cheese cheese;
    private CheeseCoin cheeseCoin;

    public Sprite green;

    void Start()
    {
        cm = GameObject.FindGameObjectWithTag("CheckpointManager").GetComponent<CheckpointManager>();
        cheese = GameObject.FindGameObjectWithTag("Player").GetComponent<Cheese>();
        cheeseCoin = GameObject.FindGameObjectWithTag("Player").GetComponent<CheeseCoin>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cm.lastCheckpointPos = transform.position;
            cm.lastCheeseCount = cheese.cheesecount;
            cm.isCheeseCoinCollected = cheeseCoin.cheeseCoinCollected;

            if (GetComponent<SpriteRenderer>().sprite != green)
            {
                FindObjectOfType<AudioManager>().Play("checkpoint");
                GetComponent<SpriteRenderer>().sprite = green;
            }
        }
    }
}
