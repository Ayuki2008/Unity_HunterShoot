using UnityEngine;

namespace SH 
{
    /// <summary>
    /// �i�H�Y���u�]�t��
    /// </summary>
    public class SystemBallEat : MonoBehaviour
    {
        private string nameBallPlayer = "�u�]";
        private SystemTurn systemTurn;

        private void Awake()
        {
            // �z�L�����M�䪫��<����>()
            // *�j�M�����������W�u�঳�@��
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
