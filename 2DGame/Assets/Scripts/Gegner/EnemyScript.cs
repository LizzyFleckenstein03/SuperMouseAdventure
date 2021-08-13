using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int enemyHealth;
    public int enemyDamage;

    public bool spiky;

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<FollowPlayer>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 10;
            Destroy(gameObject, 2);
        }
    }
}
