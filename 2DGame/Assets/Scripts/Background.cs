using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    GameObject Camera;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Camera.transform.position.x, transform.position.y, transform.position.z);
    }
}
