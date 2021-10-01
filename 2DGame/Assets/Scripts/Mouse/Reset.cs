using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    private CheckpointManager checkpointManager;

    private CheeseCollection cheeseCollection;

    public GameObject cheeseCoin;

    Abyss abyss;

    Health health;

    void Start()
    {
        checkpointManager = GameObject.FindGameObjectWithTag("CheckpointManager").GetComponent<CheckpointManager>();
        abyss = GetComponent<Abyss>();
        health = GetComponent<Health>();
        cheeseCollection = GetComponent<CheeseCollection>();
    }

    void ResetPosition()
    {
        transform.position = checkpointManager.lastCheckpointPos;
        cheeseCollection.cheesecount = checkpointManager.lastCheeseCount;
        cheeseCollection.countText.text = cheeseCollection.cheesecount.ToString();
        if (checkpointManager.isCheeseCoinCollected)
        {
            cheeseCoin.SetActive(false);
        }
        abyss.fallenDown = false;
        health.mouseHealth = 5;
    }

    void Update()
    {
        if(abyss.fallenDown || health.mouseHealth <= 0)
        {
            ResetPosition();
        }
    }
}
