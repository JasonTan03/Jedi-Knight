using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    //movement
    public PlayerDeath playerDeath;
    public float movementSpeed;
    public float jumpPower;
    private float move;
    public bool isJumping;
    private bool lookRight = true;
    public bool isalive = true;
    public Rigidbody2D player;
    public Animator animator;

    //dash
    private bool canDash = true;
    private bool isDashing;
    public float dashPower;
    public float dashTime;
    public float dashCD;
    public TrailRenderer trail;

    float temp;

    //energy
    staminabar enegry;
    //health
    HeatlhBar health;

    //audio
    AudioManager audioManager;


    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        enegry = GameObject.FindGameObjectWithTag("Stamina").GetComponent<staminabar>();
        health = GameObject.FindGameObjectWithTag("Health").GetComponent<HeatlhBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        if (isalive == true) {
            move = Input.GetAxisRaw("Horizontal");
            animator.SetFloat("move", Mathf.Abs((move*movementSpeed)));
            Flip();
            player.velocity = new Vector2(move * movementSpeed, player.velocity.y);
            
        }

        Flip();

        if (((Input.GetKeyDown(KeyCode.Space) == true)|| (Input.GetKeyDown(KeyCode.W) == true)) && isalive == true && !isJumping)
        {
            audioManager.playSFX(audioManager.jump);
            animator.SetBool("IsJumping", true);
            player.velocity = Vector2.up * jumpPower;
            isJumping = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) == true && isalive == true && canDash && enegry.stamina > 20)
        {
            audioManager.playSFX(audioManager.dash);
            animator.SetTrigger("IsDashing");
            enegry.DecreaseStamina(20f);
            StartCoroutine(Dash());
        }

        if (health.hp == 0)
        {
            animator.SetBool("Death",true);
            isalive = false;
            
        }

    }

    void OnCollisionEnter2D(Collision2D ground)
    {
        if (ground.gameObject.CompareTag("ground"))
        {
            isJumping = false;
            animator.SetBool("IsJumping",false);
        }
    }
    private void Flip()
    {
        if (lookRight && move < 0f || !lookRight && move > 0f)
        {
            lookRight = !lookRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float ogGravity = player.gravityScale;
        player.gravityScale = 0f;
        player.velocity = new Vector2(transform.localScale.x * dashPower, 0f);
        trail.emitting = true;
        yield return new WaitForSeconds(dashTime);
        trail.emitting = false;
        player.gravityScale = ogGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCD);
        canDash = true;
    }
}
