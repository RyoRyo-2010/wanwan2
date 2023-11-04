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
            //ŠÔ‚ğ”‚¦‚é
            time += Time.deltaTime;
            //Text‚Éo‚·
            text.text = $"{time.ToString("F1")}•b";
        }
    }
}
