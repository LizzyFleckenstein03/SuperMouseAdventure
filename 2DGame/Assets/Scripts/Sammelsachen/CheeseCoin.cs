using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheeseCoin : MonoBehaviour
{
    private bool cheeseCoinCollected;

    public GameObject cheeseCoin;
     
    public Image cheeseCoinRenderer;
    public Sprite collectedCheeseCoin;
    public Sprite missingCheeseCoin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cheeseCoinCollected == true)
        {
            cheeseCoinRenderer.sprite = collectedCheeseCoin;
            cheeseCoin.SetActive(false);
        }
        else
        {
            cheeseCoinRenderer.sprite = missingCheeseCoin;
        }

        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            cheeseCoinCollected = true;
        }
    }
}
