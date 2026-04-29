using UnityEngine;

public class NozzleAim : MonoBehaviour
{
    public Transform firePoint;
    public float minAngle = 10f;
    public float maxAngle = 80f;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector2 dir = mousePos - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        angle = Mathf.Clamp(angle, minAngle, maxAngle);

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}