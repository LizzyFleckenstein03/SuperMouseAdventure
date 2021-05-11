using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [SerializeField]
    string bossName;

    [SerializeField]
    Text bossText;

    // Start is called before the first frame update
    void Start()
    {
        bossText.text = bossName;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
