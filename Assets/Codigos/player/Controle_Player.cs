using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle_Player : MonoBehaviour
{

    private Rigidbody rigidBody;
    private BoxCollider boxCollider;
    public LayerMask groundLayers;

    private float velocidade = 50;
    public GameObject botoesInventario; // Vetor que guarda os botões do inventario
    public bool mostrarBtn = true; // Boolean que indica se deve mostrar ou ocultar os botões
    public bool visivelBtn = false; // Indica se os botões estão ou não visiveis

    public bool correndo = false;

    private void Awake()
    {
        botoesInventario = GameObject.FindGameObjectWithTag("Btn"); // Mandando game objects com a tag btn para o vetor
    }

    public void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();

        botoesInventario.SetActive(false); // Desativando o inventario por aqui pq pelo inspector impede do objeto ser carregado
    }

    void FixedUpdate()
    {
        Andar();
        //Pular();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            UsarInventario();
        }
    }

    void Andar()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidade = 100;
            correndo = true;
        }
        else
        {
            if(correndo == true)
            {
                velocidade = 50;
                correndo = false;
            }
        }


        float x = Input.GetAxis("Horizontal") * Time.deltaTime * velocidade;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * velocidade;

        transform.Translate(x, 0, z);
    }

    void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //float y = velocidade * Time.deltaTime * 5;
            //transform.Translate(0, y, 0);

            rigidBody.AddForce(Vector3.up * 7, ForceMode.Impulse);

        }
    }

    private bool EstaNoChao()
    {
        return false;
    }

    public void UsarInventario()
    {
        // Ativando/desativando a visibilidade dos botões de inventario
        botoesInventario.SetActive(mostrarBtn);
        mostrarBtn = !mostrarBtn;
        if (mostrarBtn == true)
        {
            visivelBtn = false;
        }
        else
        {
            visivelBtn = true;
        }
    }
}
