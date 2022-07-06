using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 응애응애

public class Player : MonoBehaviour
{

    //변수 생성


    [SerializeField]
    private int m_hp;
    private string m_name;    //플레이어의 이름


    // Start is called before the first frame update
    void Start()
    {

        m_hp = 10;
        m_name = "서여닝";

        Debug.Log("플레이어의 체력이 " + m_hp + "로 초기화 되었습니다.");    //디버그로그로 잘 되고있는지 확인?
        Debug.Log("플레이어의 이름이 " + m_name + "로 초기화 되었습니다.");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) //GetKeyDown = 키 눌렀을 때
        {
            IncreaseHP();
            Debug.Log("플레이어의 체력이 " + m_hp + "가 되었습니다.");
        }
        if (Input.GetKey(KeyCode.B)) //GeyKey = 누르는 동안 
        {
            MovePlayer();
            Debug.Log("플레이어의 위치가 이동 되었습니다.");
        }


    }
    //  함수 생성
    private void IncreaseHP()
    {
        m_hp += 1;    // 기존 hp보다 1만큼 증가한다. -> 체력이 증가한다.
    }
    private void MovePlayer()
    {
        transform.position += new Vector3(1, 1, 1);
    }
}
