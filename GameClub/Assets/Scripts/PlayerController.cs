using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator anim;
    public int moveSpeed;
    public float jumpSpeed = 1f, jumpFrequency = 1f, nextJumpTime;

    public Transform groundObjectPosition;
    public float groundCheckRadius;
    public LayerMask groundObjectLayer;

    public bool isGrounded = false;

    public float horizontal;
    int ability;
    // Start is called before the first frame update
    void Start()
    {
        ability = DataMenager.Instance.ability;
        moveSpeed += ability;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        /*DataMenager.Instance.BulletDamage += power;
        print(DataMenager.Instance.bulletDamage.ToString());*/
    }

    // Update is called once per frame
    void Update()
    {
        
        HorizontalMove();
        OnGroundCheck();
    }
    void HorizontalMove()
    {
        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        flipFace();
        setAnim();
        Jump();
        
    }
    void flipFace()
    {
        if (horizontal < 0)
        {
            sprite.flipX = true;
        }
        else if(horizontal > 0)
        {
            sprite.flipX = false;
        }
    }
    void setAnim()
    {
        if (horizontal < 0 || horizontal > 0)
        {
            anim.SetBool("RunAnimation", true);
        }
        else
        {
            anim.SetBool("RunAnimation", false);
        }
    }
    void Jump()
    {
        if(Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            rb.AddForce(new Vector2(0f, jumpSpeed));
        }
    }
    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundObjectPosition.position, groundCheckRadius, groundObjectLayer);
        anim.SetBool("isGroundedAnim", isGrounded);
    }

    
}
