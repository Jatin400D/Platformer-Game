using System;
using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Loading2 : MonoBehaviour
{
    public Slider Loadingbar;
    public TextMeshProUGUI Text;
   
    void Start()
    {
        Loadingbar.value = 0;
        Text.text = "Loading... %";

        StartCoroutine(LoadScene());

    }

  
    IEnumerator LoadScene()
    {
        float Loadingtime = 5f;
        float elapsedtime = 0f;

        while (elapsedtime < Loadingtime)
        {
            elapsedtime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedtime / Loadingtime);


            Loadingbar.value = progress;
            Text.text = "loading..." + Mathf.FloorToInt(progress * 100)+"%";



            yield return null;

        }

        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");

    }
    



      





   
}
