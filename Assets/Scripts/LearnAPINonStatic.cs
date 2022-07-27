using UnityEngine;

/// <summary>
/// �ǲ� �D�R�A API
/// API ���W�S�� static
/// </summary>
public class LearnAPINonStatic : MonoBehaviour
{
    public Transform traA;
    public Light lightA;
    public Transform traB;
    private void Start()
    {
        /*
         * �D�R�A�ݩ� properties
         * 1. ���o get
         * ���� :
         * - �����O�������
         * - ���骫��
         * - ���s��ӹ��骫��
         * ���W��.�D�R�A�ݩʦW��
         */
        print("A ���󪺮y�СG" + traA.position);
        print("�O���C��G" + lightA.color);

        // 2. �]�w set
        // ���W��.�D�R�A�ݩʦW�� ���w ��;
        traA.position = new Vector3(1.57f, 0.5f, -15);
        lightA.color = new Color(0, 1, 1);
    }

    private void Update()
    {
        // �D�R�A��k methods
        // 3. �ϥ�
        // ���W��.�D�R�A��k�W��(�����޼�)
        traB.Rotate(0, 10, 0);
    }
}