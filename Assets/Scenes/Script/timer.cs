using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{

    public TextMeshProUGUI Text;
    public float timeRemaining = 120f;
    void Start()
    {

    }

    void Update()
    {


        timeRemaining -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);


        Text.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
