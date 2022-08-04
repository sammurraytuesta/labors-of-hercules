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
    public float moveSpeed = 20f;
    public float lookSpeed = 20f;
    public Vector2 rotation = new Vector2(0,0);
    public float airControl;
    public int health = 100;
    float Xaxis;
    float Yaxis;
    public bool hasLionDrop = false;

    public Vector3 rootMotion;
    public Animator anim;
    public CharacterController charCont;
    public CharacterController Controller { get => charCont; set => charCont = value;}

    int isSprintingParam = Animator.StringToHash("isSprinting");

    void Start()
    {
        jmpHt = 3f;
        gravity = 20f;
        downStep = 0.1f;
        airControl = 8f;
        rotation.y = 180;
        Cursor.visible = false;
        anim = GetComponent<Animator>();
        charCont = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Xaxis = Input.GetAxis("Horizontal");
        Yaxis = Input.GetAxis("Vertical");
        
        anim.SetFloat("Yaxis", Yaxis*10);
        anim.SetFloat("Xaxis", Xaxis*10);

        Vector3 movement = new Vector3(Xaxis, 0f, Yaxis); //3d space
        transform.Translate(movement * Time.deltaTime * moveSpeed); //delta smooths move

        rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
        transform.eulerAngles = rotation;

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
