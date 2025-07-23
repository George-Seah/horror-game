using UnityEngine;

public class AutoSpin : MonoBehaviour
{
    [SerializeField] float spinSpeed;
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * spinSpeed * Time.fixedDeltaTime);
    }
}
