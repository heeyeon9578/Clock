using UnityEngine;
/// <summary>
/// Clock2 ��� ���� �ڽ� Ŭ����
/// </summary>
public class Clock3 : Clock2
{

    public void setAudio(AudioSource a_so)
    {
        audioSource = a_so;
    }
    public void setTransform(Transform _hoursTransform, Transform _minuteTransform)
    {
        hoursTransform = _hoursTransform;
        minuteTransform = _minuteTransform;
    }
    public void setSpeed(float hour, float minute)
    {
        
        oneHour = hour;
        oneMinute= minute;  
    }
}
