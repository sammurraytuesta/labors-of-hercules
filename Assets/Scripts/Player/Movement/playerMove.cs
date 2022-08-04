using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float jmpHt;
    public float gravity;
    private bool isInAir;
    public float downStep;
    Vector3 velocity;
    public float airControl;
    public int health = 100;
    float Xaxis;
    float Yaxis;
    public bool hasLionDrop = false;

    public Vector3 rootMotion;
    public Animator anim;
    public CharacterController charCont;
    public CharacterController Controller { get => charCont; set => charCont = value; }

    int isSprintingParam = Animator.StringToHash("isSprinting");

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        jmpHt = 3f;
        gravity = 20f;
        downStep = 0.1f;
        airControl = 8f;
        anim = GetComponent<Animator>();
        charCont = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //mouse looking
        float mouseInput = Input.GetAxis("Mouse X");
        Vector3 lookhere = new Vector3(0, mouseInput, 0);
        transform.Rotate(lookhere);
      

        //movement
        Xaxis = Input.GetAxis("Horizontal");
        Yaxis = Input.GetAxis("Vertical");
        
        anim.SetFloat("Yaxis", Yaxis*10);
        anim.SetFloat("Xaxis", Xaxis*10);

        IsSprinting();
  
        if(health>100){
		health =100;
	  }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void OnAnimatorMove()
    {
        rootMotion += anim.deltaPosition;
    }

    private void FixedUpdate()
    {
        //is jumping in air
        if (isInAir)
        {
            velocity.y -= gravity * Time.fixedDeltaTime;
            Vector3 displacement = velocity * Time.fixedDeltaTime;
            displacement += CalculateAirControl();
            charCont.Move(displacement);
            isInAir = !charCont.isGrounded;
            rootMotion = Vector3.zero;
        }
        else
        {
            //walking on ground
            charCont.Move(rootMotion+Vector3.down*downStep);
            rootMotion = Vector3.zero;
            if (!charCont.isGrounded)
            {
                isInAir = true;
                velocity = anim.velocity;
                velocity.y = 0;
            }
        }
    }

    void IsSprinting()
    {
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        anim.SetBool(isSprintingParam, isSprinting);
    }

    void Jump()
    {
        if (!isInAir)
        {
            isInAir = true;
            velocity = anim.velocity;
            velocity.y += Mathf.Sqrt(2 * gravity * jmpHt);
        }
    }

    public Vector3 CalculateAirControl()
    {
        return ((transform.forward * Yaxis) + (transform.right * Xaxis)) * (airControl/100);
    }
}
