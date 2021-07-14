using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject effectsBullet;
    private void OnCollisionEnter(Collision other) {
        Instantiate(effectsBullet,gameObject.transform.position,gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
