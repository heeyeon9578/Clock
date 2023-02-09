using UnityEngine;
/// <summary>
/// Clock2 상속 받은 자식 클래스
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
    /*
        public Clock3(Transform hoursTransform, Transform minuteTransform, AudioSource audioSource) : base()
        {
            this.hoursTransform = hoursTransform;
            this.minuteTransform = minuteTransform;
            this.audioSource = audioSource;
        }
        //속도 및 오디오
        public Clock3(Transform hoursTransform, Transform minuteTransform, AudioSource audioSource, float hour, float minute) : base()
        {
            this.hoursTransform = hoursTransform;
            this.minuteTransform = minuteTransform;
            this.audioSource = audioSource;
            oneHour = hour;
            oneMinute = minute;
        }
    */
}
