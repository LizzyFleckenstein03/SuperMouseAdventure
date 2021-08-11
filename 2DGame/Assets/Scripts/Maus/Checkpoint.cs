using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointManager cm;
    private Cheese cheese;

    public Sprite red;
    public Sprite green;

    void Start()
    {
        cm = GameObject.FindGameObjectWithTag("CheckpointManager").GetComponent<CheckpointManager>();
        cheese = GameObject.FindGameObjectWithTag("Player").GetComponent<Cheese>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            cm.lastCheckpointPos = transform.position;
            cm.lastCheeseCount = cheese.cheesecount;
            GetComponent<SpriteRenderer>().sprite = green;
        }
    }
}
