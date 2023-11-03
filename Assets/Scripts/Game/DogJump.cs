using Assets.Scripts.Game;
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
    private GameObject MakeJumpBlocks;
    private MakeJumpBlocks MakeJumpBlocksScript;
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (Jumpable)
            {
                Debug.Log("Jump");
                Vector2 force = new Vector2(0, jump);

                //Rigidbody2D�ɗ͂�������
                Rigidbody2D.AddForce(force); //�Ƃ�
                
                JumpableTime = 1.0f;
                Jumpable = false;
                //�ԃu���b�N
                //10���Ԃ��Ƃ�
                Debug.Log("JumpCount % 10:" + JumpCount % 10);
                Debug.Log("JumpCount:" + JumpCount);
                
            }
            if (JumpCount >= 10)
            {
                MakeJumpBlocksScript.RedBlockGenerate();
                JumpCount = 0;
            }
            JumpCount++;
        }
        
    }

    void Start()
    {
        JumpableTimeTextUpdate();
        //MakeJumpBlocks���擾�I(�ŋ�)
        MakeJumpBlocksScript = MakeJumpBlocks.GetComponent<MakeJumpBlocks>();
    }

    void Update()
    {
        //�^�C�}�[���炢
        if(!Jumpable) //�W�����v�s�\�i�`���[�W�j�Ȃ�
        {
            JumpableTime -= Time.deltaTime;
            if(JumpableTime <= 0)
            {
                JumpableTime = 0;//�������i���̒l�ɂ��Ȃ����߁j
                Jumpable = true;
            }
            JumpableTimeTextUpdate();
        }
    }

    void JumpableTimeTextUpdate()
    {
        JumpableTimeText.text = $"�W�����v�ł���܂�:{Math.Round(JumpableTime,1)}�b";
    }
}