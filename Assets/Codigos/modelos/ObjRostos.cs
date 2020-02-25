using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ObjRostos
{
    public string nome, emocao;
    //public Image imgRosto;

    public string getNome()
    {
        return nome;
    }

    public void setNome(string nome)
    {
        this.nome = nome;
    }



    public string getEmocao()
    {
        return emocao;
    }

    public void setEmocao(string emocao)
    {
        this.emocao = emocao;
    }
}
