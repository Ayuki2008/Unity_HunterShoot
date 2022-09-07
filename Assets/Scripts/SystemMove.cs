using UnityEngine;
using System.Collections;

namespace SH
{
    /// <summary>
    /// 移動系統
    /// </summary>
    public class SystemMove : MonoBehaviour
    {
        /// <summary>
        /// 回合系統
        /// </summary>
        private SystemTurn systemTurn;
        private float moveDistance = 2;

        private void Awake()
        {
            systemTurn = GameObject.Find("回合系統").GetComponent<SystemTurn>();
            systemTurn.onTurnEnemy.AddListener(() => { StartCoroutine(Move()); });
        }

        private IEnumerator Move()
        {
            //print(gameObject + "往前移動");
            float moveCount = 10;
            float perDistance = moveDistance / moveCount;

            for (int i = 0; i < moveCount; i++)
            {
                transform.position -= new Vector3(0, 0, perDistance);
                yield return new WaitForSeconds(0.05f);
            }

            yield return new WaitForSeconds(1.5f);

            systemTurn.MoveEndBallEnemy();
        }
    }
}

