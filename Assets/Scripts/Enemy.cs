using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum AIState
    {
        Patrol,
        Seek,
        Attack,
        Die
    }
    [Space(5), Header("Base Stats")]
    public AIState state;
    public float curHealth, maxHealth, moveSpeed, attackRange, attackSpeed, sightRange, baseDamage;
    public int curWaypoint,difficulty;
    public bool isDead;
    [Space(5), Header("Base References")]
    public GameObject self;
    public Transform player;
    public Transform waypointParent;
    protected Transform[] waypoints;
    public NavMeshAgent agent;
    public GameObject healthCanvas;
    public Image healthBar;
    public Animator anim;
    private void Start()
    {
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
        agent = self.GetComponent<NavMeshAgent>();
        curWaypoint = 1;
        agent.speed = moveSpeed;
        anim = self.GetComponent<Animator>();
        healthCanvas = self.GetComponent<Wolf>().healthCanvas;
        healthBar = self.GetComponent<Wolf>().healthBar;
        Patrol();
    }
    private void Update()
    {
        anim.SetBool("Walk", false);
        anim.SetBool("Run", false);
        anim.SetBool("Attack", false);

        Patrol();
        Seek();
        Attack();
        Die();
       /* if (healthBar.fillAmount < 1 && healthBar.fillAmount > 0)
        {
            
            healthCanvas.transform.LookAt(Camera.main.transform);
            healthCanvas.transform.Rotate(0, 180, 0);
        }
        else if (healthCanvas.activeSelf == true)
        {
        }*/
    }
 
    public void Patrol()
    {
        
        if(waypoints.Length == 0 || Vector3.Distance(player.position,self.transform.position ) <= sightRange || curHealth < 0)
        {
            return;
        }
        state = AIState.Patrol;
        anim.SetBool("Walk", true);
        //DO NOT CONTINUE IF NO WAYPOINTS
        //follow waypoints
        //Set agent to target
        agent.destination = waypoints[curWaypoint].position;
        //are we at the waypoint
        if(self.transform.position.x == agent.destination.x && self.transform.position.z == agent.destination.z)
        { 
            if(curWaypoint < waypoints.Length-1)
            {
                //if so go to next waypoint
                curWaypoint++;
            }
            else
            {
                //if at end of patrol go to start
                curWaypoint = 1;
            }
        }   
    }
    public void Seek()
    {
        //if the player is out of our sight range or inside our attack range
        if (Vector3.Distance(player.position, self.transform.position) > sightRange || Vector3.Distance(player.position, self.transform.position) < attackRange || curHealth < 0)
        {
            //stop seeking
            return;
        }
        state = AIState.Seek;
        anim.SetBool("Run", true);

        //if player in sight range and not attack range then chase
        agent.destination = player.position;
    }
    public virtual void Attack()
    {
        if(Vector3.Distance(player.position, self.transform.position) > attackRange || curHealth < 0 || player.GetComponent<PlayerHandler>().curHealth < 0)
        {
            return;
        }
        state = AIState.Attack;
        anim.SetBool("Attack", true);

        Debug.Log("Attack");
        //if player in attack range attack
    }
    public void Die()
    {
        //if we are alive
        if (curHealth > 0 )
        {
            //dont run this
            return;
        }
        //else we are dead so run this
        state = AIState.Die;
        if(!isDead)
        anim.SetTrigger("Die");
        isDead = true;
        agent.destination = self.transform.position;
        //DropLoot
    }
}
