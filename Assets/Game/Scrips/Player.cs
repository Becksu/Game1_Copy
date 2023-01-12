using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private float speed = 100;

   
    [SerializeField] private float jumpForce = 350;

    private bool isGround = true;
    private bool isJump = false;
    private bool isAtack = false;
    private bool isDeath = false;
    private float horizontal;
    private string curenAnim;
    private int coin = 0;
    private Vector3 savePoint;
   

    // Start is called before the first frame update
    void Start()
    {
        
        SavePoint();
        OnInit();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDeath)
        {
            return;
        }
        isGround = CheckGround();
        horizontal = Input.GetAxisRaw("Horizontal");
        if (isAtack)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        if (isGround)
        {
            if (isJump)
            {
                return;
            }
            // if (Input.GetKeyDown(KeyCode.Space) && isGround)
            //jump
            if (Input.GetKeyDown(KeyCode.Space)&&isGround)
            {
                Jump();
            }
            // chang anim run
            if (Mathf.Abs(horizontal) > 0.1f)
            {
                ChangAnim("run");

            }
            //atackk
            if (Input.GetKeyDown(KeyCode.C)) 
            {
                Debug.Log("cccccc");
                Attack();
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                Throw();
            }               
        }
        if (!isGround && rb.velocity.y < 0)
        {
            ChangAnim("fall");
            isJump = false;
        }
        //horizontal = Input.GetAxisRaw("vetical");


        if (Mathf.Abs(horizontal) > 0.1f)
            {
                ChangAnim("run");
                rb.velocity = new Vector2(horizontal * Time.fixedDeltaTime * speed, rb.velocity.y);
                //transform.localScale = new Vector3(horizontal,1,1);
                transform.rotation = Quaternion.Euler(new Vector3(0, horizontal > 0 ? 0 : 180, 0));
            }
        else if (isGround)
            {
                ChangAnim("idle");

                rb.velocity = Vector2.zero;
            }
        
    }
    public void OnInit()
    {
        isDeath = false;
        isAtack = false;

        transform.position = savePoint;
        ChangAnim("idle");
    }
   
    private bool CheckGround()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.1f, Color.blue);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, GroundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void Attack()
    {

        ChangAnim("atack");
        isAtack = true;
        Invoke(nameof(ResetAtack), 0.5f);
    }
    private void Throw()
    {
        ChangAnim("throw");
        isAtack = true;
        Invoke(nameof(ResetAtack), 0.5f);
    }
    private void Jump()
    {

        isJump = true;
        ChangAnim("jump");
        rb.AddForce(jumpForce * Vector2.up);
    }
    private void ChangAnim(string animName)
    {
        if (curenAnim != animName)
        {
            anim.ResetTrigger(animName);
            curenAnim = animName;
            anim.SetTrigger(curenAnim);
        }
    }
    private void ResetAtack()
    {
        isAtack = false;
        ChangAnim("idle");
    }
    internal void SavePoint()
    {
        savePoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            coin++;
            Destroy(collision.gameObject);
        }
        if(collision.tag == "DeathZone")
        {
            isDeath = true;
            ChangAnim("die");
        }
        Invoke(nameof(OnInit), 1f);
      
    }

}
