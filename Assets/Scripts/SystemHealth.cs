using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SH
{
    /// <summary>
    /// 血量系統：更新血量、介面與死亡處理
    /// </summary>
    public class SystemHealth : MonoBehaviour
    {
        #region 資料
        [SerializeField, Header("畫布傷害物件")]
        private GameObject goDamage;
        [SerializeField, Header("圖片血量")]
        private Image imgHp;
        [SerializeField, Header("文字血量")]
        private TextMeshProUGUI textHp;
        [SerializeField, Header("怪物資料")]
        private DataEnemy dataEnemy;
        [SerializeField, Header("敵人動畫控制器")]
        private Animator aniEnemy;

        private float hp;
        private string parDamage = "觸發受傷";
        #endregion

        /// <summary>
        /// 碰到會受傷的物件名稱
        /// </summary>
        [SerializeField, Header("碰到會受傷的物件名稱")]
        private string nameHurtObject;

        [Header("玩家接收傷害區域")]
        [SerializeField] private Vector3 v3DamageSize;
        [SerializeField] private Vector3 v3DamagePosition;
        [SerializeField, Header("接收傷害的圖層")]
        private LayerMask layerDamage;
        [SerializeField, Header("是否為玩家")]
        private bool isPlayer;

        private SystemSpawn systemSpawn;
        private SystemFinal systemFinal;

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.2f, 1, 0.2f, 0.5f);
            Gizmos.DrawCube(v3DamagePosition, v3DamageSize);
        }

        private void Awake()
        {
            hp = dataEnemy.hp;
            textHp.text = hp.ToString();
            systemSpawn = GameObject.Find("生成怪物系統").GetComponent<SystemSpawn>();
            systemFinal = FindObjectOfType<SystemFinal>();
        }

        private void Update()
        {
            CheckObjectInDamageArea();
        }
        /* 碰撞事件
         * 1. 兩個物件必須有一個帶有 Rigidbody
         * 2. 兩個物件必須有碰撞器 Collider
         * 3. 是否有勾選 Is Trigger
         * 3-1 兩著都沒有勾選 Is Trigger 使用 OnCollision
         */

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name.Contains(nameHurtObject))
                GetDamage(collision.gameObject.GetComponent<SystemAttack>().valueAttack);
        }

        /// <summary>
        /// 檢查物件是否進入受傷區域
        /// </summary>
        private void CheckObjectInDamageArea() 
        {
            Collider[] hits = Physics.OverlapBox(
                v3DamagePosition, v3DamageSize / 2,
                Quaternion.identity, layerDamage);
            
            if (hits.Length > 0)
            {
                GetDamage(hits[0].GetComponent<SystemAttack>().valueAttack);
                Destroy(hits[0].gameObject);
            }
        }

        [SerializeField, Header("受傷音效")]
        private AudioClip soundHurt;
        [SerializeField, Header("死亡音效")]
        private AudioClip soundDead;

        private void GetDamage(float getDamage)
        {
            hp -= getDamage;
            textHp.text = hp.ToString();
            imgHp.fillAmount = hp / dataEnemy.hp;
            aniEnemy.SetTrigger(parDamage);
            Vector3 pos = transform.position + Vector3.up;
            SystemDamage tempDamage = Instantiate(goDamage, pos, Quaternion.Euler(45, 0, 0)).GetComponent<SystemDamage>();
            tempDamage.damage = getDamage;

            SystemSound.intance.PlaySound(soundHurt, new Vector2(0.7f, 1.2f));

            if (hp <= 0) Dead();
        }

        ///<summary>
        ///死亡
        ///</summary>
        private void Dead()
        {
            SystemSound.intance.PlaySound(soundDead, new Vector2(0.7f, 1.2f));

            if (isPlayer) systemFinal.ShowFinalAndUpdateSubTitle("OVER");
            else
            {
                Destroy(gameObject);
                systemSpawn.totalCountEnemyLive--;
                DropCoin();
            }
            
        }

        /// <summary>
        /// 掉落金幣
        /// </summary>
        private void DropCoin()
        {
            int range = Random.Range(dataEnemy.v2CoinRange.x, dataEnemy.v2CoinRange.y);

            for (int i = 0; i < range; i++)
            {
                float x = Random.Range(-1, 1);
                float z = Random.Range(-1, 1);

                Instantiate(
                    dataEnemy.goCoin,
                    transform.position + new Vector3(x, 2.5f, z),
                    Quaternion.Euler(90, 180, 0));
            }
        }
    }
}

