using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInventario 
{
    // ---------------------------------------------------------------------
    // Classe modelo dedicada a definir caracteristicas de um objeto pegavel
    // ---------------------------------------------------------------------

    // Variaveis
    private int idObjeto;
    private string nomeObjeto;
    private string descricaoObj;
    private Sprite imagemObj;

    // Construtor
    public ObjInventario(int id, string nome, string desc, Sprite imagem)
    {
        idObjeto = id;
        this.nomeObjeto = nome;
        this.descricaoObj = desc;
        this.imagemObj = imagem;
    }

    // Métodos get para uso externo

    public int getId()
    {
        return idObjeto;
    }

    public string getNome()
    {
        return nomeObjeto;
    }

    public string getDesc()
    {
        return descricaoObj;
    }
}
