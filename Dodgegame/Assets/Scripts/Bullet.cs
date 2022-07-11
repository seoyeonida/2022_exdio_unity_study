using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 8f;             // 총알 이동 속력
    private Rigidbody bulletRigidbody;        // 이동에 사용할 리지드바디 컴포넌트


    void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();

        // 리지드바디의 속도 = 앞쪽 방향 * 이동 속력
        bulletRigidbody.velocity = transform.forward * speed;

        // 3초 뒤에 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f);

    }

    // OnTrigger 계열 (Enter, Stay, Exit) - 둘 중 하나라도 트리거 콜라이더인 경우 실행됨
    // Enter : 콜라이더가 충돌을 했을 때
    // Stay : 콜라이더가 충돌을 하는 동안
    // Exit : 콜라이더가 충돌이 끝나는 순간 

    // OnCollision 계열 (Enter, Stay, Exit) - 둘 다 Collision 콜라이더인 경우에만 실행됨

    // 트리거 충돌 시 자동으로 실행되는 메서드
    // 메서드란 클래스 안에서 이용되는 함수
    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if (other.tag == "Player")
        {
            // 상대방 게임 오브젝트에서 PlayerController 컴포넌트를 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            // 상대방으로부터 PlayerController 컴포넌트를 가져오는데 성공했다면
            if (playerController != null) // null은 비어있다는 뜻을 나타내는 용어이다.
            {
                // 상대방 PlayerController 컴포넌트의 Die() 메서드 실행
                playerController.Die();
            }
        }
    }
}
