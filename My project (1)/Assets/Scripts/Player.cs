using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��������

public class Player : MonoBehaviour
{

    //���� ����


    [SerializeField]
    private int m_hp;
    private string m_name;    //�÷��̾��� �̸�


    // Start is called before the first frame update
    void Start()
    {

        m_hp = 10;
        m_name = "������";

        Debug.Log("�÷��̾��� ü���� " + m_hp + "�� �ʱ�ȭ �Ǿ����ϴ�.");    //����׷α׷� �� �ǰ��ִ��� Ȯ��?
        Debug.Log("�÷��̾��� �̸��� " + m_name + "�� �ʱ�ȭ �Ǿ����ϴ�.");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) //GetKeyDown = Ű ������ ��
        {
            IncreaseHP();
            Debug.Log("�÷��̾��� ü���� " + m_hp + "�� �Ǿ����ϴ�.");
        }
        if (Input.GetKey(KeyCode.B)) //GeyKey = ������ ���� 
        {
            MovePlayer();
            Debug.Log("�÷��̾��� ��ġ�� �̵� �Ǿ����ϴ�.");
        }


    }
    //  �Լ� ����
    private void IncreaseHP()
    {
        m_hp += 1;    // ���� hp���� 1��ŭ �����Ѵ�. -> ü���� �����Ѵ�.
    }
    private void MovePlayer()
    {
        transform.position += new Vector3(1, 1, 1);
    }
}
