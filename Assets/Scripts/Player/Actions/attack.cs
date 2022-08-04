using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class attack : MonoBehaviour
{
    public bool isColliding;
    GameObject enemy;
    public EnemyScript enemyScript;
    Animator anim;
    float playerDamage;
    private void Start()
    {
        anim = GetComponent<Animator>();
        playerDamage = Random.Range(7,11);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("attack");
            if (isColliding)
            {
                
                enemyScript.health -= playerDamage;
            }
        }
        anim.SetBool("attacking", false);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isColliding = true;
            enemyScript = other.gameObject.GetComponent<EnemyScript>();
            print("enemy in sights");
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        isColliding = false;
    }
}
