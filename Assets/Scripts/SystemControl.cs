using UnityEngine;

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

        public Animator ani;
        #endregion

        #region �ƥ�
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
            //��} �ƹ����� �ͦ��õo�g�u�]
            if (Input.GetKeyUp(KeyCode.Mouse0))//Mouse1�k Mouse2��

            {
                print("��}����I");

                // Object ���O�i�ٲ����g
                // �����z�L Object �����W�٨ϥ�
                // �ͦ� �u�];
                Instantiate(ball, traSpawnPoint.position, Quaternion.identity);
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
