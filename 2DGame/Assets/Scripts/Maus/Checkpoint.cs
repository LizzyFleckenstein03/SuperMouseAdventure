using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointManager cm;

    public Sprite red;
    public Sprite green;

    void Start()
    {
        cm = GameObject.FindGameObjectWithTag("CheckpointManager").GetComponent<CheckpointManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            cm.lastCheckpointPos = transform.position;
            GetComponent<SpriteRenderer>().sprite = green;
        }
    }
}
