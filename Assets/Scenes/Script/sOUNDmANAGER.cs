using UnityEngine;

public class sOUNDmANAGER : MonoBehaviour
{
    private AudioSource source;
    public static sOUNDmANAGER instance { get; private set; }




    private void Awake()
    {


        instance = this;
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip _Sound)
    {
        source.PlayOneShot(_Sound);
    }




}
