using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MousePos : MonoBehaviour
{
    private CheckpointManager checkpointManager;

    Abyss abyss;

    Health health;

    // Start is called before the first frame update
    void Start()
    {
        checkpointManager = GameObject.FindGameObjectWithTag("CheckpointManager").GetComponent<CheckpointManager>();
        abyss = GetComponent<Abyss>();
        health = GetComponent<Health>();
        transform.position = checkpointManager.lastCheckpointPos;
    }

    void Update()
    {
        if(abyss.fallenDown || health.mouseHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
