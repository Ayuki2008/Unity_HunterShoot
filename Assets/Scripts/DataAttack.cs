using UnityEngine;

namespace SH 
{
    /// <summary>
    /// �������
    /// </summary>
    [CreateAssetMenu(menuName = "SH/Data Attack" , fileName = "Data Atack")]   
    public class DataAttack : ScriptableObject
    {
        [Header("�����O"), Range(0, 10000)]
        public float attack;
        [Header("�����O�B��"), Range(0, 100)]
        public float attackFloat;
    }
}

