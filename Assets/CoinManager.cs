using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int CoinCount;
    public TMP_Text CoinText;
    public GameObject Door1;
    public GameObject Door2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinText.text =  CoinCount.ToString();
        if(CoinCount == 15)
        {
            Destroy(Door1);
        }
        if (CoinCount == 55)
        {
            Destroy(Door2);
        }
    }
}
