using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject[] CheckPoints;

    public GameObject Mouse;

    private Abyss abyss;
    private Health health;

    public bool retry;

    // Start is called before the first frame update
    void Start()
    {
        abyss = GetComponent<Abyss>();
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (abyss.fallenDown == true || health.mouseHealth == 0)
        {
            retry = true;
        }

        if (retry == true)
        {
            for (int i = 0; i < CheckPoints.Length; i++)
            {
                if (CheckPoints[i].transform.position.x < Mouse.transform.position.x)
                {
                    Mouse.transform.position = CheckPoints[i].transform.position;

                    if (Mouse.transform.position == CheckPoints[i].transform.position)
                    {
                        retry =! retry;
                        abyss.fallenDown =! abyss.fallenDown;
                        health.mouseHealth = 5;
                    }
                }
            }
        }
    }
}
