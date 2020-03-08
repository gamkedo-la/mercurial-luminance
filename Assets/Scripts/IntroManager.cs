using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    public FadingText[] FaidngTextArray;
    public IntroImage[] ImageArray;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("PlayTextSequence");
        StartCoroutine("PlayImageSequence");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    IEnumerator PlayTextSequence()
    {
        var originalColor = GameObject.FindGameObjectWithTag("FadingText").GetComponent<TextMeshProUGUI>().color;
        foreach (var fadingText in FaidngTextArray)
        {
            GameObject.FindGameObjectWithTag("FadingText").GetComponent<TextMeshProUGUI>().text = fadingText.text;

            // Fade in:
            while (originalColor.a<1)
            {
                yield return new WaitForSeconds(0.01f);
                originalColor.a += 0.01f;
                GameObject.FindGameObjectWithTag("FadingText").GetComponent<TextMeshProUGUI>().color = originalColor;
            }

            // Delay:
            yield return new WaitForSeconds(fadingText.timeInSeconds);

            // Fade out:
            while (originalColor.a > 0)
            {
                yield return new WaitForSeconds(0.01f);
                originalColor.a -= 0.01f;
                GameObject.FindGameObjectWithTag("FadingText").GetComponent<TextMeshProUGUI>().color = originalColor;
            }

            yield return new WaitForSeconds(2);
        }
    }

    IEnumerator PlayImageSequence()
    {
        var transitionEffectImage = GameObject.FindGameObjectWithTag("TransitionEffectImage");
        var transitionEffectColor = transitionEffectImage.GetComponent<Image>().color;
        var introImage = GameObject.FindGameObjectWithTag("IntroImage");

        foreach (var currentImage in ImageArray)
        {
            introImage.GetComponent<Image>().sprite = currentImage.image;

            // play effect
            while (transitionEffectColor.a > 0)
            {
                yield return new WaitForSeconds(0.01f);
                transitionEffectColor.a -= 0.01f;
                transitionEffectImage.GetComponent<Image>().color = transitionEffectColor;
            }

            // Delay:
            yield return new WaitForSeconds(currentImage.timeInSeconds);

            // play effect
            while (transitionEffectColor.a < 1)
            {
                yield return new WaitForSeconds(0.01f);
                transitionEffectColor.a += 0.01f;
                transitionEffectImage.GetComponent<Image>().color = transitionEffectColor;
            }


            yield return new WaitForSeconds(2);
        }
    }
    [Serializable]
    public class FadingText
    {
        public string text;
        public float timeInSeconds;
    }

    [Serializable]
    public class IntroImage
    {
        public Sprite image;
        public float timeInSeconds;
        public float zoomFactor = 1;
        public ImageType ImageType;
    }

    public enum ImageType
    {
        still,
        scrollingLeftToRigh,
        scrollingRightToLeft
    }
}
