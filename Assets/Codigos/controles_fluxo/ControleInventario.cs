using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleInventario : MonoBehaviour
{
    // --------------------------------------------------------
    // Classe dedicada a cuidar do fluxo da lista de inventario
    // --------------------------------------------------------

    public int idObjClicado = 0; // Objeto clicado no inventario
    public int idObjEsperado = 0; // Objeto esperado em relação a uma interação (ex: porta espera chave)

    public GameObject objetoInteragido = null; // Game Object do objeto que o jogador interagiu (porta, NPC, etc..)
    public ScriptableObject objInteragidoScript = null;


    public bool adicionou = false; // Indica se o processo de inclusão de objeto foi ou não bem sucedido.

    // Vetor que guarda os game objects de cada botão do inventario
    public Button[] botoes; 

    // Lista do inventario
    public static List<ObjInventario> listaInventario = new List<ObjInventario>();

    // Método dedicado a adicionar itens para a lista
    public void AdicionarItem(int id, string nome, string desc, Sprite imagem)
    {
        // Iterando o vetor de botões em busca de um slot vazio para preencher
        for(int i = 0; i < botoes.Length; i++)
        {
            // Checando se o botão é vazio
            if (botoes[i].GetComponent<BtnInventario>().usado == false)
            {
                listaInventario.Add(new ObjInventario(id, nome, desc, imagem)); // Guardando o objeto na memória
                botoes[i].image.sprite = imagem; // Mudando imagem do slot escolhido
                botoes[i].GetComponent<BtnInventario>().usado = true; // Marcando slot como usado
                botoes[i].GetComponent<BtnInventario>().idObjeto = id;


                adicionou = true; // Indicando que o processo foi concluido com sucesso

                // Debug.Log("Slot usado: " + i);
                break;
            }
            else // Caso não tenha espaço
            {
                if (i == (botoes.Length - 1))
                {
                    if (botoes[i].GetComponent<BtnInventario>().usado == true)
                    {
                        Debug.Log("NÃO TEM ESPAÇO");
                    }
                }
            }
        }
    }

    // Método dedicado a remover itens especificos com base em determinada ID
    public void RemoverItem(int id)
    {
        // Removendo da memória
        listaInventario.RemoveAll(o => o.getId() == id);

        // Iterando o vetor de botões em busca de um slot onde o objeto esteja guardado
        for (int i = 0; i < botoes.Length; i++)
        {
            // Checando se o botão certo foi achado
            if (botoes[i].GetComponent<BtnInventario>().usado == true && botoes[i].GetComponent<BtnInventario>().idObjeto == id)
            {
                botoes[i].image.sprite = null; // Mudando imagem do slot escolhido
                botoes[i].GetComponent<BtnInventario>().usado = false; // Liberando o slot para uso posterior
                botoes[i].GetComponent<BtnInventario>().idObjeto = 0; // Limpando o campo de ID

                adicionou = true; // Indicando que o processo foi concluido com sucesso

                // Debug.Log("Slot usado: " + i);
                break;
            }
        }


    }

    // Método dedicado a checar se um objeto clicado no inventario é o objeto certo para determinada interação
    public void CompararChaves()
    {
        bool resultado;

        if (idObjClicado == idObjEsperado) // Em caso do objeto fornecido se o objeto esperado
        {
            resultado = true;
        }
        else
        {
            resultado = false;
        }

        // Mandando o objeto decidir o que fazer com base no resultado
        objetoInteragido.GetComponent<InterativoGenerico>().Interacao2(resultado);

        // Limpando as IDs
        idObjClicado = 0;
        idObjEsperado = 0;
    }
}
