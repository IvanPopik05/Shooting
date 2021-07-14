using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public GameObject ArrowPrefab;
    public GameObject Spawn;
    public float speed;
    public float timer;
    public float spownTimer;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spownTimer)
        {
            timer = 0;
            GameObject newbullet = Instantiate(ArrowPrefab, Spawn.transform.position, Spawn.transform.rotation);
            Rigidbody newBul = newbullet.GetComponent<Rigidbody>();
            newBul.velocity = Spawn.transform.forward * speed;
        }
    }
}
