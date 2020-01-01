using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnInventario : MonoBehaviour
{
    public bool usado = false;
    public int idObjeto = 0;

    public GameObject controleInventario;

    private void Awake()
    {
        controleInventario = GameObject.FindGameObjectWithTag("Controle Inventario");
    }

    // Passa a id do objeto que o slot armazena para uma variavel do controleInventario
    public void SelecionarObjeto()
    {
        if (idObjeto != 0)
        {
            // Definindo a ID do objeto clicado
            controleInventario.GetComponent<ControleInventario>().idObjClicado = idObjeto;

            // Mandando o controle fazer a comparação de chaves
            controleInventario.GetComponent<ControleInventario>().CompararChaves();



            //Debug.Log(controleInventario.GetComponent<ControleInventario>().idObjClicado);
        }
    }


}
