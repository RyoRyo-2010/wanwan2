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

        //2段め
        [SerializeField]
        private GameObject make2TierBlockPosition;
        void Update()
        {
            timer += Time.deltaTime; //timerの値を1秒に1のペースで増やす
            if (timer > spowntime)
            {
                BlockGenerate(BlockType.White); 
                timer = 0; //timerを0に戻す。
            }
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
            
            //Quaternion.identityは回転させないことを示す言葉(らしい)
            //おーきさランダム！
            //1.8 <= 大きさ_x <= 4.0
            //0.3 <= 大きさ_y <= 1.5
            //大きさ_z = 1
            obj.transform.localScale = new Vector3(Random.Range(1.8f, 4.0f), Random.Range(0.3f, 1.5f), 1);
            Vector2 position = obj.transform.position;
            //
            //1段目か2段目か
            if(Random.Range(1,3) == 1)
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
            White,Red
        }
    }
}