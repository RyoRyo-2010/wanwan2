using System.Collections;
using UnityEngine;
//( ´∀｀)＜ゲーム作るモナ！
//いえええええい！
namespace Assets.Scripts.Game
{
    public class MakeJumpBlocks : MonoBehaviour
    {
        [SerializeField]
        private GameObject JumpBlock;
        public GameObject RedJumpBlock;
        float timer = 0;
        float spowntime = 2; //2秒ごとに生成させる
        void Update()
        {
            timer += Time.deltaTime; //timerの値を1秒に1のペースで増やす
            if (timer > spowntime)
            {
                BlockGenerate(); 
                timer = 0; //timerを0に戻す。
            }
        }

        void BlockGenerate()
        {
            GameObject obj = Instantiate(JumpBlock, this.transform.position, Quaternion.identity);
            //Quaternion.identityは回転させないことを示す言葉(らしい)
            //おーきさランダム！
            //1.8 <= 大きさ_x <= 4.0
            //0.3 <= 大きさ_y <= 1.5
            //大きさ_z = 1
            obj.transform.localScale = new Vector3(Random.Range(1.8f, 4.0f), Random.Range(0.3f, 1.5f), 1);
        }

        public void RedBlockGenerate()
        {
            GameObject obj = Instantiate(RedJumpBlock, this.transform.position, Quaternion.identity);
            //Quaternion.identityは回転させないことを示す言葉(らしい)
            //おーきさランダム！
            //1.8 <= 大きさ_x <= 4.5
            //0.3 <= 大きさ_y <= 1.5
            //大きさ_z = 1
            obj.transform.localScale = new Vector3(Random.Range(1.8f, 4.5f), Random.Range(0.3f, 1.5f), 1);
        }
    }
}