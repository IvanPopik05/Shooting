using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUi : MonoBehaviour
{
    public List<GameObject> healths;
    public PlayerHeath playerHealth;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //healths = new GameObject[transform.childCount]; //childCount - это число дочерних элементов, родитель не включён в подсчёт
        //for (int i = 0; i < healths.Length; i++)
        //{
           // healths[i] = transform.GetChild(i).gameObject; // GetChild - это число дочерних элементов по индексу
        //}
        //if (playerHealth.damaged) 
        //{
            //Destroy(transform.GetChild(0).gameObject);
        //} 
        //if(healths.Length <= 0) 
        //{
            //this.enabled = false;
        //}
    }
    public void MinusHealth() 
    {
        healths[0].SetActive(false);
        healths.RemoveAt(0);
    }
}
