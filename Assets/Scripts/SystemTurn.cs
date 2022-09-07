using UnityEngine;
using UnityEngine.Events;
using TMPro;

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

        private int countBallEat;

        /// <summary>
        /// �h�ƼƦr
        /// </summary>
        private TextMeshProUGUI textFloorCount;
        private int countFloor = 1;

        [SerializeField, Header("��e�h�Ƴ̤j��"), Range(1, 100)]
        private int countFloorMax = 50;
        private bool isFloorCountMax;

        #endregion

        private SystemFinal systemFinal;

        private void Awake()
        {
            systemControl = GameObject.Find("��").GetComponent<SystemControl>();
            systemSpawn = GameObject.Find("�ͦ��Ǫ��t��").GetComponent<SystemSpawn>();
            recycleArea = GameObject.Find("�^���ϰ�").GetComponent<RecycleArea>();
            textFloorCount = GameObject.Find("�h�ƼƦr").GetComponent<TextMeshProUGUI>();

            recycleArea.onRecyele.AddListener(RecyeleBall);

            systemFinal = FindObjectOfType<SystemFinal>();
        }

        [SerializeField, Header("�S�����ʪ���åB����ͦ����ɶ�"), Range(0, 3)]
        private float noMoveObjectAndDelaySpawn = 1;

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

                // �p�G�S���ĤH�N���ʵ����åͦ��ĤH�P�u�]
                if (FindObjectsOfType<SystemMove>().Length == 0)
                {
                    systemFinal.ShowFinalAndUpdateSubTitle("COMPLETE");
                }
            }
        }

        /// <summary>
        /// ���ʵ�����ͦ��ĤH�P�u�]
        /// </summary>
        public void MoveEndBallEnemy()
        {
            if (!canSpawn) return;
            if (!isFloorCountMax)
            {
                canSpawn = false;
                systemSpawn.SpawnRandomEnemy();
            }
            
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
            if (countFloor < countFloorMax)
            {
                countFloor++;
                textFloorCount.text = countFloor.ToString();
            }
            if (countFloor == countFloorMax) isFloorCountMax = true;

            if (isFloorCountMax)
            {
                if (FindObjectsOfType<SystemMove>().Length == 0)
                {
                    print("�D�Ԧ��\");
                }
            }
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

