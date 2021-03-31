using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject[] CheckPoints;

    public GameObject Mouse;

    private Abyss abyss;
    private Health health;

    public bool reset;

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
            reset = true;
        }

        if (reset == true)
        {
            for (int i = 0; i < CheckPoints.Length; i++)
            {
                if (CheckPoints[i].transform.position.x <= Mouse.transform.position.x && CheckPoints[i + 1].transform.position.x >= Mouse.transform.position.x)
                {
                    Mouse.transform.position = CheckPoints[i].transform.position;
                } else
                {
                    Mouse.transform.position = CheckPoints[CheckPoints.Length - 1].transform.position;
                }

                if (Mouse.transform.position == CheckPoints[i].transform.position)
                {
                    reset = false;
                    abyss.fallenDown = false;
                    health.mouseHealth = 5;
                }
            }
        }
    }
}
