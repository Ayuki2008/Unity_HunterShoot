using UnityEngine;
using System.Collections;
using TMPro;

//命名空間 namespace 空間名稱 { 該空間的內容 }
namespace SH
{
    /// <summary>
    /// 玩家控制系統
    /// 物件旋轉、發射彈珠
    /// </summary>
    public class SystemControl : MonoBehaviour
    {
        #region 資料
        [Header("箭頭")]
        public GameObject arrow;  
        [Header("旋轉速度"), Range(0, 500)]
        public float speedTurn = 10.5f;  
        [Header("彈珠欲製物")]
        public GameObject ball;  
        [Header("彈珠可發射的總數"), Range(0, 100)]
        public int canShootBallTotal = 15;
        [Header("彈珠生成點")]
        public Transform traSpawnPoint;
        [Header("攻擊參數名稱")]
        public string parAttack = "觸發攻擊";
        [Header("彈珠發射速度"), Range(0, 5000)]
        public float speedBall = 1000;
        [Header("彈珠發射間隔"), Range(0, 2)]
        public float intervalBall = 0.5f;
        [Header("彈珠數量")]
        public TextMeshProUGUI textBallCount;

        /// <summary>
        /// 能否發射彈珠
        /// </summary>
        [HideInInspector]
        public bool canShootBall = true;
        
        public Animator ani;
        /// <summary>
        /// 轉換滑鼠用攝影機
        /// </summary>
        private Camera cameraMouse;
        /// <summary>
        /// 座標轉換後實體物件
        /// </summary>
        private Transform traMouse;
        #endregion

        #region 事件
        // Awake 在 Start 之前執行一次
        private void Awake()
        {
            ani = GetComponent<Animator>();

            textBallCount.text = "x" + canShootBallTotal;

            cameraMouse = GameObject.Find("轉換滑鼠用攝影機").GetComponent<Camera>();

            // traMouse = GameObject.Find("轉化滑鼠用實體物件").GetComponent<Transform>();
            traMouse = GameObject.Find("座標轉換後實體物件").transform;

            // 物理 忽略圖層碰撞(圖層1，圖層2)
            Physics.IgnoreLayerCollision(3, 3);
        }
        private void Update()
        {
            ShootBall();
            TurnCharacter();
        }

        
        #endregion

        #region 方法
        /// <summary>
        /// 旋轉角色，讓角色面向滑鼠的位置
        /// </summary> 
        private void TurnCharacter()
        {
            // 如果 不能發射 就跳出
            if (!canShootBall) return;
            // 1. 滑鼠座標
            Vector3 posMouse = Input.mousePosition;
            // print("<color=yellow>滑鼠座標：" + posMouse + "</color>");
            // 跟攝影機的 Y 軸一樣
            posMouse.z = 25;

            // 2. 滑鼠座標轉為世界座標
            Vector3 pos = cameraMouse.ScreenToWorldPoint(posMouse);
            // 將轉換完的世界座標高度設定為角色的高度
            pos.y = 0.5f;
            // 3. 世界座標給實體物件
            traMouse.position = pos;

            // 此物件的變形.面向(座標轉換後實體物件)
            transform.LookAt(traMouse);
        }

        /// <summary>
        /// 發射彈珠，根據總數發射彈珠物件
        /// </summary> 
        private void ShootBall()
        {
            // 如果 不能發射彈珠 就跳出
            if (!canShootBall) return;

            // 按下 滑鼠左鍵 顯示 箭頭
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                arrow.SetActive(true);
            }
            // 放開 滑鼠左鍵 生成並發射彈珠
            else if (Input.GetKeyUp(KeyCode.Mouse0))//Mouse1右 Mouse2中
            {
                // 不能發射彈珠
                canShootBall = false;

                // print("放開左鍵！");
                arrow.SetActive(false);
                StartCoroutine(SpawnBall());               
            }
        }

        [SerializeField, Header("發射彈珠音效")]
        private AudioClip soundShoot;
        /// <summary>
        /// 生成彈珠附帶間隔時間
        /// </summary>
        private IEnumerator SpawnBall()
        {
            int total = canShootBallTotal;
            for (int i = 0; i < canShootBallTotal; i++)
            {
                

                ani.SetTrigger(parAttack);

                // Object 類別可省略不寫
                // 直接透過 Object 成員名稱使用
                // 生成 彈珠;
                // Ouaternion.identity 零度角
                GameObject tempBall = Instantiate(ball, traSpawnPoint.position, Quaternion.identity);
                // 暫存彈珠 取得鋼體元件 添加推力 (角色.前方 * 速度)
                // transform.forward 角色的前方
                tempBall.GetComponent<Rigidbody>().AddForce(transform.forward * speedBall);

                SystemSound.intance.PlaySound(soundShoot, new Vector2(0.7f, 1.2f));

                total--;

                if (total > 0) textBallCount.text = "x" + total;
                else if (total == 0) textBallCount.text = "";

                yield return new WaitForSeconds(intervalBall);
            }
        }

        /// <summary>
        /// 回收彈珠
        /// </summary> 
        private void RecycleBall()
        {

        }
        #endregion
    }
}
