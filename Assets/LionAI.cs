using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LionAI : EnemyScript
{
    public Transform[] points;
    private int nextPoint = 0;
    private NavMeshAgent navAgent;
    private Animator anim;
    private float speed=2;
    [SerializeField] public playerMove player;
    private Ray ray;
    private RaycastHit hit;
    public float rayDistance = 5f;
    private float attackCoolDown;
    private bool goneToPointOne =false;
    private bool goneToPointTwo =false;
    public GameObject NemeanHide;

    protected override void Start()
    {
	navAgent= GetComponent<NavMeshAgent>();
	anim = GetComponent<Animator>();
	health = 100f;
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
		Die(transform.position);
	}else{
		if(!navAgent.pathPending && navAgent.remainingDistance < .1f){
			anim.SetFloat("Speed",0);
		}
		if(Physics.Raycast(ray, out hit)){
			if(hit.collider.CompareTag("Player")){
				if(hit.distance < rayDistance){
					transform.LookAt(player.Controller.transform);
					if(hit.distance<2 && attackCoolDown ==0){
						Attack();
					}
				}
			}
		}
		if(health <= 66 && !goneToPointOne){
			Run();
			goneToPointOne = true;
		} 
            if(health <= 33 && !goneToPointTwo){
			Run();
			goneToPointTwo = true;
		} 
	}
    }

    void Die(Vector3 pos){
	GameObject itemDrop = Instantiate(NemeanHide, new Vector3(0,0,0), transform.rotation);
	itemDrop.transform.position = pos + new Vector3(0f, 1.5f, 0f);
	itemDrop.AddComponent<ShieldPickUp>();
	Destroy(this.gameObject);
    }

    void Attack(){
	attackCoolDown = 5;
	anim.SetTrigger("attack");
	player.health -= Random.Range(10,21);
    }
  
    void Run(){
	anim.SetFloat("Speed", speed);
	navAgent.destination = points[nextPoint].position;
    } 
}