using UnityEngine;

/*
 * <summary>
 * 條件式 (判斷式)
 * 1. if
 * 2. switch
 */

public class LearnCondition : MonoBehaviour
{
    public bool openDoor;
    public int combo;
    public string prop;

    // 1. 定義列舉內容
    // 2. 定義欄位

    // 列舉語法：
    // 修飾詞 列舉 列舉名稱 { 列舉內容 }
    public enum StatePlayer
    {
        Idle, Walk, Run, Hurt, Attack, Dead
    }

    // 定義欄位
    // 修飾詞 列舉名稱 欄位名稱;
    public StatePlayer statePlayer;

    private void Start()
    {
        #region if 判斷式
        // if 語法：
        // if (布林值){ 布林值 = true 會執行 }
        if (true)
        {
            print("我在判斷式 if 內");
        }
        #endregion

        #region switch 判斷式
        /*
         * switch 語法：
         * switch (比較的運算式)
         * {
         *      case 值:
         *          程式內容
         *          break;
         * }
         */

        switch (prop)
        {
            case "紅色藥水":
                print("補血");
                break;

            case "藍色藥水":
                print("補魔");
                break;

            case "黃色藥水":
                print("補體力");
                break;

            // 可省略
            default:
                print("沒有此道具~");
                break;
        }

        /*
         * 1. switch + Tab * 2
         * 2. 輸入列舉名稱 statePlayer
         * 3. Enter
         */

        switch (statePlayer)
        {
            case StatePlayer.Idle:
                print("等待");
                break;
            case StatePlayer.Walk:
                print("走路");
                break;
            case StatePlayer.Run:
                print("跑步");
                break;
            case StatePlayer.Hurt:
                print("受傷");
                break;
            case StatePlayer.Attack:
                print("攻擊");
                break;
            case StatePlayer.Dead:
                print("死亡");
                break;

        }
        #endregion
    }

    private void Update()
    {
        /*
         * 如果 openDoor = true 就開門，否則就關門
         * 如果 if 語法：
         * if (布林值) { 布林值 = true 會執行 }
         * 否則
         * else { 布林值 = false 會執行 }
         * else 一定要放在 if 下方，不能單獨使用
         */

        if (openDoor)
        {
            print("開門");
        }
        else
        {
            print("關門");  
        }

        /*
         * else if () {}
         * 無限數量
         * 連擊數 < 100 攻擊力 + 0%
         * 連擊數 >= 100 攻擊力 + 10%
         * 連擊數 >= 200 攻擊力 + 20%
         */

        if (combo < 100)
        {
            print("攻擊力 + 0%");
        }

        //有順序排法
        else if (combo >= 200)
        {
            print("攻擊力 + 20%");
        }

        //如果放在200上，執行到100以上後就會跳出迴圈
        else if (combo >= 100)
        {
            print("攻擊力 + 10%");  
        }
    }

}
