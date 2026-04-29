using UnityEngine;

public class FireHose : MonoBehaviour
{
    public ParticleSystem waterEffect;
    public Transform firePoint;
    public float range = 10f;
    public LayerMask fireLayer;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!waterEffect.isPlaying)
                waterEffect.Play();

            ShootWater();
        }
        else
        {
            if (waterEffect.isPlaying)
                waterEffect.Stop();
        }
    }

    void ShootWater()
    {
        Vector2 dir = firePoint.up;

        RaycastHit2D hit = Physics2D.Raycast(
            firePoint.position,
            dir,
            range,
            fireLayer
        );

        Debug.DrawRay(firePoint.position, dir * range, Color.blue);

        if (hit.collider != null)
        {
            Destroy(hit.collider.gameObject);
        }
    }
}