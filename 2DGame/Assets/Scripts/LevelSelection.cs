using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField]
    Transform[] levels;

    [SerializeField]
    Text nameOfLevel;

    [SerializeField]
    string[] levelNames;

    [SerializeField]
    Text nameOfWorld;

    [SerializeField]
    string[] worldNames;

    private int level;

    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        transform.position = levels[level].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (level > 0)
            {
                level -= 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (level < 9)
            {
                level += 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(level + 1);
        }

        transform.position = levels[level].transform.position;
        nameOfLevel.text = levelNames[level];
    }
}
