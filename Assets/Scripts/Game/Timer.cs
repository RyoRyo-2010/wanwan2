using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text text;

    public static float time;

    public static bool CanMeasure = true;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMeasure)
        {
            //時間を数える
            time += Time.deltaTime;
            //Textに出す
            text.text = $"{time.ToString("F1")}秒";
        }
    }
}
