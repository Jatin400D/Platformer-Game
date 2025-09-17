using System.Globalization;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.InputSystem;


public class Warrior : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator Anim;


    public Transform groundCheck;
    public Transform WallCheck;
    public Transform AttackPoint;
    public CoinManager Cm;
    


    private float MovementInputDirection;
    private float nextATtackTime = 0f;
    public float PlayerSpeed = 10.0f;
    public float JumpForce = 6f;
    public float groundCheckRadius;
    public float WallCheckDistance;
    public float WallSlideSpeed;
    public float Movementforceinair;
    public float airDrafMultiplyer = 0.95f;
    public float variableJumpHeightMultiplyer = 0.5f;
    public float WallhopForce;
    public float walljumpForce;
    public float attackRate = 2f;
    public float AttackRange = 0.5f;


    [SerializeField] private AudioClip Sword;

    [SerializeField]
    private AudioClip Coin;

    private bool isWalking;
    public bool isGrounded; 
    private bool Canjump;
    private bool IstouchingWall;   
    private bool IsWallSliding;
    private bool isFacingRight = true;
    public bool Defence = false;
  

    public LayerMask whatIsGround;
    public LayerMask EnemyLayer;
  

    public Vector2 wallHopDirection;
    public Vector2 walljumpDirection;
  
   
    private int facingDirection = 1;
    public int AmountofJumps = 1;
    private int AmountofJumpLeft;
    public int AttackDamage = 2;

  

   





    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        AmountofJumpLeft = AmountofJumps;
        wallHopDirection.Normalize();
        walljumpDirection.Normalize();

    }

    
    void Update()
    {
        Checkinput();
        CheckMovementDirection();
        UpdateAnimation();
        CheckIfCanJump();
        CheckifWallSliding();
        if(isGrounded && !isWalking)
        {
            defense();
         
        }


        if (Time.time >= nextATtackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextATtackTime = Time.time + 1f / attackRate;
            }
        }
        
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        CheckSurroundings();
    }

  
    void Attack()
    {

        sOUNDmANAGER.instance.PlaySound(Sword);
        Anim.SetTrigger("Attack2");
        IsWallSliding = false;
        isWalking = false;
        Collider2D[] HitEnemies =  Physics2D.OverlapCircleAll(AttackPoint.position,AttackRange,EnemyLayer);

        foreach(Collider2D enemy in HitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(AttackDamage);
        }



    }

    void defense()
    {
        if (Input.GetMouseButton(1)  )
        {


            Anim.SetTrigger("Block");
            Defence = true;
        
        }
    }

    private void CheckifWallSliding()
    {
        if (IstouchingWall && !isGrounded && body.linearVelocity.y < 0 ) 
        {
            IsWallSliding = true;
        }
        else
        {
            IsWallSliding = false;
        }

      
    }



   
    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        IstouchingWall = Physics2D.Raycast(WallCheck.position, transform.right, WallCheckDistance, whatIsGround);
       

    }

   

    private void CheckIfCanJump()
    {
        if((isGrounded && body.linearVelocity.y <= 0) || IsWallSliding)
        {
            AmountofJumpLeft = AmountofJumps;

        }
        if(AmountofJumpLeft <= 0)
        {
            Canjump = false;
        }

        else
        {
            Canjump = true;
        }
    }

    private void CheckMovementDirection()
    {
        if (isFacingRight && MovementInputDirection < 0)
        {
            Flip();
        }

        else if (!isFacingRight && MovementInputDirection >0 )
        {
            Flip();
        }

        if(body.linearVelocity.x != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    private void UpdateAnimation()
    {
        Anim.SetBool("IsWalking", isWalking);
        Anim.SetBool("IsGrounded", isGrounded);
        Anim.SetFloat("Yvelocity", body.linearVelocity.y);
        Anim.SetBool("isWallSliding" , IsWallSliding);
    }
    private void Checkinput()
    {
        MovementInputDirection = Input.GetAxisRaw("Horizontal");


        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }


        if (Input.GetButtonUp("Jump"))
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, body.linearVelocity.y * variableJumpHeightMultiplyer);
        }
    }

    private void Jump()
    {
        if(Canjump && !IsWallSliding)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, JumpForce);
            AmountofJumpLeft--;
        }
        else if (IsWallSliding && MovementInputDirection == 0 && Canjump )
        {
            IsWallSliding = false;
            AmountofJumpLeft--;
            Vector2 forceToadd = new Vector2(WallhopForce * wallHopDirection.x - facingDirection, WallhopForce * wallHopDirection.y);
            body.AddForce(forceToadd, ForceMode2D.Impulse);

        }
        else if ( (IsWallSliding || IstouchingWall)&& MovementInputDirection != 0 && Canjump)
        {
            IsWallSliding = false;
            AmountofJumpLeft--;
            Vector2 forceToadd = new Vector2(walljumpForce * walljumpDirection.x *  MovementInputDirection, walljumpForce * walljumpDirection.y);
            body.AddForce(forceToadd, ForceMode2D.Impulse);
        }
       
    }


    private void ApplyMovement()
    {


        if (isGrounded)
        {
            body.linearVelocity = new Vector2(PlayerSpeed * MovementInputDirection, body.linearVelocity.y);
        }
        else if ( !isGrounded && !IsWallSliding && MovementInputDirection != 0)
        {
            Vector2 forcetoadd = new Vector2(Movementforceinair * MovementInputDirection, 0);
            body.AddForce(forcetoadd);


            if(Mathf.Abs(body.linearVelocity.x) > PlayerSpeed)
            {
                body.linearVelocity = new Vector2(PlayerSpeed * MovementInputDirection, body.linearVelocity.y);
            }
        }
        else if(!isGrounded && isWalking && MovementInputDirection == 0)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x * airDrafMultiplyer, body.linearVelocity.y);
        }
        if(IsWallSliding)
        {
            if(body.linearVelocity.y < -WallSlideSpeed)
            {
                body.linearVelocity = new Vector2(body.linearVelocity.x, -WallSlideSpeed);
            }
        }
    }

    private void Flip()

    {
        if (!IsWallSliding)
        {
            facingDirection *= 1;
            isFacingRight = !isFacingRight;
            transform.Rotate(0.0f, 180f, 0.0f);
        }
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);


        Gizmos.DrawLine(WallCheck.position, new Vector3(WallCheck.position.x + WallCheckDistance, WallCheck.position.y, WallCheck.position.z));

        if (AttackPoint == null)
            return;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            sOUNDmANAGER.instance.PlaySound(Coin);
            Destroy(other.gameObject);
            Cm.CoinCount++;
        }
    }

}
