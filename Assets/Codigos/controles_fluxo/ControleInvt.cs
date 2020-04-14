using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleInvt : MonoBehaviour
{
    // CLASSE DEDICADA A TRABALHAR COM A LISTA DA CLASSE ESTATICA 'StaticInvt'
    // -----------------------------------------------------------------------

    public GameObject painelInvt;
    public Text[] slots = new Text[3]; 
    private string[] txtSlots = new string[3];



    public void Start()
    {
        txtSlots[0] = "[R] - ";
        txtSlots[1] = "[T] - ";
        txtSlots[2] = "[Y] - ";


        // TRECHO EXCLUSIVO PRA TESTE!

        ObjInvt item1 = new ObjInvt();
        item1.nome = "chave";
        item1.id = 5;
        item1.desc = "é uma chave";

        ObjInvt item2 = new ObjInvt();
        item2.nome = "garrafa";
        item2.id = 4;
        item2.desc = "é uma garrafa";

        ObjInvt item3 = new ObjInvt();
        item3.nome = "arma";
        item3.id = 2;
        item3.desc = "é uma arma";

        AddItem(item1);
        AddItem(item2);
        AddItem(item3);

        PopularUI();
        Debug.Log("Deu certo!");

        // -------------------------------
    }

    public void AddItem(ObjInvt item)
    {
        StaticInvt.lista.Add(item);
    }


    public void RemoverItem(int id)
    {
        StaticInvt.lista.RemoveAll(o => o.id == id);
    }


    public void PopularUI()
    {
        int contadorSlots = 0;

        foreach(ObjInvt item in StaticInvt.lista)
        {
            slots[contadorSlots].text = txtSlots[contadorSlots] + item.nome;
            contadorSlots++;
        }
    }

    public void ExibirPainel(bool comando)
    {
        painelInvt.SetActive(comando);
    }

    public int UsarItem(int tecla)
    {
        // DICIONARIO DE TECLAS:
        // R -> 1, T -> 2, Y -> 3

        if (StaticInvt.lista[tecla] != null)
        {
            //Debug.Log("Usando " + StaticInvt.lista[tecla].nome);

            return StaticInvt.lista[tecla].id;
        }
        else
        {
            return 0; // PRESTAR ATENÇÃO NISSO, PODE BUGAR!!!!
        }
    }
}
