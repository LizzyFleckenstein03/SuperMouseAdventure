using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private static CheckpointManager instance;
    public Vector3 lastCheckpointPos;
    public Cheese cheese;
    public int lastCheeseCount;
    public Transform mouse;

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
        SaveSystem.SavePlayer(instance, cheese);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        cheese.cheesecount = data.collectedCheese;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        mouse.transform.position = position;
    }
}
