using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    [SerializeField] AudioSource bgm;
    [SerializeField] float fadeDuration;

    float fadingTime;
    bool isFading;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fadingTime = fadeDuration;
            isFading = true;
        }
        if (isFading)
        {
            fadingTime -= Time.deltaTime;
            bgm.volume = fadingTime / fadeDuration;

            if (fadingTime <= 0f)
            {
                SceneManager.LoadScene("SelectTest");
            }
        }
    }
}
