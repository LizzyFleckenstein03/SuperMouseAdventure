using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFinish : MonoBehaviour
{
    [SerializeField]
    Text levelGeschafft;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Finish"))
        {
            levelGeschafft.text = "Level geschafft!";
        }
    }
}
