using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.StartMenu
{
    public class Buttons : MonoBehaviour
    {
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
    }
}