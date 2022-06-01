using UnityEngine;

public class LearnMethod : MonoBehaviour
{
    /*
     * 方法語法
     * 回傳類型 方法自訂名稱 () { 方法名稱 }
     * 無回傳 void
     * 方法名稱 Unity 習慣大寫開頭
     */

    private void Test()
    {
        //輸出(輸出訊息);
        print("安安");
    }

    private void PrintColorText()
    {
        print("<color=yellow>root</color>");
        print("<color=#53D6F9>colon</color>");
    }

    //自訂方法需要呼叫才會執行

    /*
     * Unity 的入口
     * 開始事件 : 播放遊戲後會執行一次
     * 初始化設定 : 初始金額、初始幾條命
     */

    private void Start()
    {
        //呼叫方法 : 方法名稱();
        Test();
        PrintColorText();
    }

     

}
