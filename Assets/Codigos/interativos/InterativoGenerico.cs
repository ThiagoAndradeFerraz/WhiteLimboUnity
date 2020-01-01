using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class InterativoGenerico : MonoBehaviour
{
    /* Classe dedicada a definir caracteristicas que serão compartilhadas em aspectos interativos 
    (objetos, npcs, etc...) */

    public Transform player;
    protected float distanciaMinima = 2.0f;
    protected bool estaProximo = false; // Indica se o player esta proximo ou não
    protected bool estadoAnterior = false; // Serve para evitar constantes repetições sem necessidade

    public Text textoUI;

    // Método dedicado a detectar a proximidade do jogador
    protected void DetectarPLayer()
    {
        if (Vector2.Distance(this.transform.position, player.position) < distanciaMinima){
            estadoAnterior = estaProximo;
            estaProximo = true;
            // Debug.Log("esta perto");
            EntradaPlayer();
        }
        else
        {
            estadoAnterior = estaProximo;
            estaProximo = false;
            // Debug.Log(" ");
        }
    }

    // Método dedicado a identificar se as teclas de interação foram ou não pressionadas
    protected void EntradaPlayer()
    {
        if (Input.GetKeyDown("r"))
        {
            Interacao();
        }
    }

    // Método abstrato de ação para cada interação feita
    protected abstract void Interacao();

    public abstract void Interacao2(bool resultado); /* Método abstrato de uso exclusivo a objetos como portas, NPCs e outros que não sejam
                                                        coletaveis. Serve para o controle de inventario definir o que vai acontecer após um 
                                                        clique no inventario. */
}