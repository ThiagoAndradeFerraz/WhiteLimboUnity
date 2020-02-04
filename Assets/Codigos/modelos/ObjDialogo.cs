using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDialogo 
{
    // =================================================
    // Classe modelo dedicada a definir caracteristicas 
    // de uma linha de dialogo
    // =================================================

    private string nomePersonagem, fala = null;
    private string dirRosto1, dirRosto2, dirFundo = null; // Diretórios das imagens a serem exibidas
    private int tipoLinha = 0;

    // -----------------------------------------------------------------------------
    // Sobre a variavel 'tipoLinha':
    //      Define o tipo de linha que está sendo lida, que pode ser:
    //          -Uma linha de dialogo normal -> 0
    //          -Uma linha finalizadora, que faz o inventario ser aberto -> 1
    //          -Uma linha finalizadora, que faz o menu de escolha ser chamado -> 2
    // -----------------------------------------------------------------------------


    // NOME PERSONAGEM
    public string getNome()
    {
        return nomePersonagem;
    }

    public void setNome(string nome)
    {
        nomePersonagem = nome;
    }

    // ------------------------------------

    // FALA
    public string getFala()
    {
        return fala;
    }

    public void setFala(string fala)
    {
        this.fala = fala;
    }

    // ------------------------------------

    // DIRETÓRIO ROSTO 1
    public string getDirRosto1()
    {
        return dirRosto1;
    }

    public void setDirRosto1(string diretorio)
    {
        dirRosto1 = diretorio;
    }

    // ------------------------------------

    // DIRETÓRIO ROSTO 2
    public string getDirRosto2()
    {
        return dirRosto2;
    }

    public void setDirRosto2(string diretorio)
    {
        dirRosto2 = diretorio;
    }

    // ------------------------------------

    // DIRETÓRIO IMAGEM DE FUNDO
    public string getDirFundo()
    {
        return dirFundo;
    }

    public void setDirFundo(string diretorio)
    {
        dirFundo = diretorio;
    }

    // ------------------------------------

    // TIPO DE LINHA
    public int getTipo()
    {
        return tipoLinha;
    }

    public void setTipo(int tipo)
    {
        tipoLinha = tipo;
    }
}




