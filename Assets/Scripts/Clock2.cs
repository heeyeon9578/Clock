using System.Collections;
using UnityEngine;

public class Clock2: MonoBehaviour
{
    const float degreesPerHour = 30f;
    const float degreesPerMinute = 6f;
    [SerializeField] protected Transform hoursTransform, minuteTransform;
    [SerializeField] protected AudioSource audioSource; 
    protected float nowHour=12f; protected float nowMinute=0f;
    protected float alarmHour=13f; protected float alarmMinute=61f;
    protected float oneHour = 120f; protected float oneMinute = 2f;

    private void Start()
    {
        StartCoroutine(coMinute());
    }
    private void Update()
    {
        checkAlarm();
    }  
 
    public void setAlarm(float hour, float minute)
    {
        alarmHour = hour;
        alarmMinute = minute;
        Debug.Log("설정한 알람 시각은==="+alarmHour+":"+ alarmMinute);
        if (alarmHour >= 12)
        {
            alarmHour -= 12;
        }
        if (alarmMinute >= 60)
        {
            alarmMinute -= 60;
        }
    }
  
    public void checkAlarm()
    {
        if (nowHour >= alarmHour && nowMinute >= alarmMinute)
        {
            alarmHour = 13f;
            alarmMinute = 61f;
            Debug.Log("알람 잘 끝남++++++++++++++ " + nowHour + ":" + nowMinute);
            audioSource.Play();
            
        }
    }

    public IEnumerator coMinute()
    {
        if (nowMinute >= 60)
        {
            nowHour++;
            
            hoursTransform.localRotation = Quaternion.Euler(0f, 0f, -(nowHour) * degreesPerHour);
            nowMinute -= 60;
        }
        if (nowHour >= 12)
        {
            nowHour -= 12;
        }
        yield return new WaitForSecondsRealtime(oneMinute); //1분
        nowMinute++;
        minuteTransform.localRotation = Quaternion.Euler(0f, 0f, -(nowMinute) * degreesPerMinute);
        StartCoroutine(coMinute());

    }

    public void Print()
    {
        Debug.Log("==========================================");
        Debug.Log("현재 시간:      " + nowHour + " \n");
        Debug.Log("현재 분:      " + nowMinute + " \n");
        Debug.Log("알람 시간:     " + alarmHour + " \n");
        Debug.Log("알람 분:       " + alarmMinute + " \n");
        Debug.Log("시간 빠르기 정도:      " + oneHour + " \n");
        Debug.Log("분 빠르기 정도:       " + oneMinute + " \n");
        Debug.Log("==========================================");


    }
}
