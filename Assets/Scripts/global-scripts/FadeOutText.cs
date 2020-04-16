using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutText : MonoBehaviour
{
    public void FadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(FadeOutRoutine());
    }
    private IEnumerator FadeOutRoutine()
    {
        Text text = gameObject.GetComponent<Text>();
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        yield return new WaitForSeconds(2);

        float t = 0f;


        // Debug.Log(text);
        while (t < 2)
        {
            t += Time.deltaTime;
            // Debug.Log(t);
            float alpha = Mathf.Lerp(1f, 0f, t);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);

            yield return null;
        }
        yield return null;
    }
}
