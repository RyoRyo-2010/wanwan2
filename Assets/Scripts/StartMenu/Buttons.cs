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
            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
        }

        public void Game()
        {
            SceneManager.LoadScene("Game");
        }
    }
}