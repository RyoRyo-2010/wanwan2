using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSensor : MonoBehaviour
{
	private AudioSource audioSource;
	[SerializeField]
	private AudioClip GameOverSound;
    // Start is called before the first frame update
    void Start()
    {
		audioSource = GetComponent<AudioSource>();
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
			if (Timer.CanMeasure)
			{
				audioSource.PlayOneShot(GameOverSound);
			}
            Timer.CanMeasure = false;
            CatchTime.time = Timer.time;
			
            FadeManager.Instance.LoadScene("Result", 3.0f);
        }
    }
}
