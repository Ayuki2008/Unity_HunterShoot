using UnityEngine;
using System.Collections;
using TMPro;

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
        [Header("�u�]�ƶq")]
        public TextMeshProUGUI textBallCount;

        public Animator ani;

        /// <summary>
        /// ��_�o�g�u�]
        /// </summary>
        private bool canShootBall = true;
        /// <summary>
        /// �ഫ�ƹ�����v��
        /// </summary>
        private Camera cameraMouse;
        /// <summary>
        /// �y���ഫ����骫��
        /// </summary>
        private Transform traMouse;
        #endregion

        #region �ƥ�
        // Awake �b Start ���e����@��
        private void Awake()
        {
            ani = GetComponent<Animator>();

            textBallCount.text = "x" + canShootBallTotal;

            cameraMouse = GameObject.Find("�ഫ�ƹ�����v��").GetComponent<Camera>();

            // traMouse = GameObject.Find("��Ʒƹ��ι��骫��").GetComponent<Transform>();
            traMouse = GameObject.Find("�y���ഫ����骫��").transform;

            // ���z �����ϼh�I��(�ϼh1�A�ϼh2)
            Physics.IgnoreLayerCollision(3, 3);
        }
        private void Update()
        {
            ShootBall();
            TurnCharacter();
        }

        
        #endregion

        #region ��k
        /// <summary>
        /// ���ਤ��A�����⭱�V�ƹ�����m
        /// </summary> 
        private void TurnCharacter()
        {
            // �p�G ����o�g �N���X
            if (!canShootBall) return;
            // 1. �ƹ��y��
            Vector3 posMouse = Input.mousePosition;
            print("<color=yellow>�ƹ��y�СG" + posMouse + "</color>");
            // ����v���� Y �b�@��
            posMouse.z = 25;

            // 2. �ƹ��y���ର�@�ɮy��
            Vector3 pos = cameraMouse.ScreenToWorldPoint(posMouse);
            // �N�ഫ�����@�ɮy�а��׳]�w�����⪺����
            pos.y = 0.5f;
            // 3. �@�ɮy�е����骫��
            traMouse.position = pos;

            // �������ܧ�.���V(�y���ഫ����骫��)
            transform.LookAt(traMouse);
        }

        /// <summary>
        /// �o�g�u�]�A�ھ��`�Ƶo�g�u�]����
        /// </summary> 
        private void ShootBall()
        {
            // �p�G ����o�g�u�] �N���X
            if (!canShootBall) return;

            // ���U �ƹ����� ��� �b�Y
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                arrow.SetActive(true);
            }
            // ��} �ƹ����� �ͦ��õo�g�u�]
            else if (Input.GetKeyUp(KeyCode.Mouse0))//Mouse1�k Mouse2��
            {
                // ����o�g�u�]
                canShootBall = false;

                // print("��}����I");
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
                int total = canShootBallTotal;

                ani.SetTrigger(parAttack);

                // Object ���O�i�ٲ����g
                // �����z�L Object �����W�٨ϥ�
                // �ͦ� �u�];
                // Ouaternion.identity �s�ר�
                GameObject tempBall = Instantiate(ball, traSpawnPoint.position, Quaternion.identity);
                // �Ȧs�u�] ���o���餸�� �K�[���O (����.�e�� * �t��)
                // transform.forward ���⪺�e��
                tempBall.GetComponent<Rigidbody>().AddForce(transform.forward * speedBall);

                total--;

                if (total > 0) textBallCount.text = "x" + total;
                else if (total == 0) textBallCount.text = "";

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