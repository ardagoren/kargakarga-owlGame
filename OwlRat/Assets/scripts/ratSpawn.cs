using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratSpawn : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    // Instantiate edilecek prefab nesnesi
    public Vector2 spawnAreaCenter; // Oluşturulacak nesnelerin merkez noktası
    public Vector2 spawnAreaSize; // Oluşturulacak nesnelerin alana yayılacağı boyut
    public float spawnInterval = 2f; // Nesne oluşturma aralığı (saniye)
    public int maxInstances = 10;
    // Oluşturulacak maksimum nesne sayısı

    public int instancesCount = 0;
    
    private float timer = 0f;

    void Update()
    {
        // Timer'ı güncelle
        timer += Time.deltaTime;

        // Maksimum nesne sayısını kontrol et
        if (instancesCount < maxInstances && timer >= spawnInterval)
        {
            // Yeni bir nesne oluştur
            Vector2 randomPosition = GetRandomSpawnPosition();
            Instantiate(prefabToInstantiate, randomPosition, Quaternion.identity);

            // Timer'ı sıfırla ve nesne sayısını artır
            timer = 0f;
            instancesCount++;
        }
    }

    // Oluşturulacak nesnenin rastgele konumunu al
    private Vector2 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(spawnAreaCenter.x - spawnAreaSize.x / 2f, spawnAreaCenter.x + spawnAreaSize.x / 2f);
        float randomY = Random.Range(spawnAreaCenter.y - spawnAreaSize.y / 2f, spawnAreaCenter.y + spawnAreaSize.y / 2f);

        return new Vector2(randomX, randomY);
    }
}
