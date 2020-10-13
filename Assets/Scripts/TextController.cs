using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public static TextController instance;
    public Text blinkTextObj;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        blinkTextObj.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BlinkText(string text)
    {
        StartCoroutine(_BlinkText(text));
    }
    public IEnumerator _BlinkText(string text, float blinkSpeed = 1f, int maxBlinkCount = 3)
    {
        blinkTextObj.text = text;
        int blinkCount = 0;
        while (blinkCount < maxBlinkCount)
        {
            blinkTextObj.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            blinkTextObj.gameObject.SetActive(true);
            yield return new WaitForSeconds(blinkSpeed);
            blinkCount++;
        }
        blinkTextObj.gameObject.SetActive(false);

    }
}
