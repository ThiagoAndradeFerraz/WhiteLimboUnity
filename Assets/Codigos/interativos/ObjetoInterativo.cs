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

    public GameObject controleInventario;

    public Sprite imgInventario;

    public void Awake()
    {
        controleInventario = GameObject.FindGameObjectWithTag("Controle Inventario");
    }


    void Update()
    {
        // Detectando proximidade com o jogador
        DetectarPLayer();
        if (estaProximo == true && estadoAnterior == false)
        {
            textoUI.text = "[E] Ver " + nomeObj + "\n" + "[R] Pegar " + nomeObj;
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