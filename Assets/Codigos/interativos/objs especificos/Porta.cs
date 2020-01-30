using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : ObjetoInterativo
{
    protected int objetoEsperado = 1;

    protected override void Interacao()
    {
        AbrirInventario(); // Abrindo o inventario (caso esteja fechado)

        // Marcando qual é o objeto que a interação esta sendo feita
        controleInventario.GetComponent<ControleInventario>().objetoInteragido = this.gameObject;
        


        // Definindo a ID do objeto esperado, para a operação de comparação de IDs
        controleInventario.GetComponent<ControleInventario>().idObjEsperado = objetoEsperado;
    }

    public override void Interacao2(bool resultado)
    {
        if(resultado == true)
        {
            Debug.Log("Abri a porta");


            FecharInventario();

            // Removendo o item usado
            controleInventario.GetComponent<ControleInventario>().RemoverItem(objetoEsperado);

        }
        else
        {
            Debug.Log("A porta continua trancada...");
        }

        // Limpando a variavel no controle
        controleInventario.GetComponent<ControleInventario>().objetoInteragido = null;

        // Fechando o inventario
        player.GetComponent<Controle_Player>().UsarInventario();
    }
}
