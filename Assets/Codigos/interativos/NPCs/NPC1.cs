using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1 : ObjetoInterativo
{
    // Lista de falas da conversa 1
    public List<string> conversa1 = new List<string>();

    public bool dialogo = true; // VÁRIAVEL TEMPORARIA!!!!!

    protected override void Interacao()
    {   
        if(dialogo == true)
        {
            // Definindo o texto 
            MandarTexto(conversa1);
        }
    }

    // Método onde é definido o texto a ser mandado para o controle de dialogo
    public void MandarTexto(List<string> texto)
    {
        controleDialogo.GetComponent<ControleDialogo>().conversando = true;
        controleDialogo.GetComponent<ControleDialogo>().ConfigurarTexto(texto);
    }

    public override void Interacao2(bool resultado)
    {
        
    }

    /*
    private void IniciarConversa()
    {
        // Definindo o estado do jogo
        conversando = true;

        // Obtendo o tamanho da lista a ser iterada
        tamanho = conversa1.Count;

        IterarConversa();
    }

    private void IterarConversa()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("clicou!");

            if (contador <= tamanho)
            {
                Debug.Log(conversa1[contador]);
                contador++;
            }
            else
            {

            }
        }

    }
    */
}
