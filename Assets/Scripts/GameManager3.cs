using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager3 : MonoBehaviour
{
    [SerializeField] InputField inputHour;
    [SerializeField] InputField inputMinute;
    [SerializeField] Clock3 clock3;
    [SerializeField] Transform hoursTransform, minuteTransform;
    [SerializeField] AudioSource[] audioSource;
    private AudioSource tempAudio;
    private void Awake()
    {
        clock3.setTransform(hoursTransform, minuteTransform);
        tempAudio = audioSource[0];
        clock3.setAudio(tempAudio);
    }

    public void clickOK(int index) //�˶� ���� �� Ȯ�� ��ư Ŭ�� ��
    {
        StopAllCoroutines();
        if (index == 0) //������ �ð�
        {
            clock3.setSpeed(3600f, 60f);
        
        }
        else if(index == 1) //�ӵ�++
        {
            clock3.setSpeed(360f, 6f);
        }
        else if(index == 2)//�ӵ�--
        {
            clock3.setSpeed(60f, 1f);
        }
        else if(index == 3)// ���������
        {
            if (tempAudio == audioSource[0] )
            {
                tempAudio = audioSource[1]  ;
            }
            else
            {
                tempAudio = audioSource[0]  ;
            }
            clock3.setAudio(tempAudio);
        }

    }
    public void settingAlarm()
    {
        float _alarmHour = float.Parse(inputHour.text);
        float _alarmMinute = float.Parse(inputMinute.text);
        clock3.setAlarm(_alarmHour, _alarmMinute);
    }
    public void PrintClock()
    {
        clock3.Print();
    }
}
