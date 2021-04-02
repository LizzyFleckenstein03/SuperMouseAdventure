using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    GameObject Mouse;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mouse.transform.position.x, transform.position.y, transform.position.z);
    }
}
