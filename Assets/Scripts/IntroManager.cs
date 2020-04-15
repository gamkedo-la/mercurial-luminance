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

    private TextMeshProUGUI fadingText;
    private GameObject transitionEffectImage;
    private GameObject introImage;

    // Start is called before the first frame update
    void Start()
    {
        fadingText = GameObject.FindGameObjectWithTag("FadingText").GetComponent<TextMeshProUGUI>();
        transitionEffectImage = GameObject.FindGameObjectWithTag("TransitionEffectImage");
        introImage = GameObject.FindGameObjectWithTag("IntroImage");
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
        var originalColor = fadingText.color;
        foreach (var eachFadingText in FaidngTextArray)
        {
            fadingText.text = eachFadingText.text;

            // Fade in:
            while (originalColor.a<1)
            {
                yield return new WaitForSeconds(0.01f);
                originalColor.a += 0.01f;
                fadingText.color = originalColor;
            }

            // Delay:
            yield return new WaitForSeconds(eachFadingText.timeInSeconds);

            // Fade out:
            while (originalColor.a > 0)
            {
                yield return new WaitForSeconds(0.01f);
                originalColor.a -= 0.01f;
                fadingText.color = originalColor;
            }

            yield return new WaitForSeconds(2);
        }
    }

    IEnumerator PlayImageSequence()
    {
        var transitionEffectColor = transitionEffectImage.GetComponent<Image>().color;

        foreach (var currentImage in ImageArray)
        {
            introImage.GetComponent<Image>().sprite = currentImage.image;
            introImage.GetComponent<RectTransform>().localScale = new Vector3(currentImage.zoomFactor, currentImage.zoomFactor,1);

            switch (currentImage.ImageType)
            {
                case ImageType.still:
                    introImage.GetComponent<RectTransform>().position = Vector3.zero;
                    break;
                case ImageType.scrollingLeftToRight:
                    introImage.GetComponent<Animator>().SetTrigger("LeftToRight");
                    break;
                case ImageType.scrollingRightToLeft:
                    introImage.GetComponent<Animator>().SetTrigger("RightToLeft");
                    break;
                case ImageType.ZoomIn:
                    introImage.GetComponent<Animator>().SetTrigger("ZoomIn");
                    break;
                case ImageType.ZoomOut:
                    introImage.GetComponent<Animator>().SetTrigger("ZoomOut");
                    break;
            }

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
        public float zoomFactor = 1f;
        public ImageType ImageType;
    }

    public enum ImageType
    {
        still,
        scrollingLeftToRight,
        scrollingRightToLeft,
        ZoomIn,
        ZoomOut
    }
}
