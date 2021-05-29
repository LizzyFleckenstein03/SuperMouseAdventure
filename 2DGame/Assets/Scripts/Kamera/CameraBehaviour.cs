using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject begrenzer;

    [SerializeField]
    GameObject maus;

    // Update is called once per frame
    void Update()
    {
        if (maus.transform.position.x > begrenzer.transform.position.x)
        {
            transform.position = new Vector3(maus.transform.position.x, maus.transform.position.y-8, -10);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
