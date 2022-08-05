using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageEnemy : MonoBehaviour
{
    float cooldown;
    private void Update()
    {
        cooldown -= Time.deltaTime;
        if(cooldown < 0)
        {
            cooldown = 0;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") && cooldown == 0)
        {
            EnemyScript enemy = other.gameObject.GetComponent<EnemyScript>();
            enemy.health -= 10f;
            cooldown = 5;
        }
        
    
        
    }
}
