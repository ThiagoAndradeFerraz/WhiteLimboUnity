using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleDialogo : MonoBehaviour
{
    // Lista que guarda os objetos de imagem (populado pelo Inspector)
    public List<GameObject> atores = new List<GameObject>();


    // TALVEZ NÃO PRECISE USAR O ABAIXO!
    // Lista que guarda os rostos a serem exibidos pelos atores
    //public List<ObjRostos> rostos = new List<ObjRostos>();


    
    private Sprite spriteMestreEsquerda;
    private Sprite spriteMestreDireita;




    public bool conversando = false;
    public bool estadoAnterior = true;

    public bool pdIterarAutomaticamente = true;

    public int tamanho, contador = 0;

    // Objeto pai na hierarquia de UI relacionada a operações de dialogo
    public GameObject paiDialogo;

    // Objetos de texto onde as informações serão exibidas
    public Text nomePersonagem;
    public Text fala;

    // Espaço onde será recebida as falas da conversa a ser exibida
    public List<ObjDialogo> conversa;


    public void Awake()
    {
        // Desativando o botão de iteração de texto
        LigarUI(false);
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
                LigarUI(false);
                conversa = null;
                contador = 0;
                tamanho = 0;
            }
        }
    }


    // Método para ser chamado externamente e obter o texto da conversa
    public void ConfigurarTexto(List<ObjDialogo> texto)
    {
        conversa = texto;
    }

    // Método usado para iniciar as configurações da conversa
    public void IniciarConversa()
    {
        tamanho = conversa.Count;
        LigarUI(true);

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

            //Debug.Log(conversa[contador].getNome() + ": " + conversa[contador].getFala());

            nomePersonagem.text = conversa[contador].getNome();
            fala.text = conversa[contador].getFala();

            spriteMestreEsquerda = Resources.Load<Sprite>(conversa[contador].getRostoEsq()); // Srite do rosto esquerdo
            spriteMestreDireita = Resources.Load<Sprite>(conversa[contador].getRostoDireita()); // Sprite do rosto direito

            atores[1].GetComponent<SpriteRenderer>().sprite = spriteMestreEsquerda;
            atores[2].GetComponent<SpriteRenderer>().sprite = spriteMestreDireita;



            // ====
            // plano: de acordo com o que estiver no arquivo, pegar a imagem da lista de imagens
            // ====

            // TESTE - APAGAR DPS!!!!
            //atores[0].sprite = Resources.Load<Sprite>("Assets/Texturas/Placeholders/Rostos/NEUTRO-2.png");
            // TESTE - APAGAR DEPOIS!!!!!

            //atores[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("NEUTRO-1");

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

    // Método dedicado a ligar / desligar a UI relacionada as operações de dialogo
    public void LigarUI(bool comando)
    {
        
        paiDialogo.SetActive(comando);

        // Objetos de imagem dos atores
        // atores[0].gameObject.SetActive(comando); -> FUNDO A SER MUDADO É O FUNDO DO CENARIO
        atores[1].gameObject.SetActive(comando);
        atores[2].gameObject.SetActive(comando);

        




    }
}