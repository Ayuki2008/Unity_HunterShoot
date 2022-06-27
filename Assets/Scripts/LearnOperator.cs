using UnityEngine;

/*
 * <summary>
 * �ǲ߹B��l
 * 1. �ƾǹB��l
 * 2. ����B��l
 * 3. �޿�B��l
 */    

public class LearnOperator : MonoBehaviour
{
    private float a = 10;
    private float b = 3;

    private int c = 99;
    private int d = 1;

    private int diamond = 1;
    private int hp = 100;

    private void Start()
    {
        #region �ǲ߹B��l
        /*
         * �[ +
         * �� -
         * �� *
         * �� /
         * �l %
         */

        print("�[�k�G" + (a + b));  //13
        print("��k�G" + (a - b));  //7
        print("���k�G" + (a * b));  //30
        print("���k�G" + (a / b));  //3.333
        print("�l�k�G" + (a % b));  //1
        #endregion

        #region ����B��l
        /*
         * �p�� <
         * �j�� >
         * �p�󵥩� <=
         * �j�󵥩� >=
         * ������ !=
         * ���� ==
         */

        // ����B��l�����G�����L�ȡGtrue�Bfalse
        print("�p��G" + (c < d));  // false
        print("�p��G" + (c > d));  // true
        print("�p��G" + (c <= d));  // false
        print("�p��G" + (c >= d));  // true
        print("�p��G" + (c != d));  // true
        print("�p��G" + (c == d));  // false
        #endregion

        #region �޿�B��l
        // �޿�B��l�A�w�塞�L�ȡG
        // �åB && : ��ӥ��L�Ȧ��@�� false ���G�N�O false
        print("true && true :" + (true && true));  // true
        print("true && false :" + (true && false));  // false
        print("false && true :" + (false && true));  // false
        print("false && false :" + (false && false));  // false

        // �Ϊ� ||�G��ӥ��L�Ȧ��@�� true ���G�N�O true
        print("true || true :" + (true || true));  // true
        print("true || false :" + (true || false));  // true
        print("false || true :" + (false || true));  // true
        print("false || false :" + (false || false));  // false

        // �C���d�� :
        // �ӧQ���� : �_�� >= 3 �� �åB ��q > 0 �~��L��
        print("�O�_�L���G" + (diamond >= 3 && hp > 0));  //false

        // �A�˹B��l !
        // �@�ΡG�N���L���ܬۤ�
        print("!true" + (!true));  //false
        print("!false" + (!false));  //true
        #endregion
    }
}


