using System.Collections;
using UnityEngine;

public class Clock2: MonoBehaviour
{
    #region protecteds Properties
    protected float degreesPerHour = 30f;
    protected float degreesPerMinute = 6f;
    protected float initalarmHour = 13f; 
    protected float initalarmMinute = 61f;
    protected float initnowHour = 12f;
    protected float initnowMinute = 60f;
    protected float nowHour=12f; 
    protected float nowMinute=0f;
    protected float alarmHour=13f; 
    protected float alarmMinute=61f;
    protected float oneHour = 120f; 
    protected float oneMinute = 2f;
    protected float xTransform = 0; 
    protected float yTransform = 0;
    
    [SerializeField] protected Transform hoursTransform;
    [SerializeField] protected Transform minuteTransform;
    [SerializeField] protected AudioSource audioSource;
    #endregion

    private void Awake()
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
        if (alarmHour >= initnowHour)
        {
            alarmHour -= initnowHour;
        }
        if (alarmMinute >= initnowMinute)
        {
            alarmMinute -= initnowMinute;
        }
    }
  
    public void checkAlarm()
    {
        if (nowHour >= alarmHour && nowMinute >= alarmMinute)
        {
            alarmHour = initalarmHour;
            alarmMinute = initalarmMinute;
            Debug.Log("�˶� �� ����++++++++++++++ " + nowHour + ":" + nowMinute);
            audioSource.Play();
            
        }
    }

    public IEnumerator coMinute()
    {
        if (nowMinute >= initnowMinute)
        {
            nowHour++;
            
            hoursTransform.localRotation = Quaternion.Euler(xTransform, yTransform, -(nowHour) * degreesPerHour);
            nowMinute -= initnowMinute;
        }
        if (nowHour >= initnowHour)
        {
            nowHour -= initnowHour;
        }
        yield return new WaitForSecondsRealtime(oneMinute); //1��
        nowMinute++;
        minuteTransform.localRotation = Quaternion.Euler(xTransform, yTransform, -(nowMinute) * degreesPerMinute);
        Debug.Log(nowHour+ ":" + nowMinute);    
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
