using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject Spawn;
    public GameObject Flash;
    public Image imageAim;
    public float speed;
    public int bullets;
    public float timer;
    public float ShotPerid;
    private AudioSource audio;
    public Vector3 StartPosition;
    public Vector3 AimingPosition;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        StartPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, AimingPosition, Time.deltaTime * 8f);
            imageAim.enabled =false;
        }
        else 
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, StartPosition, Time.deltaTime * 8f);
            imageAim.enabled = true;
        }
        timer +=Time.deltaTime;
        if(Input.GetMouseButton(0) && timer > ShotPerid)
        {
            timer = 0;
            if(bullets > 0)
            {
                bullets -= 1;
                GameObject newbullet = Instantiate(bulletPrefab, Spawn.transform.position,Spawn.transform.rotation);
                Rigidbody newBul = newbullet.GetComponent<Rigidbody>();
                newBul.velocity = Spawn.transform.forward * speed;
                Flash.SetActive(true);
                Invoke("HideFlash",0.1f);
                audio.pitch = Random.Range(0.40f,1.2f);
                audio.Play();
            } else
            {
                Debug.Log("Нет пуль");
            }
        }
    }
    public void HideFlash()
    {
        Flash.SetActive(false);
    }
}
