using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{

    public IEnumerator Shaker(float duration, float str)
    {
        Vector3 mainpos = transform.localPosition;

        float elapsed = 0.0f;
        
        while (elapsed < duration)
        {
            float x = Random.Range(-.5f, .5f) * str;
            float y = Random.Range(-.5f, .5f) * str;

            transform.localPosition = new Vector3(x, y, mainpos.z);

            elapsed += Time.deltaTime;

            yield return null;

        }

        transform.localPosition = mainpos;
    }
}
