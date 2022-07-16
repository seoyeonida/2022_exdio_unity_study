using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 변수 생성
    public GameObject gameoverText; //게임오버 시 활성화할 텍스트 게임 오브젝트
    public Text timeText;
    public Text recordText;

    private float surviveTime;  // 생존한 시간
    private bool isGameover;    // 게임오버 상태인지 확인하는 변수

    void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover) // 느낌표 = ~가 아닌 경우
        {
            //생존 시간 갱신
            surviveTime += Time.deltaTime;
            //갱신한 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시
            timeText.text = "♥ 점수 : " + (int)surviveTime + " ♥";
        }
        else // 그 외(게임오버 상태인 경우)
        {
            //게임오버인 상태에서 R키를 누른 경우
            if (Input.GetKeyDown(KeyCode.R))
            {
                //씬 매니저를 통해 MainScene 씬을 로드
                SceneManager.LoadScene("SampleScene"); //내가 만들어놓은 씬의 이름을 불러오기.
            }
        }
    }
    //현재 게임을 게임오버 상태로 변경하는 메서드
    public void EndGame()
    {
        //현재 상태를 게임오버 상태로 전환
        isGameover = true;
        //게임오버 텍스트 게임 오브젝트를 활성화
        gameoverText.SetActive(true);

        //BestTime 키로 저장된 이전까지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //이전까지의 최고기록보다 현재 생존 시간이 더 크다면
        if (surviveTime > bestTime)
        {
            //최고 기록 값을 현재 생존 시간 값으로 변경
            bestTime = surviveTime;
            //변경된 최고 기록을 BestTime 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime); // 플레이어 프리퍼런스 = 본인 컴퓨터에 저장이 된다.
        }

        //최고 기록을 recordText 텍스트 컴포넌트를 이용해 표시
        recordText.text = "♥ 최고 점수 : " + (int)bestTime + " ♥";
    }
}