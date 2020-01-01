using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle_Player : MonoBehaviour
{
    public float velocidade = 9;
    public GameObject botoesInventario; // Vetor que guarda os botões do inventario
    public bool mostrarBtn = true; // Boolean que indica se deve mostrar ou ocultar os botões
    public bool visivelBtn = false; // Indica se os botões estão ou não visiveis

    private void Awake()
    {
        botoesInventario = GameObject.FindGameObjectWithTag("Btn"); // Mandando game objects com a tag btn para o vetor
    }

    public void Start()
    {
        botoesInventario.SetActive(false); // Desativando o inventario por aqui pq pelo inspector impede do objeto ser carregado
    }

    void FixedUpdate()
    {
        Andar();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            UsarInventario();
        }
    }

    void Andar()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * velocidade;
        float y = Input.GetAxis("Vertical") * Time.deltaTime * velocidade;

        transform.Translate(x, y, 0);
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
