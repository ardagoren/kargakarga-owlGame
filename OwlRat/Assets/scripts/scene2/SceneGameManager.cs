using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGameManager : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public ratSpawn ratSpawn;
    public GameObject owl;
    public GameObject owl2;
    float timer = 0;

    bool sayac;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (ratSpawn.instancesCount==5)
        {
            if(text1!=null)
            text1.SetActive(true);
            sayac = true;
            
        }
        if (sayac)
        {
            timer += Time.deltaTime;
        }

        

        if (timer > 7)
        {

          
            text2.SetActive(false);

        }
        else if (timer > 4)
        {

            owl.SetActive(false);
            owl2.SetActive(true);
            text2.SetActive(true);

        }
        if (timer > 10)
        {
            if(GameObject.FindGameObjectWithTag("kamufleRat")==null && GameObject.FindGameObjectWithTag("rat")==null)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
