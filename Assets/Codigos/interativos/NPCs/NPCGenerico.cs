using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class NPCGenerico : MonoBehaviour
{
    // -- DIALOGO -- 
    public TextAsset txtAsset;
    public string texto; // String que contem todo o conteúdo da conversa
    public string[] linhas; // Vetor usado para salvar linha a linha
    public string[] partes; // Vetor usado para salvar cada conteúdo espefico da linha
    public int tamanho, contador = 0; // Inteiros usados para controle da interação do texto
    // -------------

    // -- UI -------
    public Text txtNome, txtFala, txtAlertas;
    public GameObject painel;
    // -------------

    // -- DETECÇÃO DO JOGADOR --
    public Transform player;
    protected float distanciaMinima = 40.0f;
    protected bool estadoAnterior = true;
    protected bool estadoAtual = false;
    protected bool pdInteragir = false; // Indica se a interação pode ser iniciada
    // -------------------------

    /*
    void Start()
    {
        estadoAnterior = !estadoAtual;


        CarregarTexto(txtAsset);
        IterarTexto();
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            IterarTexto();
            
        }

        DetectarProximidade();

        Debug.Log(Vector3.Distance(this.transform.position, player.position) < distanciaMinima);
    }
    */

    protected void CarregarTexto(TextAsset arquivo)
    {
        texto = arquivo.text; // Carregando o arquivo
        linhas = texto.Split('\n'); // Separando em linhas
        tamanho = linhas.Length;
    }

    protected void IterarTexto()
    {
        if (contador < tamanho)
        {
            if (contador < 1)
            {
                // Ativando a exibição do painel ao iniciar a iteração
                painel.SetActive(true);
            }

            partes = linhas[contador].Split('|');

            //txtAlertas.text = " ";

            // SEPARANDO OS COMPONENTES DA LINHA LIDA
            txtNome.text = partes[0];
            txtFala.text = partes[1];

            contador++;
        }
        else
        {
            painel.SetActive(false);
            contador = 0;
            //tamanho = 0;
        }
    }

    protected void DetectarProximidade()
    {

        if (Vector3.Distance(this.transform.position, player.position) < distanciaMinima)
        {
            // Tratando texto a ser exibido
            if(estadoAnterior != estadoAtual)
            {
                txtAlertas.text = "[E] - FALAR";
                estadoAtual = true;
                estadoAnterior = estadoAtual;

                pdInteragir = true;
            }

            if (pdInteragir == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Interacao();
                }
            }

            /*
            // Caso jogador interaja com o NPC
            if (Input.GetKeyDown(KeyCode.E))
            {
                IterarTexto();
            }*/
        }
        else
        {
            if(estadoAtual == estadoAnterior)
            {
                txtAlertas.text = " ";
                estadoAtual = false;

                pdInteragir = false;
            }
        }
    }

    // Método de interação (a ser reescrito pelas classes filhas de acordo com suas necessidades)
    protected abstract void Interacao();
}
