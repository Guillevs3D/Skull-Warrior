using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject walls;
    public Enemy[] enemyArray;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        bool allEnemyDead = true;

        for (int i = 0; i < enemyArray.Length; i++)
        {
            if (enemyArray[i].isAlive == true)
            {
                allEnemyDead = false;
            }
        }

        if (allEnemyDead == true)
        {
            walls.SetActive(false);
        }

    }
}
