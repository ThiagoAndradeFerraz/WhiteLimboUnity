using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chave : ObjetoInterativo
{
    // Sobrepondo o método de interação do jogador com o objeto
    protected override void Interacao()
    {
        estadoAnterior = estaProximo;
        estaProximo = false;
        textoUI.text = " "; //Limpando o texto de alerta

        // Adicionando objeto a lista de inventario na memória
        controleInventario.GetComponent<ControleInventario>().AdicionarItem(idObj, nomeObj, desc, imgInventario);

        if(controleInventario.GetComponent<ControleInventario>().adicionou == true)
        {
            Destroy(this.gameObject);
            controleInventario.GetComponent<ControleInventario>().adicionou = false; // Reiniciando variavel
        }
    }

    // IGNORAR PARA ESSE MÉTODO
    public override void Interacao2(bool resultado)
    {
        
    }
}
