using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public int damage = 10;
    public float timeAttack = 2;
    public float timeMomentAttack;
    public PlayerMove playerMoveScript;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMoveScript.isAlive)
            Attack();
    }

    /*
     * Cada vez que se ataque, tenemos que desactivar el script de movimiento.
     * Y tenemos que volver a activarlo al cabo de 2 seg
     * */

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.E) == true || (Input.GetMouseButtonDown(0)))
        {
            anim.SetBool("Attack", true);
            anim.SetBool("RunPlayer", false);
            playerMoveScript.enabled = false;
            timeMomentAttack = Time.time;
        }

        //Si estamos atacando contamos el tiempo en finalizar el ataque y poder volver a movernos.
        if (anim.GetBool("Attack") == true)
        {
            //timeAttack = 2
            //timeMomentAttack = 5
            //Time.time == 7 <--- Han pasado 2 s!!
            if (Time.time >= timeMomentAttack + timeAttack)
            {
                EndAttack();
            }
        }
    }
    public void EndAttack()
    {
        playerMoveScript.enabled = true;
        anim.SetBool("Attack", false);
    }
}
