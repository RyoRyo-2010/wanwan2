using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.StartMenu
{
	public class Buttons : MonoBehaviour
	{
		private Resetconfirm resetconfirm = Resetconfirm.none;
		[SerializeField]
		private Text text;
		
		public void CheckScores()
		{
			SceneManager.LoadScene("CheckScores");
		}

		public void Exit()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
	Application.Quit();//�Q�[���v���C�I��
#endif
		}

		public void Game()
		{
			SceneManager.LoadScene("Game");
		}

		public void DataReset()
		{
			switch (resetconfirm)
			{
				case Resetconfirm.none:
					text.text = "�{���ɁH";
					resetconfirm = Resetconfirm.really;
					break;
				case Resetconfirm.really:
					ScoreManager.MakeJsonFile();
					text.text = "�������I";
					resetconfirm = Resetconfirm.done;
					break;
			}
		}

		private enum Resetconfirm
		{
			none,really,done
		}

		public void HowToPlay()
		{
			SceneManager.LoadScene("HowToPlay");
		}
	}
}