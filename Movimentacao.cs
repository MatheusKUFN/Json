using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{

    float _velocidade = 20.0F;
    float _girar = 60.0F;
    float ponto = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coletavel"))
        {
            ponto += 1;
            //other.gameObject.transform.position = new Vector3(0,0,0);

        }
    }

    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        float movV = (Input.GetAxis("Vertical") * _velocidade) * Time.deltaTime;
        float movH = (Input.GetAxis("Horizontal") * _girar) * Time.deltaTime;

        transform.Translate(0, 0, movV);
        transform.Rotate(0, movH, 0);
    }
}