using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

namespace SH 
{
    /// <summary>
    /// 遊戲結束系統：勝與敗
    /// </summary>
    public class SystemFinal : MonoBehaviour
    {
        /// <summary>
        /// 遊戲結束畫面底圖
        /// </summary>
        private CanvasGroup groupFinal;
        /// /// <summary>
        /// 遊戲結束副標題
        /// </summary>
        private TextMeshProUGUI textSubTitle;
        /// /// <summary>
        /// 重新遊戲
        /// </summary>
        private Button btnReplay;
        /// /// <summary>
        /// 離開遊戲
        /// </summary>
        private Button btnQuit;

        private void Awake()
        {
            groupFinal = GameObject.Find("遊戲結束畫面底圖").GetComponent<CanvasGroup>();
            textSubTitle = GameObject.Find("遊戲結束副標題").GetComponent<TextMeshProUGUI>();
            btnReplay = GameObject.Find("重新遊戲").GetComponent<Button>();
            btnQuit = GameObject.Find("離開遊戲").GetComponent<Button>();
            btnReplay.onClick.AddListener(Replay); // 按下重新遊戲按鈕後 執行 Replay 方法
            btnQuit.onClick.AddListener(Quit); // 按下離開遊戲按鈕後 執行 Quit 方法
        }

        /// <summary>
        /// 顯示結束畫面並更新小標題
        /// </summary>
        /// <param name="subTitle">小標題文字</param>
        public void ShowFinalAndUpdateSubTitle(string subTitle)
        {
            textSubTitle.text = subTitle;
            StartCoroutine(ShowFinal());
        }

        /// <summary>
        /// 顯示介面
        /// </summary>
        private IEnumerator ShowFinal()
        {
            for (int i = 0; i < 10; i++)
            {
                groupFinal.alpha += 0.1f;
                yield return new WaitForSeconds(0.03f);
            }

            groupFinal.interactable = true;
            groupFinal.blocksRaycasts = true;
        }

        /// <summary>
        /// 重新遊戲功能
        /// </summary>
        private void Replay()
        {
            string nameCurrent = SceneManager.GetActiveScene().name; // 取得當前場景名稱
            SceneManager.LoadScene(nameCurrent);
        }

        /// <summary>
        /// 離開按鈕功能
        /// </summary>
        private void Quit()
        {
            Application.Quit();
        }
    }
}

