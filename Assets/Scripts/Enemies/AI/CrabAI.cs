using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabAI : EnemyScript
{
    
   private UnityEngine.AI.NavMeshAgent navAgent;
   private Animator anim;
   private float speed;
   [SerializeField] public playerMove player;
   public GameObject Player;
   private Ray ray;
   private RaycastHit hit;
   public float rayDistance = 15f;
   private float attackCoolDown;
   private float timer;
   private UnityEngine.AI.NavMeshHit navHit;
   public GameObject FullCrabPrefab;

    protected override void Start()
    {
	navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	anim = GetComponent<Animator>();
	health = 30f;
	Player = GameObject.FindGameObjectWithTag("Player");
	player = Player.GetComponent<playerMove>();
    }

    void FixedUpdate()
    {
	ray = new Ray(transform.position, (player.Controller.transform.position-transform.position));
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
					transform.LookAt(player.Controller.transform);
					if(hit.distance<1 && attackCoolDown ==0){
						Attack();
					}else{
						anim.SetFloat("Speed", speed);
						navAgent.destination = player.Controller.transform.position;
					}
				}
			}
		}
	 }	
    }

    void Attack(){
	attackCoolDown = 2;
	anim.SetTrigger("attack");
	player.health -= Random.Range(2,7);
    }

    void Die(){
	player.health += Random.Range(10, 16);
	int respawnPercent = Random.Range(1,6);
	if(respawnPercent == 2){
		GameObject crab1 = Instantiate(FullCrabPrefab, transform.position + new Vector3(3f, 0f, 0f), transform.rotation);
		GameObject crab2 = Instantiate(FullCrabPrefab, transform.position + new Vector3(-3f, 0f, 0f), transform.rotation);
		crab1.GetComponent<CrabAI>().player = player;
		crab2.GetComponent<CrabAI>().player = player;
	}
	Destroy(this.gameObject);
    }
        
}