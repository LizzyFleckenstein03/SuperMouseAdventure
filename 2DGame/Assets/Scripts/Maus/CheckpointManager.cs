using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private static CheckpointManager instance;

    public Vector3 lastCheckpointPos;

    Cheese cheese;

    CheeseCoin cheeseCoin;

    public Transform mouse;

    public int lastCheeseCount;

    public bool isCheeseCoinCollected;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //cheese muss noch definiert werden


    public void SavePlayer ()
    {
        SaveSystem.SavePlayer(instance, cheese, cheeseCoin);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        cheese.cheesecount = data.collectedCheese;
        cheeseCoin.cheeseCoinCollected = data.isCheeseCoinCollected;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        mouse.transform.position = position;
    }
}
