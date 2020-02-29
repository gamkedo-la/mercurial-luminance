using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public FadingText[] FaingTextArray;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("PlayTextSequence");
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
        foreach (var fadingText in FaingTextArray)
        {
            GameObject.FindGameObjectWithTag("FadingText").GetComponent<TextMeshProUGUI>().text = fadingText.Text;

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
    [Serializable]
    public class FadingText
    {
        public string Text;
        public float timeInSeconds;
    }
}
