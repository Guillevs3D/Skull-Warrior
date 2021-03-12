using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject panelGameOver;
    public GameObject spawnPlayer;

    [Header ("Script")]
    public PlayerMove playerMove;
    public DayNight scriptDayNight;

    //Puede ser accedida desde cualquier sitio sin una referencia previa
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        panelGameOver.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Se llama desde el botón Reintenar.
    public void Reintentar()
    {
        //¿Que habría que hacer para Reiniciar la partida?
        panelGameOver.SetActive(false);
        playerMove.isAlive = true;
        playerMove.anim.SetBool("Dead",false);
        playerMove.transform.position = spawnPlayer.transform.position;
        scriptDayNight.stateDayNight = false;
        playerMove.health = 100;
        playerMove.enabled = true;
        
    }

    //Ciuando el player coge la espada, movemos el spawnPlayer a la posición donde hemos cogido la espada. 
    //cuando el player coge la espada mover el spawn al cofre

}
