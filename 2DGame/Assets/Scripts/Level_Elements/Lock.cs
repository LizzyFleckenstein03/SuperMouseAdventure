using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lock : MonoBehaviour
{
    private KeyHolder keyHolder;

    public SpriteRenderer spriteRenderer;
    public Sprite unlockedLockSprite;

    public bool doorOpen, waitingToOpen;

    public bool isDoor;

    // Start is called before the first frame update
    void Start()
    {
        keyHolder = FindObjectOfType<KeyHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        if(waitingToOpen)
        {
            if(Vector3.Distance(keyHolder.followingKey.transform.position, transform.position) < 0.1f)
            {
                waitingToOpen = false;

                doorOpen = true;

                //spriteRenderer.sprite = unlockedLockSprite;

                keyHolder.followingKey.gameObject.SetActive(false);
                keyHolder.followingKey = null;

                gameObject.SetActive(false);
            }
        }

        if(isDoor)
        {
            if (doorOpen && Vector3.Distance(keyHolder.transform.position, transform.position) < 1f && Input.GetAxis("Vertical") > 0.1f)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(keyHolder.followingKey != null)
            {
                keyHolder.followingKey.followTarget = transform;
                waitingToOpen = true; 
            }
        }
    }
}
