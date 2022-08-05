using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FoxAI : EnemyScript
{
    private NavMeshAgent navAgent;
    private Animator anim;
    private float speed;
    [SerializeField] public playerMove player;
    private Ray ray;
    private RaycastHit hit;
    public float rayDistance = 5f;
    private float attackCoolDown;
    private float wanderTime = 2f;
    private float timer;
    public float wanderRadius = 4f;
    private NavMeshHit navHit;
    

     protected override void Start()
    {
	navAgent= GetComponent<NavMeshAgent>();
	anim = GetComponent<Animator>();
	health = 60f;
    }


    void FixedUpdate()
    {
	ray = new Ray(transform.position, (player.Controller.transform.position-transform.position));
	timer += Time.deltaTime;
	if(attackCoolDown != 0){
		attackCoolDown -= Time.deltaTime;
	}
	if(attackCoolDown <0){
			attackCoolDown = 0;
		}
	if(health <= 0f){
		Die();
      }else{
		if(Physics.Raycast(ray, out hit)){
			if(hit.collider.CompareTag("Player")){
				if(hit.distance < rayDistance){
					timer = 0;
					transform.LookAt(player.Controller.transform);
					if(hit.distance<2 && attackCoolDown ==0){
						Attack();
					}else if(hit.distance<3){
						navAgent.destination = player.Controller.transform.position;
					}
				}else{
					if(timer >= wanderTime){
						Vector3 wanderPos = Wander(transform.position, wanderRadius, -1);
						anim.SetFloat("Speed", speed);
						navAgent.SetDestination(wanderPos);
						timer = 0;
					}
				}
			}
		}	
	}
        
    }
    
    Vector3 Wander(Vector3 origin, float dist, int layermask){
	Vector3 rand = Random.insideUnitSphere*dist;
	rand += origin;
	NavMesh.SamplePosition (rand, out navHit, dist, layermask);
 	return navHit.position;
    }

     void Attack(){
	attackCoolDown = 2;
	int randy = Random.Range(1,3);
	if(randy==1){
		anim.SetTrigger("Tail Attack");
		player.health -= Random.Range(2,6);
	}else{
		anim.SetTrigger("Paw Attack");
		player.health -= Random.Range(4,9);
	}
		HurtSound();

	}

	void Die(){
	Destroy(this.gameObject);
	player.health += Random.Range(10, 16);
    }
}
