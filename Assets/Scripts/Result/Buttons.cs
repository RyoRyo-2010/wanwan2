using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Result
{
    public class Buttons : MonoBehaviour
    {
        public void OneMore()
        {
            SceneManager.LoadScene("Game");
        }

        public void BackMenu()
        {
            SceneManager.LoadScene("StartMenu");
        }
    }
}