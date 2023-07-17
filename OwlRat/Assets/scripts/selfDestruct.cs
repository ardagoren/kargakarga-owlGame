using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
      public float destructDelay = 3f; // İmha süresi (saniye)

    void OnEnable()
    {
        Invoke("DestroySelf", destructDelay);
    }

    void DestroySelf()
    {
        gameObject.SetActive(false);
        // Alternatif olarak, eğer objeyi tamamen yok etmek istiyorsanız:
        // Destroy(gameObject);
    }
}
