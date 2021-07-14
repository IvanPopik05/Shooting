using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashCreatorLight : MonoBehaviour
{
    public Light[] lighter;
    public float speedFlash;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Light light = lighter[Random.Range(0, lighter.Length)];
        StartCoroutine(RangeLight());
    }
    IEnumerator RangeLight()
    {
        yield return new WaitForSeconds(speedFlash);
        foreach (var item in lighter)
        {
            item.enabled = false;
        }
        yield return new WaitForSeconds(speedFlash);
        foreach (var item in lighter)
        {
            item.enabled = true;
        }
    }
}
