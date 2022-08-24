using UnityEngine;
using TMPro;

namespace SH
{
    /// <summary>
    /// �޲z�����G��s�����ƶq
    /// </summary>
    public class ManagerCoin : MonoBehaviour
    {
        /// <summary>
        /// �����ƶq
        /// </summary>
        private TextMeshProUGUI textCoin;
        /// <summary>
        /// �����`��
        /// </summary>
        private int totalCion;

        private void Awake()
        {
            textCoin = GameObject.Find("�����ƶq").GetComponent<TextMeshProUGUI>();
        }

        /// <summary>
        /// �K�[�@�Ӫ����ç�s����
        /// </summary>
        public void AddCoinAndUpdateUI()
        {
            totalCion++;
            textCoin.text = totalCion.ToString();
        }
    }
}

