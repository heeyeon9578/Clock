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
        Debug.Log("������ �˶� �ð���==="+alarmHour+":"+ alarmMinute);
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
            Debug.Log("�˶� �� ����++++++++++++++ " + nowHour + ":" + nowMinute);
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
        yield return new WaitForSecondsRealtime(oneMinute); //1��
        nowMinute++;
        minuteTransform.localRotation = Quaternion.Euler(0f, 0f, -(nowMinute) * degreesPerMinute);
        StartCoroutine(coMinute());

    }

    public void Print()
    {
        Debug.Log("==========================================");
        Debug.Log("���� �ð�:      " + nowHour + " \n");
        Debug.Log("���� ��:      " + nowMinute + " \n");
        Debug.Log("�˶� �ð�:     " + alarmHour + " \n");
        Debug.Log("�˶� ��:       " + alarmMinute + " \n");
        Debug.Log("�ð� ������ ����:      " + oneHour + " \n");
        Debug.Log("�� ������ ����:       " + oneMinute + " \n");
        Debug.Log("==========================================");


    }
}
