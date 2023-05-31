using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    public Image fadeImage;
    public Image img;
    public AnimationCurve curve;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo (string scene)
    {
        StartCoroutine(FadeOut(scene));
    }
    IEnumerator FadeIn()
    {
        float t = 1f;
        while (t > 0f)
        {
            t -= Time.deltaTime;
            //fadeImage.color = new Color (0f, 0f, 0f, t);
            float a = curve.Evaluate(t);
            fadeImage.color = new Color(0f, 0f, 0f, a);
            yield return 0; //Wait for the next frame then continue

        }
    }


    IEnumerator FadeOut(string scene)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            //fadeImage.color = new Color (0f, 0f, 0f, t);
            float a = curve.Evaluate(t);
            fadeImage.color = new Color(0f, 0f, 0f, a);
            yield return 0; //Wait for the next frame then continue
        }

        SceneManager.LoadScene(scene);
    }

}
