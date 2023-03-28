using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Horizontal")]
    [SerializeField] private float maxSpeedX = 10f;
    [SerializeField] private float horizontalAcc = 50f;
    [SerializeField] private float friction = 50f;

    [Header("Vertical")]
    [SerializeField] public float jumpVelocity = 10f;
    [SerializeField] public float fallForce = 10f;
    [SerializeField] public float maxFallSpeed = 10f;

    private CapsuleCollider2D mainCollider;
    public Rigidbody2D rb;
    private Transform t;

    private float moveDirection;
    float horizontalInput;
    public bool isGrounded;
    public bool facingRight = true;

    private List<PlayerAbility> abilities;

    public bool canDash = true;
    public int currentJumped = 0;

    public bool overrideVelocity = false;
    public Vector2 overridenVelocity;
    public Animator anim;

    void Start()
    {
        mainCollider = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        t = transform;
        abilities = new List<PlayerAbility>();

        abilities.Add(new DashAbility(50f, .15f));
        abilities.Add(new MultiJump(2));
    }

    void Update()
    {
        //animator variables
        horizontalInput = Input.GetAxis("Horizontal");
        anim.SetBool("isWalking", horizontalInput != 0);
        anim.SetBool("Grounded", isGrounded);
        //dash animation
        if (!isGrounded  && Input.GetKeyDown(KeyCode.Space))
            anim.Play("dash");

        // Move direction
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            
            moveDirection = Input.GetKey(KeyCode.A) ? Mathf.MoveTowards(moveDirection, -1, horizontalAcc * Time.deltaTime) : Mathf.MoveTowards(moveDirection, 1, horizontalAcc * Time.deltaTime);
        } else
        {
            moveDirection = Mathf.MoveTowards(moveDirection, 0, friction * Time.deltaTime);
        }

        // Update player facing
        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }

        // Fall down
        if (Input.GetKey(KeyCode.S) && !isGrounded)
        {
            float downVelocity = rb.velocity.y - fallForce * Time.deltaTime;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Abs(downVelocity) < maxFallSpeed ? downVelocity : -maxFallSpeed);
        }
        
        CheckGrounded();

        foreach (var ability in abilities) {
            StartCoroutine(ability.Apply(this));
        }
    }


    private void FixedUpdate()
    {

        // Apply movement velocity
        if (!overrideVelocity)
        {
            rb.velocity = new Vector2((moveDirection) * maxSpeedX, rb.velocity.y);
        } else
        {
            rb.velocity = overridenVelocity;
        }
    }

    private void CheckGrounded() {
        // Check if player is grounded
        if (!isGrounded)
            anim.Play("jump");

        Bounds colliderBounds = mainCollider.bounds;
        float colliderRadius = mainCollider.size.x* 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x* 0.5f, colliderRadius* 0.9f, 0);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
        //Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != mainCollider)
                {
                    isGrounded = true;
                    canDash = true;
                    currentJumped = 0;
                    break;
                }
            }
        }

        // Simple debug
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, colliderRadius, 0), isGrounded ? Color.green : Color.red);
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(colliderRadius, 0, 0), isGrounded ? Color.green : Color.red);
    }


 
       
   
}
