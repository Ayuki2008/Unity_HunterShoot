using UnityEngine;
using UnityEngine.Events;

namespace SH
{
    /// <summary>
    /// �^���ϰ�
    /// </summary>
    public class RecycleArea : MonoBehaviour
    {
        /// <summary>
        /// �^���u�]�ƥ�
        /// </summary>
        public UnityEvent onRecyele;

        /// <param name="other"></param>
        // ��ӸI�����䤤�@�ӤĿ� Is Trigger
        private void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains("�u�]"))
            {
                //print("�^���u�]");
                onRecyele.Invoke();
            }
        }
    }
}

