using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/*Crear una Función Encounter() que haga:
 * Activar los canvas dialogo.
 * Hacer flip del npc
 * Desactivar controles de movimiento del player
*/

public class EncounterController : MonoBehaviour
{
    public GameObject bocadilloPlayer;
    public GameObject bocadilloNPC;
    public PlayerMove playerMoveScript;
    public SpriteRenderer flipNPC;
    public TextMeshProUGUI textPlayer;
    public TextMeshProUGUI textNPC;

    public int dialogStage = 0;
    public bool startSpeak = false;

    public string[] dialogArray;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DialogController();
    }

    public void DialogController()
    {
        if (Input.GetKeyDown(KeyCode.Space) && startSpeak == true)
        {
            dialogStage += 1;
        }

        if (dialogStage == 1)
        {
            bocadilloNPC.SetActive(false);
            bocadilloPlayer.SetActive(true);
            textPlayer.text = dialogArray[1];
        }
        
        if (dialogStage == 2)
        {
                bocadilloNPC.SetActive(true);
                bocadilloPlayer.SetActive(false);
                textNPC.text = dialogArray[2];
        }
        
        if (dialogStage == 3)
        {
            bocadilloNPC.SetActive(true);
            bocadilloPlayer.SetActive(false);
            textNPC.text = dialogArray[3];
        }
        
        if (dialogStage == 4)
        {
            bocadilloNPC.SetActive(false);
            bocadilloPlayer.SetActive(true);
            textPlayer.text = dialogArray[4];
        }
        
        if (dialogStage == 5)
        {
            bocadilloNPC.SetActive(false);
            bocadilloPlayer.SetActive(false);
            playerMoveScript.enabled = true;
            gameObject.SetActive(false);
        }
    }

    public void Encounter()
    {
       // bocadilloPlayer.SetActive(true);
        bocadilloNPC.SetActive(true);
        playerMoveScript.anim.SetBool("RunPlayer", false);
        flipNPC.flipX = true;
        playerMoveScript.enabled = false;
        textNPC.text = dialogArray[0];
        startSpeak = true;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Encounter();

    }
}
