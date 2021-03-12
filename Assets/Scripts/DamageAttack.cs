using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAttack : MonoBehaviour
{
    public string targetDamageTag;
    public float forceKnockback = 100;
    public float damage = 5;
    private SpriteRenderer parentSprite;
 

    // Start is called before the first frame update
    void Awake()
    {
        parentSprite = GetComponentInParent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parentSprite.flipX == true)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && targetDamageTag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().healt -= damage;
            collision.gameObject.GetComponent<Animator>().SetTrigger("Hit");
            
            if(collision.gameObject.GetComponent<SpriteRenderer>().flipX == true)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * forceKnockback);
            }
            else
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * forceKnockback);
        }

        if (collision.gameObject.tag == "Player" && targetDamageTag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMove>().health -= damage;
            collision.gameObject.GetComponent<Animator>().SetTrigger("Hit");

            if (collision.gameObject.GetComponent<SpriteRenderer>().flipX == true)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * forceKnockback);
            }
            else
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * forceKnockback);
        }
    }
}
