using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public string maxHealthValue;
    public Text textElement;
    public int maxHealth = 100;
    int currentHealth;
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
    Rigidbody2D rigidbody2d;
    Vector2 lookDirection = new Vector2(1, 0);
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        textElement.text = maxHealthValue;

        //currentHealth = maxHealth;        

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
            if(jumpTimeCounter > 0)
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

        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    character.DisplayDialog();
                }
            }
        }
    

        if (maxHealth <=0)
        {
            //Destroy(gameObject);
            SceneManager.LoadScene(sceneName: "Lose");
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

    void OnCollisionEnter2D( Collision2D col)
    {
        if(col.gameObject.tag.Equals("Enemy"))
        {
            maxHealth = maxHealth - 50;
            
            //Destroy(gameObject);
        }
        
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }
}
