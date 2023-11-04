using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSensor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("GameOver!");
            Timer.CanMeasure = false;
            CatchTime.time = Timer.time;
            FadeManager.Instance.LoadScene("Result", 2.0f);
        }
    }
}
