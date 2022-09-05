using UnityEngine;
using UnityEngine.Events;

namespace SH
{
    /// <summary>
    /// �^�X�t�ΡG���a�μĤH�^�X�޲z
    /// </summary>
    public class SystemTurn : MonoBehaviour
    {
        #region ���

        /// <summary>
        /// �ĤH�^�X
        /// </summary>
        public UnityEvent onTurnEnemy;

        private SystemControl systemControl;
        private SystemSpawn systemSpawn;
        private RecycleArea recycleArea;

        /// <summary>
        /// �u�]�`��
        /// </summary>
        private int totalCountBall;
        /// <summary>
        /// �Ǫ��P�i�H�Y���u�]�s���`��
        /// </summary>
        private int totalCountEnemyLive;
        /// <summary>
        /// �^���u�]�ƶq
        /// </summary>
        private int totalRecyeleBall;

        private bool canSpawn = true;

        #endregion

        private int countBallEat;

        private void Awake()
        {
            systemControl = GameObject.Find("��").GetComponent<SystemControl>();
            systemSpawn = GameObject.Find("�ͦ��Ǫ��t��").GetComponent<SystemSpawn>();
            recycleArea = GameObject.Find("�^���ϰ�").GetComponent<RecycleArea>();

            recycleArea.onRecyele.AddListener(RecyeleBall);
        }

        /// <summary>
        /// �^���u�]
        /// </summary>
        private void RecyeleBall()
        {
            totalCountBall = systemControl.canShootBallTotal;

            totalRecyeleBall++;
            //print("�u�]�^���ƶq�G" + totalRecyeleBall);

            if(totalRecyeleBall == totalCountBall)
            {
                //print("�^�������A���ĤH�^�X");
                onTurnEnemy.Invoke();
            }
        }

        /// <summary>
        /// ���ʵ�����ͦ��ĤH�P�u�]
        /// </summary>
        public void MoveEndSpawnEnemy()
        {
            if (!canSpawn) return;

            canSpawn = false;
            systemSpawn.SpawnRandomEnemy();
            Invoke("PlayerTurn", 1);
        }

        /// <summary>
        /// ���a�^�X
        /// </summary>
        private void PlayerTurn()
        {
            systemControl.canShootBall = true;
            canSpawn = true;
            totalRecyeleBall = 0;

            #region �u�]�ƶq�B�z
            systemControl.canShootBallTotal += countBallEat;
            countBallEat = 0;
            #endregion
        }

        /// <summary>
        /// �Y��u�]�ƶq���W
        /// </summary>
        public void BallEat() 
        {
            countBallEat++;
        }
    }
}

