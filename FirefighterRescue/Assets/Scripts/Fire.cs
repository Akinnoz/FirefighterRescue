using UnityEngine;

public class Fire : MonoBehaviour
{
    private void OnDestroy()
    {
        if (GameManager.instance != null)
            GameManager.instance.FireExtinguished();
    }
}