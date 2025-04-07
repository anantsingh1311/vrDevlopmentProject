using System;
using UnityEngine;

public class CameraController : MonoBehaviour, IDestroyable
{
    [SerializeField] Transform rotateAnchor;
    [SerializeField] float rotateSpeed = 2;
    [SerializeField] float angle1;
    [SerializeField] float angle2;

    bool isDestroyed;
    float currentAngle;
    float targetAngle;

    public event Action Destroyed;

    private void Start()
    {
        currentAngle = angle1;
        targetAngle = angle2;
    }

    public void DestroyObject()
    {
        if (isDestroyed)
            return;

        rotateAnchor.localEulerAngles += new Vector3(60, 0, 0);
        enabled = false;
        isDestroyed = true;
        Destroyed?.Invoke();
    }

    private void Update()
    {
        currentAngle += rotateSpeed * Time.deltaTime;

        if(Mathf.Abs(currentAngle - targetAngle) < 1)
        {
            currentAngle = targetAngle;
            targetAngle = rotateSpeed > 0 ? angle1 : angle2;
            rotateSpeed = -rotateSpeed;
        }

        rotateAnchor.localEulerAngles = new Vector3(0, 0, currentAngle);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("stone"))
            DestroyObject();
    }
}
