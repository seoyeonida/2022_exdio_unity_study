using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // PlayerController��ũ��Ʈ���� ������ ������Ʈ�� ���� �������� ����
    private Rigidbody playerRigidbody;  // �̵��� ����� ������ٵ� ������Ʈ
    public float speed = 8f;       // �̵� �ӷ�


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        // ����� ���� �� �Է� ���� �����Ͽ� ����
        float xinput = Input.GetAxis("Horizontal");
        float zinput = Input.GetAxis("Vertical");

        // ���� �̵� �ӵ��� �Է� ���� �̵� �ӷ��� ���� ����
        float xSpeed = xinput * speed;
        float zSpeed = zinput * speed;

        // Vector3 �ӵ��� (xSpeed, 0, zSpeed)���� ����
        Vector3 newvelocity = new Vector3(xSpeed, 0, zSpeed);

        // ������ٵ��� �ӵ��� newVelocity�� �Ҵ�
        playerRigidbody.velocity = newvelocity;
    }

    public void Die()
    {
        // �ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);

    }
}
