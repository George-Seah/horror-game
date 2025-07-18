using UnityEngine;

public class CreatureRotate : MonoBehaviour
{
    [SerializeField] Vector3 rotateVector = new Vector3(5f, 2.5f, 10f);
    [SerializeField] float rotationSpeed = 5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        rotateVector = rotateVector.normalized;
        transform.Rotate(rotateVector * rotationSpeed * Time.fixedDeltaTime);
    }
}
