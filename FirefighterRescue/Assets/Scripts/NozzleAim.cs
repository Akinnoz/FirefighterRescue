using UnityEngine;

public class NozzleAim : MonoBehaviour
{
    public float rotateSpeed = 80f;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
    }
}