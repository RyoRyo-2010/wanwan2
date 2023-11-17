using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FirstSelect : MonoBehaviour
{
	[SerializeField]
	private GameObject firstSelect;
	// Start is called before the first frame update
	void Start()
    {
		EventSystem.current.SetSelectedGameObject(firstSelect);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
