using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
    public InputField inputHour;
    public InputField inputMinute;
    public Clock2 clock2;
    public void settingAlarm()
    {
        float _alarmHour = float.Parse(inputHour.text);
        float _alarmMinute = float.Parse(inputMinute.text);
        clock2.setAlarm(_alarmHour, _alarmMinute);
        inputHour.text = "13";
        inputMinute.text = "61";
    }
}
