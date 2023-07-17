using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rat2 : MonoBehaviour
{
    public float wanderSpeed = 5f; // Objenin dolaşma hızı
    public Vector2 wanderAreaCenter; // Dolaşma alanının merkez noktası
    public Vector2 wanderAreaSize; // Dolaşma alanının boyutları
    private float rotateChange = 2f;
    private Vector2 wanderDirection;
    private Vector2 targetPosition;

    public float minX = -5f; // Kamera sınırları
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;


   
    public Quaternion bul;
    float timer = 0f;
    GameObject owl;
    void Start()
    {
        GetNewWanderDirection();
        owl = GameObject.Find("owl");
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (rotateChange <= timer)
        {
            GetNewWanderDirection();
            timer = 0;
        }
        Move();

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY),
            transform.position.z
        );

        if (owl.activeSelf)
        {
            if (Vector2.Distance(transform.position, owl.transform.position) < 1f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, GameObject.Find("owl2").transform.position) < 1f)
            {
                Destroy(gameObject);
            }
        }
    }

    // Objeyi dolaştır
    void Move()
    {
        transform.Translate(wanderDirection * wanderSpeed * Time.deltaTime);

        // Eğer hedef pozisyona yakınsa yeni bir hedef pozisyon al
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            GetNewWanderDirection();
        }
    }

    // Yeni bir dolaşma yönü al
    void GetNewWanderDirection()
    {
        // Rastgele bir yön seç
        wanderDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        // Rastgele bir hedef pozisyon seç
        float randomX = Random.Range(wanderAreaCenter.x - wanderAreaSize.x / 2f, wanderAreaCenter.x + wanderAreaSize.x / 2f);
        float randomY = Random.Range(wanderAreaCenter.y - wanderAreaSize.y / 2f, wanderAreaCenter.y + wanderAreaSize.y / 2f);
        targetPosition = new Vector2(randomX, randomY);

    }

}
