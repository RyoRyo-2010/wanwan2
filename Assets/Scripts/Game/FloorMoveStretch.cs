using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMoveStretch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		//ëÂÇ´Ç≥Çí≤êÆ
		//ç∂â∫
		Vector3 left = Camera.main.ViewportToWorldPoint(new Vector3(-0.1f, 0, 0));
		Vector3 right = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, 0, 0));
		float w = right.x - left.x;
		{
			Vector3 v = this.transform.localScale;
			v.x = w;
			this.transform.localScale = v;
		}
		
		Vector3 viewPort = Camera.main.ViewportToWorldPoint(new Vector3(-0.1f, 0, 0));
		Debug.Log(viewPort);
		viewPort.z = 0;
		viewPort.x += this.transform.localScale.x / 2;
		this.transform.position = viewPort;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
