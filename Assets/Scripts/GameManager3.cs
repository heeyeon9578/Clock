using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager3 : MonoBehaviour
{
    public InputField inputHour;
    public InputField inputMinute;
    public Clock3 clock3;
    public Transform hoursTransform, minuteTransform;
    public AudioSource audioSource;
    public AudioSource audioSource2;
    AudioSource tempAudio;
    private void Awake()
    {
        clock3.setTransform(hoursTransform, minuteTransform);
        clock3.setAudio(audioSource);
        tempAudio = audioSource;
        StartClock();
    }
    private void Update()
    {
        clock3.checkAlarm();
    }
    public void clickOK(int index) //알람 설정 후 확인 버튼 클릭 시
    {
        StopAllCoroutines();
        if (index == 0) //보통의 시계
        {
            clock3.setSpeed(3600f, 60f);
        
        }
        else if(index == 1) //속도++
        {
            clock3.setSpeed(360f, 6f);
        }
        else if(index == 2)//속도--
        {
            clock3.setSpeed(60f, 1f);
        }
        else if(index == 3)// 오디오변경
        {
            if (tempAudio == audioSource)
            {
                tempAudio = audioSource2;
            }
            else
            {
                tempAudio = audioSource;
            }
            clock3.setAudio(tempAudio);
           
        }
        
     

    }
    void StartClock()
    {
        StartCoroutine(clock3.coMinute());
    }
    public void settingAlarm()
    {
        float _alarmHour = float.Parse(inputHour.text);
        float _alarmMinute = float.Parse(inputMinute.text);
        clock3.setAlarm(_alarmHour, _alarmMinute);
        inputHour.text = "13";
        inputMinute.text = "61";
    }
    public void PrintClock()
    {
        clock3.Print();
    }
}
