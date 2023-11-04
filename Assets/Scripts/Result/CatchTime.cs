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
        GetComponent<Text>().text = $"ç°âÒÇÃãLò^ÇÕÅA{time.ToString("F1")}ïbÇ≈ÇµÇΩÅB";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
