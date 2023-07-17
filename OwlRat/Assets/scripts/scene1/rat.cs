using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rat : MonoBehaviour
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
    public float avoidanceDistance = 2f;
    public float avoidanceSpeed = 5f;


    public float minX = -5f; // Kamera sınırları
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;


    public countManager countMan;

    int count = 0;
    GameObject owl;
    bool activated;

    public float additionAngle;
    void Start()
    {
        GetNewWanderDirection();
        owl = GameObject.Find("owl");
      

    }
    void Update()
    {


        //if (owl.transform.parent.GetChild(1).gameObject.activeSelf)
        //{
        //    wanderSpeed = 5;
        //}

       
        if (count >= 3)
        {
            wanderSpeed = 3;
            owl.SetActive(false);
            owl.transform.parent.GetChild(1).gameObject.SetActive(true);

            if (!activated)
            {
                owl.transform.parent.GetChild(1).GetChild(0).gameObject.SetActive(true);
                activated = true;
            }



        }
        else if (count == 2)
        {
            if (owl.transform.GetChild(0).gameObject != null)
            {
                if (!owl.transform.GetChild(0).gameObject.activeSelf)
                {
                    owl.transform.GetChild(0).gameObject.SetActive(true);
                }
            }
        }

        if (GameObject.Find("owl2")!=null)
        {
           
            if (Vector2.Distance(transform.position, GameObject.Find("owl2").transform.position) < 1.5f)
            {
              
                Destroy(gameObject);
            }
        }
        Debug.Log("sa");
        if (activated==false)
        {
            speedTimer += Time.deltaTime;
            if (5 <= speedTimer)
            {
                wanderSpeed += 3;
                speedTimer = 0;
                count++;
            }
            if (GameObject.Find("owl") != null)
            {
                if (Vector2.Distance(transform.position, GameObject.Find("owl").transform.position) < 1f)
                {
                    Destroy(gameObject);
                }
            }
        }
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
