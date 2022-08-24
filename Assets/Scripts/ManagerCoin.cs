using UnityEngine;
using TMPro;

namespace SH
{
    /// <summary>
    /// 管理金幣：更新金幣數量
    /// </summary>
    public class ManagerCoin : MonoBehaviour
    {
        /// <summary>
        /// 金幣數量
        /// </summary>
        private TextMeshProUGUI textCoin;
        /// <summary>
        /// 金幣總數
        /// </summary>
        private int totalCion;

        private void Awake()
        {
            textCoin = GameObject.Find("金幣數量").GetComponent<TextMeshProUGUI>();
        }

        /// <summary>
        /// 添加一個金幣並更新介面
        /// </summary>
        public void AddCoinAndUpdateUI()
        {
            totalCion++;
            textCoin.text = totalCion.ToString();
        }
    }
}

