using UnityEngine;

public class LearnMethod : MonoBehaviour
{
    /*
     * ��k�y�k
     * �^������ ��k�ۭq�W�� () { ��k�W�� }
     * �L�^�� void
     * ��k�W�� Unity �ߺD�j�g�}�Y
     */

    private void Test()
    {
        //��X(��X�T��);
        print("�w�w");
    }

    private void PrintColorText()
    {
        print("<color=yellow>root</color>");
        print("<color=#53D6F9>colon</color>");
    }

    //�ۭq��k�ݭn�I�s�~�|����

    /*
     * Unity ���J�f
     * �}�l�ƥ� : ����C����|����@��
     * ��l�Ƴ]�w : ��l���B�B��l�X���R
     */

    private void Start()
    {
        //�I�s��k : ��k�W��();
        Test();
        PrintColorText();
    }

     

}
