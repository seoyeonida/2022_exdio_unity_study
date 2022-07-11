using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 8f;             // �Ѿ� �̵� �ӷ�
    private Rigidbody bulletRigidbody;        // �̵��� ����� ������ٵ� ������Ʈ


    void Start()
    {
        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();

        // ������ٵ��� �ӵ� = ���� ���� * �̵� �ӷ�
        bulletRigidbody.velocity = transform.forward * speed;

        // 3�� �ڿ� �ڽ��� ���� ������Ʈ �ı�
        Destroy(gameObject, 3f);

    }

    // OnTrigger �迭 (Enter, Stay, Exit) - �� �� �ϳ��� Ʈ���� �ݶ��̴��� ��� �����
    // Enter : �ݶ��̴��� �浹�� ���� ��
    // Stay : �ݶ��̴��� �浹�� �ϴ� ����
    // Exit : �ݶ��̴��� �浹�� ������ ���� 

    // OnCollision �迭 (Enter, Stay, Exit) - �� �� Collision �ݶ��̴��� ��쿡�� �����

    // Ʈ���� �浹 �� �ڵ����� ����Ǵ� �޼���
    // �޼���� Ŭ���� �ȿ��� �̿�Ǵ� �Լ�
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
        if (other.tag == "Player")
        {
            // ���� ���� ������Ʈ���� PlayerController ������Ʈ�� ��������
            PlayerController playerController = other.GetComponent<PlayerController>();

            // �������κ��� PlayerController ������Ʈ�� �������µ� �����ߴٸ�
            if (playerController != null) // null�� ����ִٴ� ���� ��Ÿ���� ����̴�.
            {
                // ���� PlayerController ������Ʈ�� Die() �޼��� ����
                playerController.Die();
            }
        }
    }
}
