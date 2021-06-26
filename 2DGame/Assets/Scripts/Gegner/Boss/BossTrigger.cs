using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public bool bossFight;

    BoxCollider2D boxCollider2D;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        bossFight = true;
        FindObjectOfType<AudioManager>().Stop("flowers");
        FindObjectOfType<AudioManager>().Play("snail_fight");

        boxCollider2D.enabled = false;
    }
}
