using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnchantedOwlMovement : MonoBehaviour
{
    public float moveSpeed = 8f; // Karakterin hareket hızı

    public float minX = -15f; // Kamera sınırları
    public float maxX = 15f;
    public float minY = -5f;
    public float maxY = 5f;

    void Update()
    {
        // Klavye girişlerini al
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Hareket vektörünü oluştur
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f).normalized;

        // Karakteri hareket ettir
        transform.position += movement * moveSpeed * Time.deltaTime;



        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY),
            transform.position.z
        );



    }

}
