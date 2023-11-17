using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DogJump : MonoBehaviour
{
    Vector3 move;
    [SerializeField]
    private float jump;

    [SerializeField]
    private Rigidbody2D Rigidbody2D;

    [SerializeField]
    private Text JumpableTimeText;

    private float JumpableTime = 0.0f;
    private bool Jumpable = true;

    private int JumpCount = 0;

    [SerializeField]
    private GameObject MakeMoveScripts;
    private MakeMoveScript makeMove;
	private AudioSource audioSource;
	[SerializeField]
	private AudioClip AudioClip;
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("OnJump");
        if (context.phase == InputActionPhase.Performed)
        {
            if (Jumpable)
            {
                Debug.Log("Jump");
                Vector2 force = new Vector2(0, jump);

                //Rigidbody2Dに力を加える
                Rigidbody2D.AddForce(force); //とぶ
				//効果音鳴らす
				audioSource.PlayOneShot(AudioClip);
                JumpableTime = 1.0f;
                Jumpable = false;
                //赤ブロック
                //10回飛ぶごとに
                Debug.Log("JumpCount % 10:" + JumpCount % 10);
                Debug.Log("JumpCount:" + JumpCount);
                
            }
            if (JumpCount >= 10)
            {
                makeMove.BlockGenerate(MakeMoveScript.BlockType.Red);
                JumpCount = 0;
            }
            JumpCount++;
        }
        
    }

    void Start()
    {
        JumpableTimeTextUpdate();
        //MakeJumpBlocksを取得！(最強)
        makeMove = MakeMoveScripts.GetComponent<MakeMoveScript>();
		//AudioSouceを取得
		audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //タイマーくらい
        if(!Jumpable) //ジャンプ不可能（チャージ）なら
        {
            JumpableTime -= Time.deltaTime;
            if(JumpableTime <= 0)
            {
                JumpableTime = 0;//無理やり（負の値にしないため）
                Jumpable = true;
            }
            JumpableTimeTextUpdate();
        }
    }

    void JumpableTimeTextUpdate()
    {
        JumpableTimeText.text = $"ジャンプできるまで:{Math.Round(JumpableTime,1)}秒";
    }
}