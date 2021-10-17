using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] private Transform bubblePos;
    
    bool collected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collected = true;
        }
    }

    private void Update()
    {
        if (collected)
        {
            transform.position = bubblePos.position;
        }
    }
}
