using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleDialogo : MonoBehaviour
{
    public bool conversando = false;
    public bool estadoAnterior = true;

    public bool pdIterarAutomaticamente = true;

    public int tamanho, contador = 0;

    // Botão de iteração do texto
    public GameObject btnProx;

    // Espaço onde será recebida as falas da conversa a ser exibida
    public List<string> conversa;


    public void Awake()
    {
        // Desativando o botão de iteração de texto
        btnProx.SetActive(false);
        conversa = null;
    }



    public void Update()
    {
        if (conversando == true)
        {
            /*
            if (estadoAnterior == conversando)
            {
                estadoAnterior = !conversando;
            }*/

            

            IniciarConversa();
        }
        else
        {
            // Checagem para evitar processamento desnecessário
            if (estadoAnterior == !conversando)
            {
                // Reiniciando as configurações
                btnProx.SetActive(false);
                conversa = null;
                contador = 0;
                tamanho = 0;
            }
        }
    }


    // Método para ser chamado externamente e obter o texto da conversa
    public void ConfigurarTexto(List<string> texto)
    {
        conversa = texto;
    }

    // Método usado para iniciar as configurações da conversa
    public void IniciarConversa()
    {
        tamanho = conversa.Count;
        btnProx.SetActive(true);

        if(pdIterarAutomaticamente == true)
        {
            IterarConversa();
            pdIterarAutomaticamente = false;
        }
    }

    // Método usado pelo clique do botão de dialogo
    public void IterarConversa()
    {
        if (contador < tamanho) 
        {
            // Exibição normal dos dados de cada linha

            Debug.Log(conversa[contador]);
            contador++;
        }
        else
        {
            // Tratando quando é chegado no fim da leitura

            pdIterarAutomaticamente = true;
            conversando = false;
            estadoAnterior = !conversando;
            Debug.Log(" ");
        }

    }
}