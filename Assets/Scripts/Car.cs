using UnityEngine;

/*
 * �Ź� -> ����
 * 1. �����W���C������
 * 2. �K�[���� Add Component
 * 3. ��������O
 */

public class Car : MonoBehaviour
{
    /*
     * < ��� field �y�k > (�ܼ� variable) 
     * �׹��� ������� ���ۭq�W�� ���w �� �����Ÿ�
     * �׹�����ƪ��s���v��
     * 
     * ��j�򥻭׹���
     * public  ���} : ���\�~���s���A��ܦb�ݩʭ��O
     * private �p�H : �����\�~���s���A����ܦb�ݩʭ��O(�w�]�ȡA�i�ٲ�)
     */

    /*
     * ����ݩʻy�k
     * [�ݩʦW��(��)]
     * 
     * 1. ���� Tooltip
     * 2. ���D Header
     * 3. �d�� Range #�ȭ���ƻP�B�I��
     */

    [Range(1, 50)]
    [Tooltip("�T�������q�A���O���C")]
    public int weight = 3; // ���q

    [Header("�T��������"), Range(1, 10)] // ����ݩʤ@�_�g
    public float height = 3.5f; // ����

    [Header("�T�����~�P�W��")]
    public string brand = "���h"; // �~�P

    [Header("�O�_���ѵ�")]
    [Tooltip("�]�w�T���O�_���ѵ�")]
    public bool hasSkyWindow = true; // �O�_���ѵ�
}
