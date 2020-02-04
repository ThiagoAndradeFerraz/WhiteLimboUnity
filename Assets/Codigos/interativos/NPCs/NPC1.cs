using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1 : ObjetoInterativo
{
    // Lista de falas da conversa 1
    public List<ObjDialogo> conversa1 = new List<ObjDialogo>();

    public bool dialogo = true; // VÁRIAVEL TEMPORARIA!!!!!

    public void Start()
    {
        PopularLista();
    }

    protected override void Interacao()
    {   
        if(dialogo == true)
        {
            // Definindo o texto 
            MandarTexto(conversa1);
        }
    }

    // Método onde é definido o texto a ser mandado para o controle de dialogo
    public void MandarTexto(List<ObjDialogo> texto)
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

    // Método dedicado a popular a lista
    // * Dados precisam vir de um arquivo de texto em sua versão final!!!
    public void PopularLista()
    {
        // CONVERSA TESTE, APAGAR DEPOIS!!!
        
        // FALA 1
        ObjDialogo fala1 = new ObjDialogo();
        fala1.setDirFundo(" ");
        fala1.setDirRosto1(" ");
        fala1.setDirRosto2(" ");
        fala1.setFala("olá visitante");
        fala1.setNome("michel");
        fala1.setTipo(0);

        conversa1.Add(fala1);

        // FALA 2
        ObjDialogo fala2 = new ObjDialogo();
        fala2.setDirFundo(" ");
        fala2.setDirRosto1(" ");
        fala2.setDirRosto2(" ");
        fala2.setFala("como posso sair daqui?");
        fala2.setNome("jogador");
        fala2.setTipo(0);

        conversa1.Add(fala2);

        // FALA 3
        ObjDialogo fala3 = new ObjDialogo();
        fala3.setDirFundo(" ");
        fala3.setDirRosto1(" ");
        fala3.setDirRosto2(" ");
        fala3.setFala("pegue a chave e destranque a porta!");
        fala3.setNome("michel");
        fala3.setTipo(0);

        conversa1.Add(fala3);

    }



}
