using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJumpBlocks : MonoBehaviour
{
    
    [SerializeField]
    private float speed;

    void Update()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("JumpBlock");
        foreach (GameObject obj in objs)
        {
            obj.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            //もし、画面外に出たら(x < -30)
            if(obj.transform.position.x < -30)
            {
                //消すぅ！
                Destroy(obj);
            }
        }
    }
}
