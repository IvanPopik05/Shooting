using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent nav;
    public GameObject target;
    public GameObject effectsRed;
    public Animator anim;
    public BodyPart[] allBodyParts;
    public float dist;
    public int health;
    public Vector3 pos;
    public bool activeArcher;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        if (!activeArcher) 
        {
            nav = GetComponent<NavMeshAgent>();
        }
        pos = new Vector3(0, 1.449f, 0.307f);
    }
    private void Update()
    {
        dist = Vector3.Distance(transform.position, target.transform.position);
        if (!activeArcher) 
        {
            nav.destination = target.transform.position;
            if (dist > 2)
            {
                anim.SetBool("Attack", false);
                nav.speed = 2;
            }
            else
            {
                anim.SetBool("Attack", true);
                nav.speed = 0;
            }
        }
    }
    public void TakeDamage()
    {
        if (health >= 0) 
        {
            health -= 1;
            Instantiate(effectsRed, transform.position + pos, transform.rotation);
            if (!activeArcher) 
            {
                anim.SetTrigger("Hit");
            }
            return;
        }
        if (health <= 0) 
        {
            if (!activeArcher) 
            {
                nav.enabled = false;
                anim.enabled = false;
            }
            this.enabled = false;
            foreach (var bodyParts in allBodyParts)
            {
                Rigidbody rb = bodyParts.GetComponent<Rigidbody>();
                rb.isKinematic = false;
                rb.AddRelativeForce(0f,3000f,0f);
                rb.AddRelativeForce(-transform.forward * 3500f);
            }
            Destroy(gameObject, 25f);
        }
    }
}
