using UnityEngine;

namespace SH
{
    // ScriptableObject �}���ƪ���G�}�����e�ܦ���Ʀs��b Project ��
    // �����f�t CreateAssetMenu
    [CreateAssetMenu(menuName = "SH/Data Enemy", fileName = "Data Enemy")]

    public class DataEnemy : ScriptableObject
    {
        [Header("��q"), Range(0, 10000)]
        public float hp;
        [Header("�ˮ`"), Range(0, 10000)]
        public float damage;
    }
}
