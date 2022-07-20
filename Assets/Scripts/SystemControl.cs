using UnityEngine;
using System.Collections;

//�R�W�Ŷ� namespace �Ŷ��W�� { �ӪŶ������e }
namespace SH
{
    /// <summary>
    /// ���a����t��
    /// �������B�o�g�u�]
    /// </summary>
    public class SystemControl : MonoBehaviour
    {
        #region ���
        [Header("�b�Y")]
        public GameObject arrow;  
        [Header("����t��"), Range(0, 500)]
        public float speedTurn = 10.5f;  
        [Header("�u�]���s��")]
        public GameObject ball;  
        [Header("�u�]�i�o�g���`��"), Range(0, 100)]
        public int canShootBallTotal = 15;
        [Header("�u�]�ͦ��I")]
        public Transform traSpawnPoint;
        [Header("�����ѼƦW��")]
        public string parAttack = "Ĳ�o����";
        [Header("�u�]�o�g�t��"), Range(0, 5000)]
        public float speedBall = 1000;
        [Header("�u�]�o�g���j"), Range(0, 2)]
        public float intervalBall = 0.5f;

        public Animator ani;
        #endregion

        #region �ƥ�
        // Awake �b Start ���e����@��
        private void Awake()
        {
            ani = GetComponent<Animator>();    
        }
        private void Update()
        {
            ShootBall();
        }
        #endregion

        #region ��k
        /// <summary>
        /// ���ਤ��A�����⭱�V�ƹ�����m
        /// </summary> 
        private void TurnCharacter()
        {

        }

        /// <summary>
        /// �o�g�u�]�A�ھ��`�Ƶo�g�u�]����
        /// </summary> 
        private void ShootBall()
        {
            // ���U �ƹ����� ��� �b�Y
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                arrow.SetActive(true);
            }
            // ��} �ƹ����� �ͦ��õo�g�u�]
            else if (Input.GetKeyUp(KeyCode.Mouse0))//Mouse1�k Mouse2��

            {
                print("��}����I");
                arrow.SetActive(false);
                StartCoroutine(SpawnBall());
                
            }
        }
        /// <summary>
        /// �ͦ��u�]���a���j�ɶ�
        /// </summary>
        private IEnumerator SpawnBall()
        {
            for (int i = 0; i < canShootBallTotal; i++)
            {
                ani.SetTrigger(parAttack);

                // Object ���O�i�ٲ����g
                // �����z�L Object �����W�٨ϥ�
                // �ͦ� �u�];
                // Ouaternion.identity �s�ר�
                GameObject tempBall = Instantiate(ball, traSpawnPoint.position, Quaternion.identity);
                // �Ȧs�u�] ���o���餸�� �K�[���O (����.�e�� * �t��)
                // transform.forward ���⪺�e��
                tempBall.GetComponent<Rigidbody>().AddForce(transform.forward * speedBall);

                yield return new WaitForSeconds(intervalBall);
            }
        }

        /// <summary>
        /// �^���u�]
        /// </summary> 
        private void RecycleBall()
        {

        }
        #endregion
    }
}
