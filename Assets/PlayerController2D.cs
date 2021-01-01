using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class PlayerController2D : MonoBehaviour
{
    public float runningSpeed;
    public float jumpingForce;
    public Joystick joystick;
    public Animator playerAnimator;
    public Rigidbody2D playerRigidbody;
    public Collider2D PlayerCollider;


    float horizontalMove;
    float VelocityY;
    float PositionY;
    float PositionZ;

    bool isRunning;
    bool isJumping;
    bool grounded;
   

    // Start is called before the first frame update
    void Start()
    {

        isJumping = false;
        isRunning = false;

        
    }

    
    // Update is called once per frame
    void Update()
    {
        
        horizontalMove = joystick.Horizontal;
        VelocityY = playerRigidbody.velocity.y;
        if (joystick.Horizontal >= .3f || Input.GetAxis("Horizontal") > 0)
        {
            if(grounded)
            isRunning = true;
            playerAnimator.SetBool("IsRunning", isRunning);
            playerRigidbody.velocity = new Vector2(runningSpeed, VelocityY);

        }
        else if (joystick.Horizontal <= -.3f || Input.GetAxis("Horizontal") < 0)
        {
            if(grounded)
            isRunning = true;
            playerAnimator.SetBool("IsRunning", isRunning);
            playerRigidbody.velocity = new Vector2(-runningSpeed, VelocityY);
        }
        else
        {
           playerRigidbody.velocity = new Vector2(0, VelocityY);
           isRunning = false;
           playerAnimator.SetBool("IsRunning", isRunning);

        }
      
        if(Input.GetButtonDown("Jump"))
        {
            JumpButton();
        }

      

    }
    private void FixedUpdate()
    {
        if (isJumping && grounded)
        {
            playerRigidbody.AddForce(transform.up * jumpingForce ,ForceMode2D.Impulse);
            playerAnimator.SetTrigger("IsJumping");
            isJumping = false;

        }

        /*if(!grounded && isJumping)
        {
            playerRigidbody.AddForce(transform.up * jumpingForce * Time.deltaTime);
            isJumping = false;

        }*/
    }

    private void LateUpdate()
    {
        if (horizontalMove < 0 || Input.GetAxis("Horizontal") < 0)
        {

            gameObject.transform.localScale = new Vector3(-0.15f, 0.15f, 1);
        }
        else if (horizontalMove > 0 || Input.GetAxis("Horizontal") > 0)
        {
            gameObject.transform.localScale = new Vector3(0.15f, 0.15f, 1);
        }
        else
        {
            gameObject.transform.localScale = gameObject.transform.localScale;
        }
    }
    
    public void JumpButton()
    {
        isJumping = true;
        //playerRigidbody.AddForce(transform.up * jumpingForce * Time.deltaTime);
        
    }
    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }*/


    public void SetGrounded(bool check)
    {
        grounded = check;
    }
    

}
    