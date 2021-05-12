using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField]
    private Transform bossTrigger;

    [SerializeField]
    private Transform mouse;

    public bool bossFight;

    private void Update()
    {
        if(mouse.transform.position.x > bossTrigger.position.x)
        {
            bossFight = true;
        }
    }
}
