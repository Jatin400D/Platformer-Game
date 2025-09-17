using UnityEngine;

public class FireballHolder : MonoBehaviour
{
   [SerializeField] private Transform Boss;



    private void Update()
    {
        transform.localScale = Boss.localScale;
    }
}
