using UnityEngine;

namespace SH 
{
    /// <summary>
    /// 可以吃的彈珠系統
    /// </summary>
    public class SystemBallEat : MonoBehaviour
    {
        private string nameBallPlayer = "彈珠";
        private SystemTurn systemTurn;

        private void Awake()
        {
            // 透過類型尋找物件<類型>()
            // *搜尋的類型場景上只能有一個
            systemTurn = FindObjectOfType<SystemTurn>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains(nameBallPlayer))
            {
                systemTurn.BallEat();
                Destroy(gameObject);
            }
        }
    }
}
