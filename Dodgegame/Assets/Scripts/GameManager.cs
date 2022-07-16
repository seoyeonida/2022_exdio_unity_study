using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ���� ����
    public GameObject gameoverText; //���ӿ��� �� Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ
    public Text timeText;
    public Text recordText;

    private float surviveTime;  // ������ �ð�
    private bool isGameover;    // ���ӿ��� �������� Ȯ���ϴ� ����

    void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover) // ����ǥ = ~�� �ƴ� ���
        {
            //���� �ð� ����
            surviveTime += Time.deltaTime;
            //������ ���� �ð��� timeText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
            timeText.text = "�� ���� : " + (int)surviveTime + " ��";
        }
        else // �� ��(���ӿ��� ������ ���)
        {
            //���ӿ����� ���¿��� RŰ�� ���� ���
            if (Input.GetKeyDown(KeyCode.R))
            {
                //�� �Ŵ����� ���� MainScene ���� �ε�
                SceneManager.LoadScene("SampleScene"); //���� �������� ���� �̸��� �ҷ�����.
            }
        }
    }
    //���� ������ ���ӿ��� ���·� �����ϴ� �޼���
    public void EndGame()
    {
        //���� ���¸� ���ӿ��� ���·� ��ȯ
        isGameover = true;
        //���ӿ��� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);

        //BestTime Ű�� ����� ���������� �ְ� ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //���������� �ְ���Ϻ��� ���� ���� �ð��� �� ũ�ٸ�
        if (surviveTime > bestTime)
        {
            //�ְ� ��� ���� ���� ���� �ð� ������ ����
            bestTime = surviveTime;
            //����� �ְ� ����� BestTime Ű�� ����
            PlayerPrefs.SetFloat("BestTime", bestTime); // �÷��̾� �����۷��� = ���� ��ǻ�Ϳ� ������ �ȴ�.
        }

        //�ְ� ����� recordText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
        recordText.text = "�� �ְ� ���� : " + (int)bestTime + " ��";
    }
}