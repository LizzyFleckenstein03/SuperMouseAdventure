using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [SerializeField]
    int startBossHealth;

    private int bossHealth;

    [SerializeField]
    string bossName;

    [SerializeField]
    Text bossText;

    [SerializeField]
    Image healthBar;

    private float barWidth = 342;
    private float barHeight = 72;
    private float barX;

    // Start is called before the first frame update
    void Start()
    {
        bossHealth = startBossHealth;
        bossText.text = bossName;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossHealth == 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            bossHealth--;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            bossHealth--;
        }
        
        //Hier steht alter Code, der allerdings nicht auf das Image angewendet werden kann. 
        //bossHealthBar.transform.localScale = new Vector3((barWidth/startBossHealth) * bossHealth, barHeight, 0);
        //bossHealthBar.transform.position = new Vector3(barX/startBossHealth * bossHealth, bossHealthBar.transform.position.y, transform.position.z);
    }
}
