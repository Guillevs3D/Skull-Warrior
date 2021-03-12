using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{
    public List<string> rewards = new List<string>();
    public List<int> rewardsProbability = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int dado = Random.Range(0, 1000);
            for(int i = 0; i < rewards.Count; i++)
            {
                if(dado < rewardsProbability[i])
                {
                    print("La recompensa es: " + rewards[i]);
                    break;
                }
            }
        }

    }
}
