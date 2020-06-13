using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Playerの操作を担当するスクリプト
public class PlayerController : MonoBehaviour
{

    Vector3 inputMove;

    [SerializeField]
    float moveSpeed = 5f;          // 移動速度

    [SerializeField]
    float jumpPower = 5f;

    Vector3 velocity;
    [SerializeField]
    float gravity = 12f; 

    //　レイを飛ばす体の位置
    [SerializeField]
    private Transform playerRayPosition;
    //　レイの距離
    [SerializeField]
    private float charaRayRange = 0.2f;

    CharacterController characterController;
    Animator animator;

    bool jumpStartFlag;
    bool jumpEndFlag;

    private bool rayIsGround;                               // 光線が地面に到達しているかどうかの判定フラグ
    private bool isGround;                                  // 地面の接地フラグ
    private bool doubleJumpFlag;                            // 2段ジャンプのフラグ

    Vector3 cameraForward;
    Vector3 moveForward;

    int airAttackCount;

    [SerializeField]
    int maxAirAttackCount = 1;

    PlayerAnimationEvent playerAnimationEvent;

    Status playerStatus;

    //public GameObject effectManagerObj;
    //EffectManager effectManager;

    

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerAnimationEvent = GetComponent<PlayerAnimationEvent>();
        animator = GetComponent<Animator>();
        playerStatus = GetComponent<Status>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //effectManager = effectManagerObj.GetComponent<EffectManager>();

       

    }

    void Update()
    {

        RayIsGround();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //effectManager.Effect1Emission(Vector3.zero, Quaternion.identity);
            
        }

        //　キャラクターコライダが接地、またはレイが地面に到達している場合
        if ( (characterController.isGrounded || RayIsGround() ) && velocity.y < 0)
        {
            isGround = true; 
            velocity.y = 0;
            doubleJumpFlag = false;
            airAttackCount = 0;
        }
        else
        {
            isGround = false;
        }

        animator.SetBool("IsGround", isGround);

        Damage();
        Jump();
        Attack();

        if (!animator.GetCurrentAnimatorStateInfo(1).IsTag("Attack") && !animator.GetCurrentAnimatorStateInfo(2).IsTag("Damage"))
        {
            Movement();
        }
        else
        {
            animator.SetFloat("Speed", 0f);
            return;
        }
       
        velocity.x = moveForward.x;
        velocity.z = moveForward.z;

        characterController.Move(velocity * moveSpeed * Time.deltaTime);
        velocity.y -= gravity * Time.deltaTime;
       
    }

    // -----------------------------------------------------------------------------------------------------------
    // Rayを用いた地面との接地判定
    bool RayIsGround()
    {
        //　Playerが地面と接地していない時はRay(光線)を飛ばして確認する
        if (!characterController.isGrounded)
        {
            

            if (Physics.Linecast(playerRayPosition.position, (playerRayPosition.position - transform.up * charaRayRange)))
            {
                rayIsGround = true;
            }
            else
            {
                rayIsGround = false;
            }
            Debug.DrawLine(playerRayPosition.position, (playerRayPosition.position - transform.up * charaRayRange), Color.red);
            Debug.Log(rayIsGround);
        }

        return rayIsGround;
    }

    // プレイヤーの移動
    void Movement()
    {
        
        //　地面に接地している時は初期化
        if (!isGround)
        {
            // 光線を飛ばして接地確認をする際は重力だけは働かせておく、XとY軸は初期化
            velocity = new Vector3(0f, velocity.y, 0f);
        }

        inputMove = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (inputMove.magnitude != 0f)
        {
            inputMove.Normalize();
            animator.SetFloat("Speed", inputMove.magnitude);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }

        cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        moveForward = cameraForward * inputMove.z + Camera.main.transform.right * inputMove.x;

        // 向きを進行方向に変更する
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
  
    }

    // Playerのジャンプ
    void Jump()
    {

        if (Input.GetButtonDown("Jump"))
        {

            if (isGround)
            {
                animator.SetTrigger("Jump");
                velocity.y = jumpPower;
            }
            // 地面に接地していない And 2段ジャンプのフラグがfalse(2段ジャンプしていない)
            else if (!isGround && !doubleJumpFlag)
            {
                animator.SetTrigger("Jump");
                velocity.y = jumpPower;
                doubleJumpFlag = true;
            }

        }

        animator.SetFloat("JumpSpeed", velocity.y);

    }
    // Playerの攻撃
    void Attack()
    {
       
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(isGround)
            {
                animator.SetTrigger("Attack");
            }
            else if (!isGround && (airAttackCount < maxAirAttackCount) && velocity.y != 0)
            {
                animator.SetTrigger("AirAttack");
                velocity.y = jumpPower;
                airAttackCount++;
            }
        }
           
    }

    // Playerのダメージ
    void Damage()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse1) && isGround)
        {
            playerStatus.Damage(1);

            if (playerStatus.hitPoint >= 1)
            {
                animator.SetTrigger("Damage");
            }
            else
            {
                animator.SetBool("Die", true);
            }
           
        }

    }

    // -----------------------------------------------------------------------------------------------------------
   
}
