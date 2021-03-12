using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Variables Globales Publicas
    [Header("Player Config")]
    public float health = 100;
    /*[Header("Weapons")]
     public bool sword = false;
     public bool shield = false;*/

    [Header("Move")]
    public float speedMove = 5f;
    public float jumpForce = 5f;
    public bool isAlive = true;


    //Variables Globales Internal (Como públci, pero no aparece en elinspector)
    internal Animator anim;

    //Variables Globales Privadas
    private bool grounded = true;
    private SpriteRenderer playerRenderer;
    private Rigidbody2D rigidbodyPlayer;

    private PlayerMove playerScript;


    // Start is called before the first frame update
    void Start()
    {        
        anim = GetComponent<Animator>();
        playerRenderer = GetComponent<SpriteRenderer>();
        rigidbodyPlayer = GetComponent<Rigidbody2D>();
        playerScript = GetComponent<PlayerMove>();
        rigidbodyPlayer = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            MovePlayer();
            JumpPlayer();
            HealtPlayer();
        }
    }
    public void MovePlayer()
    {
       float xMove;
       xMove = Input.GetAxis("Horizontal") * speedMove * Time.deltaTime;
       transform.Translate(Vector2.right * xMove);
        
        if (xMove < 0)
        {
            playerRenderer.flipX = true;
        }
        if(xMove > 0)
        {
            playerRenderer.flipX = false;
        }

        //la exclamacion es una negacion
        if (xMove !=0)
        {
            anim.SetBool("RunPlayer", true);
        }
        else 
        {
            anim.SetBool("RunPlayer", false);
        }
    }
    
    public void JumpPlayer()
    {    
            if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
            {
                rigidbodyPlayer.AddForce(Vector2.up * jumpForce);
                anim.SetTrigger("Jump");
                grounded = false;
            }

    }

    public void HealtPlayer()
    {
        if (health <= 0)
        {
            isAlive = false;
            anim.SetBool("Dead", true);
            playerScript.enabled = false;
            //rigidbodyPlayer.gravityScale = 0;
            // Panel has muerto
            GameManager.instance.panelGameOver.SetActive(true);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "DeadZone")
        {
            HealtPlayer();
        }
    }
}