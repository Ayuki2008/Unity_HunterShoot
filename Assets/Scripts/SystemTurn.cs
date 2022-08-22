using UnityEngine;
using UnityEngine.Events;

namespace SH
{
    /// <summary>
    /// �^�X�t�ΡG���a�μĤH�^�X�޲z
    /// </summary>
    public class SystemTurn : MonoBehaviour
    {
        /// <summary>
        /// �ĤH�^�X
        /// </summary>
        public UnityEvent onTurnEnemy;

        #region ���
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
        #endregion

        private bool canSpawn = true;

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
            print("�u�]�^���ƶq�G" + totalRecyeleBall);

            if(totalRecyeleBall == totalCountBall)
            {
                print("�^�������A���ĤH�^�X");
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
        }
    }
}

