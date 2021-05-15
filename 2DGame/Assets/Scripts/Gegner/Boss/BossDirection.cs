using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDirection : MonoBehaviour
{
    BossTrigger bossTrigger;

    public bool isFlipped;

    private void Start()
    {
        bossTrigger = GetComponent<BossTrigger>();
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > bossTrigger.mouse.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if(transform.position.x < bossTrigger.mouse.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
