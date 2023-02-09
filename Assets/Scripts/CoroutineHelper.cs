using UnityEngine;
using System.Collections;



public class CoroutineHelper : MonoBehaviour

{

    IEnumerator enumerator = null;

    private void Coroutine(IEnumerator coro)
    {
        enumerator = coro;
        StartCoroutine(coro);
    }



    void Update()
    {
        if (enumerator != null)
        {
            if (enumerator.Current == null)
            {
                Destroy(gameObject);
            }
        }
    }



    public void Stop()
    {
        StopCoroutine(enumerator.ToString());
        Destroy(gameObject);
    }



    public static CoroutineHelper Start_Coroutine(IEnumerator coro)
    {
        GameObject obj = new GameObject("CoroutineHandler");
        CoroutineHelper handler = obj.AddComponent<CoroutineHelper>();
        if (handler)
        {
            handler.Coroutine(coro);
        }
        return handler;
    }
}