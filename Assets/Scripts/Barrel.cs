using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject BangBarrelEffects;
    public GameObject explosionAudio;
    private void Update()
    {
        if (!explosionAudio)
        {
            explosionAudio.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Collider[] allColliders = Physics.OverlapSphere(transform.position,5f);
            foreach (var collider in allColliders)
            {
                BodyPart colBody = collider.GetComponent<BodyPart>();
                PlayerHeath colPlayer = collider.GetComponent<PlayerHeath>();
                if (collider.attachedRigidbody) 
                {
                    if (colBody)
                    {
                        colBody.ThisEnemy.TakeDamage();
                    }
                    if (colPlayer) 
                    {
                        colPlayer.TakeDamage();
                    }
                    Vector3 direction = (collider.transform.position - transform.position).normalized;
                    collider.attachedRigidbody.AddRelativeForce(direction * 2500f);
                }
            }
            Instantiate(BangBarrelEffects,transform.position,Quaternion.identity);
            Instantiate(explosionAudio, transform.position, Quaternion.identity);
            explosionAudio.SetActive(true);
            Destroy(gameObject);
        }
    }
}
