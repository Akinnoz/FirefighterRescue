using UnityEngine;

public class FireHoseProjectile : MonoBehaviour
{
    public LineRenderer line;
    public Transform firePoint;
    public float speed = 16f;
    public float gravity = 0.05f;
    public int resolution = 30;
    public float timeStep = 0.1f;
    public LayerMask fireLayer;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            line.enabled = true;
            DrawWater();
        }
        else
        {
            line.enabled = false;
        }
    }

    void DrawWater()
    {
        line.positionCount = resolution;

        Vector2 start = firePoint.position;

        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dir = (mouse - start).normalized;

        Vector2 velocity = new Vector2(dir.x * speed, dir.y * speed + 30f);

        Vector2 prev = start;

        for (int i = 0; i < resolution; i++)
        {
            float t = i * timeStep;

            Vector2 pos = start +
                          velocity * t +
                          0.5f * new Vector2(0, -9.8f * gravity) * t * t;

            line.SetPosition(i, pos);

            RaycastHit2D hit = Physics2D.Raycast(
                prev,
                pos - prev,
                Vector2.Distance(prev, pos),
                fireLayer
            );

            if (hit.collider != null)
            {
                Destroy(hit.collider.gameObject);
            }

            prev = pos;
        }
    }
}
