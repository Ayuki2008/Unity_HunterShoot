using UnityEngine;

/*
 * 藍圖 -> 物件
 * 1. 場景上的遊戲物件
 * 2. 添加元件 Add Component
 * 3. 選取此類別
 */

public class Car : MonoBehaviour
{
    /*
     * < 欄位 field 語法 > (變數 variable) 
     * 修飾詞 資料類型 欄位自訂名稱 指定 值 結束符號
     * 修飾此資料的存取權限
     * 
     * 兩大基本修飾詞
     * public  公開 : 允許外部存取，顯示在屬性面板
     * private 私人 : 不允許外部存取，不顯示在屬性面板(預設值，可省略)
     */

    /*
     * 欄位屬性語法
     * [屬性名稱(值)]
     * 
     * 1. 提示 Tooltip
     * 2. 標題 Header
     * 3. 範圍 Range #僅限整數與浮點數
     */

    [Range(1, 50)]
    [Tooltip("汽車的重量，單位是噸。")]
    public int weight = 3; // 重量

    [Header("汽車的高度"), Range(1, 10)] // 兩個屬性一起寫
    public float height = 3.5f; // 高度

    [Header("汽車的品牌名稱")]
    public string brand = "賓士"; // 品牌

    [Header("是否有天窗")]
    [Tooltip("設定汽車是否有天窗")]
    public bool hasSkyWindow = true; // 是否有天窗
}
