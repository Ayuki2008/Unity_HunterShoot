// 單行註解(說明、標記)
/*
 * 多行註解
 * 多行註解
 */

// 藍色 保留字
// 白色 名稱
// 綠色 資料類型
using UnityEngine;

// 修飾詞_類別(藍圖)_類別名稱_繼承(物件導向程式設計 OOP 三大原則)
public class LearnData : MonoBehaviour
{
    // LearnData 類別成員區域

    /* 
     * 儲存資料方式:
     * 欄位 field (儲存各種資料)
     * 
     * 欄位語法:
     * 資料類型 欄位自訂名稱 結束符號;
     */
    int hp; //定義一筆整數資料(int) 名稱叫做 hp

    /*
     * 資料類型:四大基本類型
     * 整　數:保存正負沒有小數點的資料 int
     * 浮點數:保存正負有小數點的資料 float
     * 字　串:保存文字資訊(玩家名、技能名、對話內容) string
     * 布林值:保存有&沒有 bool
     */

    int lv;
    float exp;
    string playerName; //如果有兩個單字以上，第二個單字後大寫
    bool hasCureSkill; //是否有治癒技能
}

// 非 LearnData 類別成員區域
