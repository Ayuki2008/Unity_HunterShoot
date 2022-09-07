using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

namespace SH 
{
    /// <summary>
    /// �C�������t�ΡG�ӻP��
    /// </summary>
    public class SystemFinal : MonoBehaviour
    {
        /// <summary>
        /// �C�������e������
        /// </summary>
        private CanvasGroup groupFinal;
        /// /// <summary>
        /// �C�������Ƽ��D
        /// </summary>
        private TextMeshProUGUI textSubTitle;
        /// /// <summary>
        /// ���s�C��
        /// </summary>
        private Button btnReplay;
        /// /// <summary>
        /// ���}�C��
        /// </summary>
        private Button btnQuit;

        private void Awake()
        {
            groupFinal = GameObject.Find("�C�������e������").GetComponent<CanvasGroup>();
            textSubTitle = GameObject.Find("�C�������Ƽ��D").GetComponent<TextMeshProUGUI>();
            btnReplay = GameObject.Find("���s�C��").GetComponent<Button>();
            btnQuit = GameObject.Find("���}�C��").GetComponent<Button>();
            btnReplay.onClick.AddListener(Replay); // ���U���s�C�����s�� ���� Replay ��k
            btnQuit.onClick.AddListener(Quit); // ���U���}�C�����s�� ���� Quit ��k
        }

        /// <summary>
        /// ��ܵ����e���ç�s�p���D
        /// </summary>
        /// <param name="subTitle">�p���D��r</param>
        public void ShowFinalAndUpdateSubTitle(string subTitle)
        {
            textSubTitle.text = subTitle;
            StartCoroutine(ShowFinal());
        }

        /// <summary>
        /// ��ܤ���
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
        /// ���s�C���\��
        /// </summary>
        private void Replay()
        {
            string nameCurrent = SceneManager.GetActiveScene().name; // ���o��e�����W��
            SceneManager.LoadScene(nameCurrent);
        }

        /// <summary>
        /// ���}���s�\��
        /// </summary>
        private void Quit()
        {
            Application.Quit();
        }
    }
}

