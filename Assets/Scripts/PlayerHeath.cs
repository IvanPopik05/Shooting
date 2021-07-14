using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeath : MonoBehaviour
{
    public int health;
    public GameObject loseObject;
    public GameObject effectsRed;
    public AudioSource audio;
    public Vector3 pos;
    public bool damaged;
    public Image damageImage;
    public float flashSpeed = 5f;                              
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public GameObject pointLight;
    public HealthUi healthUi;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EnemyFoot"))
        {
            TakeDamage();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ArrowEnemy")) 
        {
            TakeDamage();
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            pointLight.SetActive(true);
        }
        else 
        {
            pointLight.SetActive(false);
        }
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;

    }
    public void TakeDamage()
    {
        healthUi.MinusHealth();
        damaged = true;
        health -= 1;
        Instantiate(effectsRed, transform.position + pos, transform.rotation);
        audio.pitch = Random.Range(1f, 1.2f);
        audio.Play();
        if (health <= 0)
        {
            loseObject.SetActive(true);
        }
    }
}
