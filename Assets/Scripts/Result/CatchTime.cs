using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchTime : MonoBehaviour
{
    public static float time;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = $"今回の記録は、{time.ToString("F1")}秒でした。";
		Timer.CanMeasure = true;
		Timer.time = 0;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
