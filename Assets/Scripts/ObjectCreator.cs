using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    public GameObject Prefab;
    public float CreationPeriod;
    public float Timer;
    public float OffsetValue;
    public bool ActiveBarrel;
    public GameObject[] PrefabsBarrel;

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > CreationPeriod) 
        {
            Timer = 0;
            Vector3 randomOffset = new Vector3(Random.Range(-OffsetValue,OffsetValue), 0f, Random.Range(-OffsetValue,OffsetValue));
            if (!ActiveBarrel)
            {
                Instantiate(Prefab, transform.position + randomOffset, transform.rotation);
            }
            if (ActiveBarrel)
            {
                GameObject barrel = PrefabsBarrel[Random.Range(0, PrefabsBarrel.Length)];
                Instantiate(barrel,transform.position + randomOffset,transform.rotation);
            }
        }
    }
}
