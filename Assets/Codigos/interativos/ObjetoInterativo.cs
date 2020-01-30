using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjetoInterativo : InterativoGenerico
{
    // Classe dedicada a objetos interativos (chaves, portas, etc...)

    public int idObj;
    public string nomeObj;
    public string desc;

    public bool pegavel;

    public GameObject controleInventario, controleDialogo;

    public Sprite imgInventario;

    public string[] strAcoes = new string[1]; // Textos de ações possiveis ao se aproximar
                                              // 0 -> Botão E, 1 -> Botão R

    public void Awake()
    {
        controleInventario = GameObject.FindGameObjectWithTag("Controle Inventario");
        controleDialogo = GameObject.FindGameObjectWithTag("controle_dialogo");
    }


    void Update()
    {
        // Detectando proximidade com o jogador
        DetectarPLayer();
        if (estaProximo == true && estadoAnterior == false)
        {
            textoUI.text = "[E] " + strAcoes[0] + " " + nomeObj + "\n" + "[R] " + strAcoes[1] + " " + nomeObj;
        }
        else if(estaProximo == false && estadoAnterior == true) {
            textoUI.text = " ";
        }
    }

    protected void AbrirInventario()
    {
        if (player.GetComponent<Controle_Player>().visivelBtn == false)
        {
            player.GetComponent<Controle_Player>().botoesInventario.SetActive(true);
            player.GetComponent<Controle_Player>().visivelBtn = true;
        }
    }

    protected void FecharInventario()
    {
        if (player.GetComponent<Controle_Player>().visivelBtn == true)
        {
            player.GetComponent<Controle_Player>().botoesInventario.SetActive(false);
            player.GetComponent<Controle_Player>().visivelBtn = false;
        }
    }


    /* Método sobreposto onde é definida qual sera a interacao do player com o objeto
    protected override void Interacao()
    {
        estadoAnterior = proximoInd;
        proximoInd = false;
        textoUI.text = " ";

        controleInventario.GetComponent<ControleInventario>().AdicionarItem(idObj, nomeObj, desc);


        Destroy(this.gameObject);
    }*/
}