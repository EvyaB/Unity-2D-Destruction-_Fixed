using UnityEngine;
using System.Collections;

// Copied from commit by 'carohauta' on the original version of Unity-2D-Destruction
public class DestroyObjectDelay : MonoBehaviour
{
    public float delay = 1;

    private bool fading = false;

    private void Start()
    {
        Invoke("DestroyObject", delay);
        Invoke("SetFadeTrue", delay - 1);
    }

    private void Update()
    {
        if (fading)
        {
            var material = GetComponent<Renderer>().material;
            var color = material.color;

            material.color = new Color(color.r, color.g, color.b, color.a - (delay / 5 * Time.deltaTime));
        }
    }

    private void SetFadeTrue()
    {
        fading = true;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}