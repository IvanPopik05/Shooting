using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(2)) 
        {
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = 0.02f * 0.2f;
        }
        if (Input.GetMouseButtonUp(2)) 
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
        }
    }
}
