using UnityEngine;

namespace SH 
{
    /// <summary>
    /// 攻擊資料
    /// </summary>
    [CreateAssetMenu(menuName = "SH/Data Attack" , fileName = "Data Atack")]   
    public class DataAttack : ScriptableObject
    {
        [Header("攻擊力"), Range(0, 10000)]
        public float attack;
        [Header("攻擊力浮動"), Range(0, 100)]
        public float attackFloat;
    }
}

