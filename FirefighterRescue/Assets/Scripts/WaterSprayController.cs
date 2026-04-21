using UnityEngine;

public class WaterSprayController : MonoBehaviour
{
    public ParticleSystem water;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!water.isPlaying)
                water.Play();
        }
        else
        {
            if (water.isPlaying)
                water.Stop();
        }
    }
}