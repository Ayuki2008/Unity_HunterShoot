using UnityEngine;

public class LearnMethod : MonoBehaviour
{

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

        print("�^�� 10 ��k���G�G" + ReturnTen());
        print("�ӫ~�`���G" + CalculatePrice());

        Shoot("���y");  //�S����ѼƷ|�H�w�]��
        Shoot("�q�y");  
        Shoot("�B�y", "������");  //�л\�Ѽ�
        Shoot("���y", "�զ⳷��");  //�����w���浲�G���~
        Shoot("���y", effect: "�զ⳷��"); //���y�A�������A���w �ѼƦW��:�զ⳷��

        //��Z������
        Attack(50);
        //���Z������
        Attack(20, "���y");
    }

    /*
     * ��k�y�k
     * �׹��� �Ǧ^���� ��k�ۭq�W�� (�Ѽ�1, �Ѽ�2, ...) { ��k���e }
     * �L�^�� void
     * ��k�W�� Unity �ߺD�j�g�}�Y
     */

    private void Test()
    {
        //��X(��X�T��);
        print("�w�w");
    }

    #region ��k�m��
    private void PrintColorText()
    {
        print("<color=yellow>root</color>");
        print("<color=#53D6F9>colon</color>");
    }

    /*
     * �Ǧ^��k
     * �����f�t return
     */
    private int ReturnTen()
    {
        //�Ǧ^ ��� (��������������P�^�������ۦP)
        return 10;
    }

    //�ө��t�ΡG99 ���A�p������ӫ~����
    public int countProduct = 10;
    public int countPrice = 99;

    private int CalculatePrice()
    {
        return countProduct * countPrice;
    }
    #endregion


    //�Ѽƻy�k�G�Ѽ����� �ѼƦW�� ���w �w�]��
    //���w�]�Ȫ��Ѽƥ�����b�̥k��
    private void Shoot(string type, string sound = "������", string effect = "����")
    {
        print("�o�g�G" + type);
        print("���ġG" + sound);
        print("�S�ġG" + effect);
    }

    /*
     * ��k���h�� overload
     * �w�q�G
     * 1. �ۦP�W�٪���k
     * 2. �����P�ƶq���ѼƩεۤ��P�������Ѽ�
     */
    private void TestMethod()
    {

    }

    private void TestMethod(int number)
    {

    }

    private void Attack(float atk)
    {
        print("��Z�������A�����O�G" + atk);
    }

    private void Attack(float atk, string ball)
    {
        print("��Z�������A�����O�G" + atk);
        print("�o�g����" + ball);
    }
}
