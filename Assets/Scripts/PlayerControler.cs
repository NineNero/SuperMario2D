using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    int playerHealth = 3;
    public float playerspeed = 5.5f;
    public float jumpForce = 3f;
    string texto = "Hello World";
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rBody;
    private GroundSensor sensor;
    public Animator anim;
    float horizontal;

    GameManager gameManager;
    SFXManager sfxManager;
    
    // Start is called before the first frame update
    void Start ()     
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rBody = GetComponent<Rigidbody2D>();
        sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>();
        anim = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        playerHealth = 10;
        Debug.Log(texto);
    }   

    // Update is called once per frame
    void Update ()
    {
        if(gameManager.isGameOver == false)
        {
            horizontal = Input.GetAxis("Horizontal");

             //transform.position += new Vector3(horizontal, 0, 0) * playerspeed * Time.deltaTime;

            if(horizontal < 0)
            {
                spriteRenderer.flipX = true;
                anim.SetBool("IsRunning", true);
            }
            else if(horizontal > 0)
            {
                spriteRenderer.flipX = false;
                anim.SetBool("IsRunning", true);
            }
            else
            {
                anim.SetBool("IsRunning", false);
            }

            if(Input.GetButtonDown("Jump") && sensor.isGrounded)
            {
                rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                anim.SetBool("IsJumping", true);
            }
        }
        

    }

    void FixedUpdate()
    {
        rBody.velocity = new Vector2(horizontal * playerspeed, rBody.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Coin")
        {
            gameManager.AddCoin();
            sfxManager.CoinSound();
            Destroy(collider.gameObject);
        }
    }
}
