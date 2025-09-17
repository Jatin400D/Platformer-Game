using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class LoadingSCreen : MonoBehaviour
{
    public Slider loadingBar; 
    public TextMeshProUGUI loadingText;  
    public string sceneToLoad;
    
    void Start()
    {
        
        loadingBar.value = 0;
        loadingText.text = "Loading... 0%";

      
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        float LoadingTime = 5f;
        float elapsedTime = 0f;

        if (elapsedTime < LoadingTime)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / LoadingTime);

            loadingBar.value = progress;
            loadingText.text = "Loading... " + Mathf.FloorToInt(progress * 100) + "%";

            yield return null; 
        }

       
       
    }
}
