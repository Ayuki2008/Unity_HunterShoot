using UnityEngine;

namespace SH
{
    /// <summary>
    /// ���Ĩt�ΡG���Ѽ����n�����\��
    /// </summary>
    // �n�D����(����(����1)�B����(����2) ...)
    // �M�Φ��}���ܹC������ɷ|����
    [RequireComponent(typeof(AudioSource))]
    public class SystemSound : MonoBehaviour
    {
        // �p�G��L�t�λݭn�P�����q�i�H�ϥΦ��g�k
        // �w�q�@�ӻP���}���ۦP�����]���R�A
        // �W�ٲߺD�|�� instance ����
        public static SystemSound intance;

        private AudioSource aud;
        private void Awake()
        {
            // Awake �� Start �N���u�����}��
            intance = this;
            aud = GetComponent<AudioSource>();
        }

        /// <summary>
        /// ���񭵮�
        /// </summary>
        /// <parm name="sound">������</parm>
        /// <parm name="rangeVolume">���q�d��</parm>
        public void PlaySound(AudioClip sound, Vector2 rangeVolume) 
        {
            // ���o�H���d�򪺭��q
            float volume = Random.Range(rangeVolume.x, rangeVolume.y);
            // ���Ĥ���A����@������(���ġA���q)
            aud.PlayOneShot(sound, volume);
        }
    }
}

