using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public Transform target; // Takip edilecek karakterin transformu
    public float smoothSpeed = 0.125f; // Kamera hareketinin yumuşaklığı
    public Vector3 offset; // Karakter ile kamera arasındaki uzaklık
    public Transform newTarget;

    public float minX = -5f; // Kamera sınırları
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    bool transed;
    void LateUpdate()
    {
        if (target == null)
            return;

        if (!target.gameObject.activeSelf)
        {
                target = newTarget;      
            
        }
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(
            Mathf.Clamp(smoothedPosition.x, minX, maxX),
            Mathf.Clamp(smoothedPosition.y, minY, maxY),
            transform.position.z
        );
    }
}







