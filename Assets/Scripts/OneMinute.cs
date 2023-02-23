using System.Collections;
using UnityEngine;

public class OneMinute : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField]  Transform hoursTransform, minuteTransform;
    const float degreesPerHour = 30f;
    const float degreesPerMinute = 6f;
    const float oneHour = 60f;
    float nowHour = 0f;
    float nowMinute = 0f;
    private void Start()
    {
        StartCoroutine(checkOneMinute());
    }
    IEnumerator checkOneMinute()
    {
        yield return new WaitForSecondsRealtime(60f);
        minuteTransform.localRotation = Quaternion.Euler(0f, 0f, -(nowMinute++) * degreesPerMinute);
        animator.Play("OneMinute");
        if (nowMinute % oneHour==0)
        {
            hoursTransform.localRotation = Quaternion.Euler(0f, 0f, -(++nowHour) * degreesPerHour);
        }
        Debug.Log("------------" + nowHour +":"+ nowMinute + "------------");

        StartCoroutine(checkOneMinute());
    }
}
