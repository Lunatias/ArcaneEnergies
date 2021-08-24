using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{

    //Speed of character movement and height of the jump. Set these values in the inspector.
    public float speed;
    public Animator playerAnimator;
    public SpriteRenderer playerSprite;

    //Assigning a variable where we'll store the Rigidbody2D component.
    private Rigidbody2D rb;

    private bool onGround;

    //assign variable for health
    public float health, maxHealth;
    public HealthBar healthBar;

    //method to take damage
    public void TakeDamage() {
        if (health >0) {
            health -= 1;
            healthBar.UpdateHealthBar();
        }

    }

    public void RecoverDamage() {
        if (health < maxHealth) {
            health += 1;
            healthBar.UpdateHealthBar();
        }
        
        
    }
    


    // Start is called before the first frame update
    void Start()
    {
        //Sets our variable 'rb' to the Rigidbody2D component on the game object where this script is attached.
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
    


        //Movement code for left and right arrow keys.
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (playerSprite != null)
            {
                playerSprite.flipX = true;
            }
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(+speed, rb.velocity.y);
            if (playerSprite != null)
            {
                playerSprite.flipX = false;
            }


        }



        //ELSE if we're not pressing an arrow key, our velocity is 0 along the X axis, and whatever the Y velocity is (determined by jump)
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            this.TakeDamage();
        } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            this.RecoverDamage();
        }

        if (playerAnimator != null)
        {
            playerAnimator.SetFloat("speed", rb.velocity.magnitude);
        }


    }


    
}