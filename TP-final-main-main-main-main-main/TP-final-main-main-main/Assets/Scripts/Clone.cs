using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    // Start is called before the first frame update
    float time_to_Spawn = 2f;
    float interval = 5f;
    public GameObject manzana;
    //int cloneAmount = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

      
        if (Time.time > time_to_Spawn)
        {

            Vector3 position = new Vector3(Random.Range(-12.35f, 12.4f), 0.31f, Random.Range(-12.39f, 12.33f));
            Instantiate(manzana, position, Quaternion.identity);
          
           
            //instantate 
            time_to_Spawn += interval;
        }
    
     }




}
