using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MousePos : MonoBehaviour
{
    private CheckpointManager checkpointManager;

    // Start is called before the first frame update
    void Start()
    {
        checkpointManager = GameObject.FindGameObjectWithTag("Checkpointmanager").GetComponent<CheckpointManager>();
        transform.position = checkpointManager.lastCheckpointPos;
    }

    void Update()
    {
        /**if()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }*/
    }
}
