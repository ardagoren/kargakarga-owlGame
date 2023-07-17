using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class araSahne : MonoBehaviour
{
    public GameObject obj;
    public GameObject obj2;

    public string nextScene;

    public int limit;
    float time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        obj.transform.Translate(transform.up * 5 * Time.deltaTime);
        obj2.transform.Translate(transform.up * 5 * Time.deltaTime);

        if(time>limit)
        SceneManager.LoadScene(nextScene);


    }
}
