using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float LongRay = 4.0f;

    public float altura = 1.0f;
    public float distancia = 1.0f;
    public float alturaGiro = 1.0f;

    public Transform transPlayer;
    public Transform transCamara;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player = transPlayer.position;

        Vector3 playerUp = transPlayer.up;
        Vector3 playerForward = transPlayer.forward;

        Vector3 resultado = player + playerUp * altura - playerForward * distancia;

        transCamara.position = resultado;


        Vector3 CamaraForwardNew = player + playerUp * alturaGiro - transCamara.position;

        transCamara.rotation = Quaternion.LookRotation(CamaraForwardNew);


        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * LongRay, Color.red);
    }
}
