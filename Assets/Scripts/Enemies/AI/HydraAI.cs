using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HydraAI : EnemyScript
{

    private Animator anim;
    [SerializeField] public playerMove player;
    public GameObject Player;
    private Ray ray;
    private RaycastHit hit;
    public float rayDistance = 20f;
    private float attackCoolDown=0;
    public GameObject Tooth;
    private bool crab1 = false;
    private bool crab2 = false;
    private bool crab3 = false;
    public GameObject crabwave1;
    public GameObject crabwave2;
    public GameObject crabwave3;
    private int headHit = 0;
    private int[] dealDamage = {5,10,15,20};
    private bool isPoison = false;
    private float poisonTimer = 0f;
    
    // Start is called before the first frame update
    protected override void Start()
    {
		anim = GetComponent<Animator>();
		health = 200f;
		Player = GameObject.FindGameObjectWithTag("Player");
		player = Player.GetComponent<playerMove>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      ray = new Ray(transform.position + new Vector3(0f,1.5f,0f), (player.Controller.transform.position-transform.position));
	//Debug.DrawRay(transform.position+ new Vector3(0f,1.5f,0f), (player.Controller.transform.position-transform.position)*100, Color.green);
	if(attackCoolDown != 0){
		attackCoolDown -= Time.deltaTime;
	}
	if(attackCoolDown <0){
			attackCoolDown = 0;
	}
	if(poisonTimer != 0){
		poisonTimer -= Time.deltaTime;
	}
	if(poisonTimer <0){
			poisonTimer = 0;
			isPoison =false;	
			StopCoroutine("poison");
	}
	if(poisonTimer>0 && isPoison){
		StartCoroutine("poison");
	}
	if(health <= 0f){
		Die(transform.position);
	}else{
		if(Physics.Raycast(ray, out hit)){
			if(hit.collider.CompareTag("Player")){
				if(hit.distance < rayDistance){
					transform.LookAt(player.Controller.transform);
					transform.Rotate(0,-90,0);
					if(hit.distance<4 && attackCoolDown ==0){
						Attack();
					}
				}
			}
		}
	}
	if(health<=150 && !crab1){
		crab1 = true;
		crabwave1.SetActive(true);
	}if(health<=100 && !crab2){
		crab2 = true;
		crabwave2.SetActive(true);
	}if(health<=50 && !crab3){
		crab3 = true;
		crabwave3.SetActive(true);
	}
    }

    void Attack(){
	int attackDetermine = Random.Range(1,11);
	int headsAttack = 0;
	attackCoolDown = 5;
	if(attackDetermine<6){
		print("attack1");
		print(dealDamage[headHit%4]);
		anim.SetTrigger("attack1");
		player.health -= dealDamage[headHit%4];
		headHit++;
		if(headHit == 4){
			isPoison = true;
			poisonTimer = 3f;
			headHit = 0;
		}
	}else if(attackDetermine<9 && attackDetermine>5){
		print("attack2");
		anim.SetTrigger("attack2");
		player.health -= dealDamage[headHit%4]+dealDamage[(headHit+1)%4] + dealDamage[(headHit+2)%4];
		print(dealDamage[headHit%4]+dealDamage[(headHit+1)%4] + dealDamage[(headHit+2)%4]);
		headHit+=3;
		if( ((headHit%4) == 0) || (((headHit%4) - 1) == 0) || (((headHit%4) - 2) == 0)){
			isPoison = true;
			poisonTimer = 3f;
		}
	}else{
		print("attack3");
		anim.SetTrigger("attack3");
		headsAttack = 4;
		player.health -= dealDamage[headHit%4]+dealDamage[(headHit+1)%4] + dealDamage[(headHit+2)%4] + dealDamage[(headHit+3)%4];
		print(dealDamage[headHit%4]+dealDamage[(headHit+1)%4] + dealDamage[(headHit+2)%4] + dealDamage[(headHit+3)%4]);
		headHit+=4;
		if( ((headHit%4) == 0) || (((headHit%4) - 1) == 0) || (((headHit%4) - 2) == 0) || (((headHit%4) - 3) == 0)){
			isPoison = true;
			poisonTimer = 3f;
		}
	}
    }

    IEnumerator poison(){
	player.health -= Random.Range(1, 4);
	isPoison=false;
	yield return new WaitForSeconds(.5f);
	isPoison=true;
    }

    void Die(Vector3 pos){
	GameObject itemDrop = Instantiate(Tooth, new Vector3(0,0,0), transform.rotation);
	itemDrop.transform.position = pos + new Vector3(0f, 1.5f, 0f);
	itemDrop.transform.Rotate(317.273682f,255.962433f,42.8875771f);
	itemDrop.AddComponent<ToothPickUp>();
	//itemDrop.GetComponent<ToothPickUp>().player = player;
	//use inventory instead
	Destroy(this.gameObject);
    }
}
