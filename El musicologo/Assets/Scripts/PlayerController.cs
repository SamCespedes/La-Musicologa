using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;
    
    private Vector3 PlayerInput;
   
    public CharacterController Player;
  
    public float PlayerSpeed; 
    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 movePlayer;
    public float gravity = 9.8f;
    public float fallVelocity;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        PlayerInput = new Vector3(horizontalMove, 0, verticalMove);
        PlayerInput = Vector3.ClampMagnitude(PlayerInput, 1);

        camDirection();

        movePlayer= PlayerInput.x * camRight + PlayerInput.z * camForward;

        movePlayer = movePlayer * PlayerSpeed;

        Player.transform.LookAt(Player.transform.position + movePlayer);

        SetGravity();

        PlayerSkills();



        Player.Move(movePlayer * Time.deltaTime);

        SetGravity();
    }

    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y= 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    public void PlayerSkills()
    {
        if (Player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
        }
    }


    void SetGravity()
    {
        if (Player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;

        }
    }
}
