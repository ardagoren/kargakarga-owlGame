using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strongCat : MonoBehaviour
{
    public float wanderSpeed = 5f; // Objenin dolaşma hızı
    public Vector2 wanderAreaCenter; // Dolaşma alanının merkez noktası
    public Vector2 wanderAreaSize; // Dolaşma alanının boyutları

    float speedTimer = 0f;


    GameObject player;

    private Vector2 wanderDirection;
    private Vector2 targetPosition;

    private float timer = 0f;
    private float rotateChange = 2f;

    public float minX = -5f; // Kamera sınırları
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    public Quaternion bul;
    int count = 0;
    GameObject owl;
     GameObject owl2;
    bool activated;

    float eatTimer=0f;
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

        if (GameObject.Find("owl2")==null)
        {
            if (Vector2.Distance(transform.position, owl.transform.position) < 1f)
            {
                eatTimer += Time.deltaTime;
                Debug.Log(eatTimer);
                if (eatTimer > 2)
                    Destroy(gameObject);
            }
            else
            {
                eatTimer = 0;
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
