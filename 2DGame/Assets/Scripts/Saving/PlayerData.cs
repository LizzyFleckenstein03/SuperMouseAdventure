using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public float [] position;
    public int collectedCheese;

    public PlayerData (CheckpointManager cm, Cheese cheese)
    {
        collectedCheese = cheese.cheesecount;
        position = new float[3];
        position[0] = cm.lastCheckpointPos.x;
        position[1] = cm.lastCheckpointPos.y;
        position[2] = cm.lastCheckpointPos.z;
    }
}
