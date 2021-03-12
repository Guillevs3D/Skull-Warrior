using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class OpenChest : MonoBehaviour
{
    public bool open = false;
    public GameObject chestOpen;
    public GameObject bocadilloPlayer;
    public PlayerMove playerMoveScript;
    public TextMeshProUGUI textPlayer;


    // Start is called before the first frame update
    void Start()
    {
     chestOpen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //4-Cuando una tecla, desactivar dialogo y reactivar movimiento. 
        if (Input.GetKeyDown(KeyCode.Space) && open == true)
        {
            playerMoveScript.enabled = true;
            gameObject.SetActive(false);
            bocadilloPlayer.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Desactivar imagen cofre cerrado
            GetComponent<SpriteRenderer>().enabled = false;
            //Activar cofre abierto.
            chestOpen.SetActive(true);
            open = true;

            //1-Parar al jugador igual que hacíamos en el encounter.
            playerMoveScript.anim.SetBool("RunPlayer", false);
            playerMoveScript.enabled = false;

            //2-Activar espada.
            playerMoveScript.anim.SetBool("Weapon", true);

            //Checkpoint
            GameManager.instance.spawnPlayer.transform.position = transform.position + (Vector3.up *2);

            //3-Activar un dialogo del player que diga: "Siento mucha fuerza en esta espada".
            bocadilloPlayer.SetActive(true);
            textPlayer.text = "Siento mucha fuerza en esta espada.";

        }
    }
}
