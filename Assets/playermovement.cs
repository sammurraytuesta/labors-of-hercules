using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Animator anim;
    //public Vector3 point;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
       
        anim.SetFloat("forward", moveVertical);
        anim.SetFloat("sideways", moveHorizontal);
       // transform.Rotate(Vector3.up * moveHorizontal, 60 * Time.deltaTime);
    }
}
