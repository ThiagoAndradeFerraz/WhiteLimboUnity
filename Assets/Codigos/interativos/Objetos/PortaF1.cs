using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaF1 : NPCGenerico
{
    // ----- PORTA USADA NA FASE 1 ------------------
    // -- ARQUIVOS DE CONVERSA --
    public TextAsset textAsset1; // PORTA TRANCADA
    public TextAsset textAsset2; // DESTRASNCADA

    // -- SWITCHS DE PROGRESSO --
    public bool desTrancado = false;
    public int aberto = 0;

    protected override void Interacao(int chave)
    {
        
        if(chave == 4)
        {
            if(aberto == 0)
            {
                desTrancado = true;
                CarregarFala(textAsset2);
                IterarTexto();
                aberto = 1;
            }
        }
        else
        {
            if(desTrancado == false)
            {
                CarregarFala(textAsset1);
                IterarTexto();
            }
            else
            {
                if(aberto == 1)
                {
                    IterarTexto();
                    aberto = 2;
                }
                else
                {
                    Debug.Log("saiu");
                }
            }
        }
           
    }

    protected override void MudarCargaConv()
    {
        
    }


    // TRATANDO MENSAGEM DE INTERAÇÃO
    protected override void DefinirTipos()
    {
        acao = acaoPorta;
    }
}
