using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LionAI : EnemyScript
{
    //public Transform[] points;
	public Transform pointOne;
	public Transform pointTwo;
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
	private float elapsedTime;
	private float invulnerabilityTime = 20f;
	private float timer = 0.0f;

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
				print("headed to point 2");
				Invulnerable(1);
			Run(pointOne);
			goneToPointOne = true;
		} 
            if(health <= 33 && !goneToPointTwo){
				Invulnerable(2);

				print("headed to point 2");
				Run(pointTwo);
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
  
    void Run(Transform nextPoint){
		
		
	anim.SetFloat("Speed", speed);
		navAgent.destination = nextPoint.position;//points[nextPoint].position;
    }

	void Invulnerable(int section)
    {
		
		while (timer < invulnerabilityTime)
        {
			if (section == 1)
            {
				this.health = 66;
            } else if (section == 2)
            {
				health = 33;
            }
			timer += Time.deltaTime;
		}
		
    }
}