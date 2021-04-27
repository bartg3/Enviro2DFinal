using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool m_FacingRight = true;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool IsJumping;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            IsJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetKey(KeyCode.Space) && IsJumping == true)
        {
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Ejimas1);
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                IsJumping = false;

            }
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            IsJumping = false;
        }

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isRunning", true);

        }
        else 
        {
            anim.SetBool("isRunning", false);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            anim.SetTrigger("jumping");
        }
        
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(m_FacingRight == false && moveInput > 0)
        {
            Flip();
        }

        else if(m_FacingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        m_FacingRight = !m_FacingRight;
        
        transform.Rotate(0f, 180f, 0f);
    }
}
