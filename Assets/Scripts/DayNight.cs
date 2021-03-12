using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{


    public LightColorController lightController;
    public bool stateDayNight = false;
    public int timeNight = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stateDayNight == true)
        {
            lightController.time += Time.deltaTime / timeNight;
        }
        else
            lightController.time = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        stateDayNight = true;
    }
}
