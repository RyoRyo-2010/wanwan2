using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//( �L�́M)���Q�[����郂�i�I
//���������������I
public class MakeMoveScript : MonoBehaviour
{
	[SerializeField]
	private GameObject JumpBlock;
	public GameObject RedJumpBlock;
	float timer = 0;
	[SerializeField]
	float spownTime = 2; //2�b���Ƃɐ���������
	[SerializeField]
	private float speed;
	void Update()
	{
		timer += Time.deltaTime; //timer�̒l��1�b��1�̃y�[�X�ő��₷
		if (timer > spownTime)
		{
			BlockGenerate(BlockType.White);
			timer = 0; //timer��0�ɖ߂��B
		}

		//��������
		GameObject[] objs = GameObject.FindGameObjectsWithTag("JumpBlock");
		foreach (GameObject obj in objs)
		{
			obj.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
			//�����A��ʊO�ɏo����(x < -30)
			if (obj.transform.position.x < -30)
			{
				//�������I
				Destroy(obj);
			}
		}

		//�X�s�[�h�����Â�����
		speed = 0.05f * Timer.time + 3.17f;
		//�u���b�N�̖��x��������
		spownTime = -0.21f * speed + 2.68f;
	}

	public void BlockGenerate(BlockType blockType)
	{
		GameObject obj = null;
		switch (blockType)
		{
			case BlockType.White:
				obj = Instantiate(JumpBlock, this.transform.position, Quaternion.identity);
				break;
			case BlockType.Red:
				obj = Instantiate(RedJumpBlock, this.transform.position, Quaternion.identity); ;
				break;
		}

		//Quaternion.identity�͉�]�����Ȃ����Ƃ��������t(�炵��)
		//���[���������_���I
		//1.8 <= �傫��_x <= 4.0
		//0.3 <= �傫��_y <= 1.5
		//�傫��_z = 1
		obj.transform.localScale = new Vector3(Random.Range(1.8f, 4.0f), Random.Range(0.3f, 1.5f), 1);
		Vector2 position = obj.transform.position;
		//
		//1�i�ڂ�2�i�ڂ�
		if (Random.Range(1, 3) == 1)
		{
			position.y = Random.Range(-3.5f, -2.6f);
		}
		else
		{
			position.y = Random.Range(0.0f, 2.0f);
		}
		obj.transform.position = position;
	}

	public enum BlockType
	{
		White, Red
	}
}
