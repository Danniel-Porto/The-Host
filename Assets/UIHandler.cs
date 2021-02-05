using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] Image blackScreen;
    [SerializeField] float fadeSpeed = 0.02f;

    public bool fade;
    bool isFaded;

    public float debugalpha;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1.0f);
        fade = true;
    }

    private void Update()
    {
        debugalpha = blackScreen.color.a;

        if (!isFaded & fade)
        {
            Fade();
        } else if (isFaded & fade)
        {
            FadeToBlack();
        }
    }

    void FadeToBlack()
    {
        if (blackScreen.color.a < 0.9f)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, blackScreen.color.a + fadeSpeed);
        }  else if (blackScreen.color.a >= 0.9f)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, 1f);
            isFaded = false;
            fade = false;
        }
    }

    void Fade()
    {
        if (blackScreen.color.a > 0.1f)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, blackScreen.color.a - fadeSpeed);
        }
        else if (blackScreen.color.a <= 0.1f)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, 0f);
            isFaded = true;
            fade = false;
            this.enabled = false;
        }
    }
}
