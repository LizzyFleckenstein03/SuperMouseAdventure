using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject begrenzer;

    [SerializeField]
    GameObject maus;

    [SerializeField]
    Transform cameraLock;

    [HideInInspector]
    public bool cameraLocked;

    // Update is called once per frame
    void Update()
    {
        if (maus.transform.position.x > begrenzer.transform.position.x)
        {
            transform.position = new Vector3(maus.transform.position.x, maus.transform.position.y, -10);
            cameraLocked = false;
        }
        else
        {
            transform.position = new Vector3(cameraLock.transform.position.x, cameraLock.transform.position.y, -10);
            cameraLocked = true;
        }
    }
}
