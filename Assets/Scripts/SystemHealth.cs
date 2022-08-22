using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SH
{
    /// <summary>
    /// ��q�t�ΡG��s��q�B�����P���`�B�z
    /// </summary>
    public class SystemHealth : MonoBehaviour
    {
        #region ���
        [SerializeField, Header("�e���ˮ`����")]
        private GameObject goDamage;
        [SerializeField, Header("�Ϥ���q")]
        private Image imgHp;
        [SerializeField, Header("��r��q")]
        private TextMeshProUGUI textHp;
        [SerializeField, Header("�Ǫ����")]
        private DataEnemy dataEnemy;
        [SerializeField, Header("�ĤH�ʵe���")]
        private Animator aniEnemy;

        private float hp;
        private string parDamage = "Ĳ�o����";
        #endregion

        private SystemSpawn systemSpawn;

        private void Awake()
        {
            hp = dataEnemy.hp;
            textHp.text = hp.ToString();
            systemSpawn = GameObject.Find("�ͦ��Ǫ��t��").GetComponent<SystemSpawn>();
        }

        /* �I���ƥ�
         * 1. ��Ӫ��󥲶����@�ӱa�� Rigidbody
         * 2. ��Ӫ��󥲶����I���� Collider
         * 3. �O�_���Ŀ� Is Trigger
         * 3-1 ��۳��S���Ŀ� Is Trigger �ϥ� OnCollision
         */

        private void OnCollisionEnter(Collision collision)
        {
            // print("�I���쪫��G" + collision.gameObject);

            GetDamage();
        }

        private void GetDamage()
        {
            float getDamage = 100;
            hp -= getDamage;
            textHp.text = hp.ToString();
            imgHp.fillAmount = hp / dataEnemy.hp;
            aniEnemy.SetTrigger(parDamage);
            Vector3 pos = transform.position + Vector3.up;
            SystemDamage tempDamage = Instantiate(goDamage, pos, Quaternion.Euler(45, 0, 0)).GetComponent<SystemDamage>();
            tempDamage.damage = getDamage;

            if (hp <= 0) Dead();
        }

        ///<summary>
        ///���`
        ///</summary>
        private void Dead()
        {
            //print("���`");
            Destroy(gameObject);
            systemSpawn.totalCountEnemyLive--;
        }
    }
}

