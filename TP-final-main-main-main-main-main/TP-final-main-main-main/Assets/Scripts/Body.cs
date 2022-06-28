using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    //public GameObject head;
    //int headSnake=1;
    public GameObject bodyPrefab;
    //int tail = 0;
    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionHistory = new List<Vector3>();
    public int Gap = 5;
    public float BodySpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PositionHistory.Insert(0, transform.position);
        int i = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionHistory[Mathf.Min(i * Gap, PositionHistory.Count - 1)];
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;
            body.transform.LookAt(point);

            i++;

        }
    }

     private void GrowSnake()
      {
        GameObject body = Instantiate(bodyPrefab);
            BodyParts.Add(body);
      }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "manzana")
        {


            GrowSnake();


            /*
         //for(int i = 0; i <   -1; i++)
         //Instantiate(body, transform.position, Quaternion.identity);
         //Vector3 position =  transform.position ;
         //  transform.position = Vector3.MoveTowards(transform.position, head.transform.position , 0.2f * Time.deltaTime);
         */
        }

    }
}