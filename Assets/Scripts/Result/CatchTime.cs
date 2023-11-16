using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchTime : MonoBehaviour
{
    public static float time;
	// Start is called before the first frame update
	[SerializeField]
	private GameObject ResultUpdate;
    void Start()
    {
		//スコア更新チェック
		bool update = ScoreManager.UpdateHighScore(time);
        GetComponent<Text>().text = $"今回の記録は、{time.ToString("F1")}秒でした。";
		Timer.CanMeasure = true;
		Timer.time = 0;
		if (!update)
		{
			Destroy(ResultUpdate);
		}
	}
 
    // Update is called once per frame
    void Update()
    {
        
    }
}
