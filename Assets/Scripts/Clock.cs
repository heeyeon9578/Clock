using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] bool way;
    [SerializeField] Animator hourAnim;
    [SerializeField] Animator minuteAnim;
    
    private void Awake()
    {
        way=false;
    }
    private void Update()
    {
        if(way==true)
        {
            hourAnim.SetBool("way", true);
            minuteAnim.SetBool("way", true);

        }
        else
        {

            hourAnim.SetBool("way", false);
            minuteAnim.SetBool("way", false);
        }

    }
}