using UnityEngine;

namespace SH
{
    /// <summary>
    /// 音效系統：提供播放聲音的功能
    /// </summary>
    // 要求元件(類型(元件1)、類型(元件2) ...)
    // 套用此腳本至遊戲物件時會執行
    [RequireComponent(typeof(AudioSource))]
    public class SystemSound : MonoBehaviour
    {
        // 如果其他系統需要與此溝通可以使用此寫法
        // 定義一個與此腳本相同的欄位設為靜態
        // 名稱習慣會用 instance 實體
        public static SystemSound intance;

        private AudioSource aud;
        private void Awake()
        {
            // Awake 或 Start 將欄位只為此腳本
            intance = this;
            aud = GetComponent<AudioSource>();
        }

        /// <summary>
        /// 播放音效
        /// </summary>
        /// <parm name="sound">音效檔</parm>
        /// <parm name="rangeVolume">音量範圍</parm>
        public void PlaySound(AudioClip sound, Vector2 rangeVolume) 
        {
            // 取得隨機範圍的音量
            float volume = Random.Range(rangeVolume.x, rangeVolume.y);
            // 音效元件，播放一次音效(音效，音量)
            aud.PlayOneShot(sound, volume);
        }
    }
}

