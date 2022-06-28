using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeBehaviour : MonoBehaviour
{
    // public GameObject ActivateandDeactivate;

    //float movementSpeed = 0.10f;
    // Start is called before the first frame update
    public float MoveSpeed= 5;
    public float  SteerSpeed= 180;
    public GameObject cuerpo;
    int manzana;
    public AudioClip eatingApple;
    public AudioClip Gameover;
    AudioSource fuenteDeAudio;
    public Text CurrentScore;
    int contador;
    public GameObject PanelGameOver;
    public GameObject PanelWin;
    int CantCubos = 0;
    public GameObject cube;


    void Start()
    {
        PanelGameOver.SetActive(false);
        PanelWin.SetActive(false);
        fuenteDeAudio = GetComponent<AudioSource>();
    } 

    // Update is called once per frame
    void Update()
    {
        

        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        float SteerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * SteerDirection * SteerSpeed * Time.deltaTime);
        /*
        if (Input.GetKey(KeyCode.S))
        {

            transform.Translate(0, 0, movementSpeed);
        }
        if (Input.GetKey(KeyCode.W))
        {

            transform.Translate(0, 0, -movementSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {

            transform.Translate(movementSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {

            transform.Translate(-movementSpeed, 0, 0);
        }
        */
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            PanelGameOver.SetActive(true);
            //Destroy(gameObject);
            gameObject.SetActive(false);
            while (CantCubos < 100)
            {
                Instantiate(cube);
                CantCubos++;
            }
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "manzana")
        {
            Destroy(col.gameObject);
            fuenteDeAudio.clip = eatingApple;
            fuenteDeAudio.Play();

            // movement.AddBodyPart();
            //manzana = manzana + 1;

            contador = contador + 1;
            CurrentScore.text = contador.ToString();
            MoveSpeed = MoveSpeed + 0.5f;
            SteerSpeed = SteerSpeed + 0.5f;
            if (contador == 10)
            {
                PanelWin.SetActive(true);
                while(CantCubos < 100)
                {
                    Instantiate(cube);
                    CantCubos++ ;
                }
            }
         }
    }

}
        