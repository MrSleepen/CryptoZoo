using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingText : MonoBehaviour {

    private float speed;
    private Vector3 direction;
    private float fadeTime;

    private bool startMoving;

    public Text text;

	
	// Update is called once per frame
	void Update () {
        float translation = speed * Time.deltaTime;
        if(startMoving == true)
        {
            transform.Translate(direction * translation);
        }
    }

    public void Initilize(float speed, Vector3 direction, string text, float fadeTime)
    {
        //Using "this." to make script value equal ^ these 3 overloads
        this.speed = speed;
        this.direction = direction;
        this.fadeTime = fadeTime;
        this.text.text = text;

        StartCoroutine(FadeOut());
    }
    private IEnumerator FadeOut()
    {
        float startAlpha = GetComponent<Text>().color.a;
        float rate = 1.0f / fadeTime;
        float progress = 0.0f;

        yield return new WaitForSeconds(2);
        startMoving = true;
        while (progress < 1.0)
        {
            Color tmpColor = GetComponent<Text>().color;

            GetComponent<Text>().color = new Color(tmpColor.r, tmpColor.g, tmpColor.b, Mathf.Lerp(startAlpha, 0, progress));
            progress += rate * Time.deltaTime;
            yield return null;
        }
        if(progress >= 1.0)
        {
            Destroy(gameObject);
        }
        

    }
}
