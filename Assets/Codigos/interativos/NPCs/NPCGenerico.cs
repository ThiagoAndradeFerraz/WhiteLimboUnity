using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class NPCGenerico : MonoBehaviour
{
    // -- DIALOGO -- 
    public string texto; // String que contem todo o conteúdo da conversa
    public string[] linhas; // Vetor usado para salvar linha a linha
    public string[] partes; // Vetor usado para salvar cada conteúdo espefico da linha
    public int tamanho, contador = 0; // Inteiros usados para controle da interação do texto
    protected bool switchCarga = true;
    // -------------

    // -- UI -------
    public Text txtNome, txtFala;
    protected Text txtAlertas;
    public GameObject painelDialogo;
    // -------------

    // -- DETECÇÃO DO JOGADOR --
    protected GameObject playerGObj;
    protected Transform player;
    protected float distanciaMinima = 40.0f;
    protected bool estadoAnterior = true;
    protected bool estadoAtual = false;
    protected bool pdInteragir = false; // Indica se a interação pode ser iniciada
    protected bool conversando = false;
    // -------------------------

    // -- INTERAÇÃO --
    protected bool serObjeto, serPorta, serColetavel;
    protected string acao;

    protected const string acaoPorta = "ABRIR";
    protected const string acaoNPC = "FALAR";
    protected const string acaoColetavel = "PEGAR";
    protected const string acaoObj = "INTERAGIR";

    protected GameObject objInventario; // Objeto que guarda o script do controle de inventario

    void Start()
    {
        // PREENCHENDO AS VARIAVEIS AUTOMATICAMENTE -----------

        playerGObj = GameObject.FindGameObjectWithTag("Player");
        player = playerGObj.transform;

        txtAlertas = GameObject.FindGameObjectWithTag("txt_alertas").GetComponent<Text>();

        objInventario = GameObject.FindGameObjectWithTag("Controle Inventario");

        // ----------------------------------------------------

        // DEFININDO CARACTERISTICAS DE INTERAÇÃO
        DefinirTipos();
    }


    void Update()
    {
        DetectarProximidade();
    }


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
                painelDialogo.SetActive(true);
                conversando = true;
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
            painelDialogo.SetActive(false);
            contador = 0;
            conversando = false;
            MudarCargaConv();
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
                txtAlertas.text = "[E] - " + acao;

                

                estadoAtual = true;
                estadoAnterior = estadoAtual;

                pdInteragir = true;
            }

            if (pdInteragir == true)
            {
                int slotUsado = 0;


                // MAPEANDO BOTÕES

                if (Input.GetKeyDown(KeyCode.E)) // INTERAÇÃO NORMAL
                {
                    Interacao(0);
                }
                else if (Input.GetKeyDown(KeyCode.R)) {
                    slotUsado = objInventario.GetComponent<ControleInvt>().UsarItem(1);
                    Interacao(slotUsado);
                }
                else if (Input.GetKeyDown(KeyCode.T))
                {
                    slotUsado = objInventario.GetComponent<ControleInvt>().UsarItem(2);
                    Interacao(slotUsado);
                }
                else if (Input.GetKeyDown(KeyCode.Y))
                {
                    slotUsado = objInventario.GetComponent<ControleInvt>().UsarItem(3);
                    Interacao(slotUsado);
                }
            }
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



    protected void CarregarFala(TextAsset texto)
    {
        Debug.Log("começou a carregar!");

        if (switchCarga == true)
        {
            CarregarTexto(texto);
            Debug.Log("3 - mandou carregar!");

            switchCarga = false;
        }
    }

    // Método de interação (a ser reescrito pelas classes filhas de acordo com suas necessidades)
    //protected abstract void Interacao();
    protected abstract void Interacao(int chave); // 0 = SEM OBJETO / 0 < = COM OBJETO

    protected abstract void MudarCargaConv();

    protected abstract void DefinirTipos(); // Define se é um NPC, objeto ou objeto coletavel
}
