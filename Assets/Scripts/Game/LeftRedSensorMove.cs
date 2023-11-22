using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRedSensorMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		//ビューポート座標を取得
		Vector3 viewPort = Camera.main.ViewportToWorldPoint(new Vector3(0.03f, 0, 0));
		Debug.Log(viewPort);
		viewPort.z = 0;
		viewPort.y += this.transform.localScale.y/2;
		this.transform.position = viewPort;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
