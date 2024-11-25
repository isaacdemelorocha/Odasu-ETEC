package com.example.odasu;

import java.util.ArrayList;

public class Produto {

    private String nome;
    private String descricao;

    private String local;

    private String status;
    private double preco;
    private ArrayList<byte[]> imagens;

    public Produto(String nome, String descricao, double preco, ArrayList<byte[]> imagens, String local, String status)
    {
        this.nome = nome;
        this.descricao = descricao;
        this.local = local;
        this.status = status;
        this.preco = preco;
        this.imagens = imagens;
    }

    public String getLocal() {
        return local;
    }

    public String getStatus() {
        return status;
    }

    public String getNome() {
        return nome;
    }

    public String getDescricao() {
        return descricao;
    }

    public double getPreco() {
        return preco;
    }

    public ArrayList<byte[]> getImagens() {
        return imagens;
    }
}
