using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OswaldoNPC : NPCGenerico
{
    // -- DIALOGO -------------------
    // -- ARQUIVOS DE CONVERSA --
    // -- FASE 1 --
    public TextAsset txtAssetConv1; // Introdução
    public TextAsset txtAssetConv2; // Sem remédio
    public TextAsset txtAssetConv3; // Entregou remédio
    public TextAsset txtAssetConv4; // Dps do remédio

    // -- SWITCHES --
    private bool boolConv1 = true;
    private bool boolConv2 = false;
    private bool boolConv3 = false;
    private bool boolConv4 = false;

    /*
    void Start()
    {
        //CarregarTexto(txtAssetConv1);
        switchCarga = true;
    }*/

    
    protected override void Interacao(int chave)
    {
        if (chave == 0)
        {
            if (boolConv1)
            {
                CarregarFala(txtAssetConv1);
                IterarTexto();
            }
            else if (boolConv2)
            {
                CarregarFala(txtAssetConv2);
                IterarTexto();
            }
        }
        else if (chave == 4)
        {
            Debug.Log("usou chave");
        }



        
    }



    protected override void MudarCargaConv()
    {
        if (boolConv1)
        {
            boolConv1 = false;
            boolConv2 = true;
            switchCarga = true;
        }
    }

    // TRATANDO MENSAGEM DE INTERAÇÃO
    protected override void DefinirTipos()
    {
        acao = acaoNPC;
    }
}
