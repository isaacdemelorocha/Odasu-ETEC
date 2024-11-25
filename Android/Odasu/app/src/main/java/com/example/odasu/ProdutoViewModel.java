package com.example.odasu;

import android.content.Context;
import android.util.Log;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class ProdutoViewModel extends ViewModel {

    private final MutableLiveData<List<Produto>> produtosLiveData = new MutableLiveData<>();
    private final Acessa objA = new Acessa();

    // Função para obter os produtos
    public LiveData<List<Produto>> getProdutos() {
        return produtosLiveData;
    }

    // Função para carregar os produtos do banco de dados
    public void carregarProdutos(Context context) {
        new Thread(new Runnable() {
            @Override
            public void run() {
                objA.entBanco(context);

                try {
                    objA.RS = objA.stmt.executeQuery("SELECT nome_produto, imagem1_produto, descricao_produto, preco_produto, local_produto, status_produto FROM tb_produto");

                    List<Produto> listaProdutos = new ArrayList<>();

                    while (objA.RS.next()) {
                        String nome = objA.RS.getString("nome_produto");
                        Log.d("ProdutoViewModel", "Produto encontrado: " + nome);

                        String descricao = objA.RS.getString("descricao_produto");
                        double preco = objA.RS.getDouble("preco_produto");
                        String local = objA.RS.getString("local_produto");
                        String status = objA.RS.getString("status_produto");

                        ArrayList<byte[]> imagens = new ArrayList<>();
                        byte[] imagem1 = objA.RS.getBytes("imagem1_produto");
                        if (imagem1 != null) {
                            imagens.add(imagem1);
                            Log.d("MostrarProduto", "Imagem carregada para o produto: " + nome + " com tamanho: " + imagem1.length);
                        } else {
                            Log.d("MostrarProduto", "Sem imagem para o produto: " + nome);
                        }

                        Produto produto = new Produto(nome, descricao, preco, imagens, local, status);
                        listaProdutos.add(produto); // Adiciona à lista
                    }

                    if (listaProdutos.isEmpty()) {
                        Log.d("ProdutoViewModel", "Nenhum produto encontrado no banco de dados.");
                    } else {
                        Log.d("ProdutoViewModel", "Produtos encontrados: " + listaProdutos.size());
                    }

// Atualiza os dados no LiveData
                    produtosLiveData.postValue(listaProdutos);
                } catch (SQLException ex) {
                    ex.printStackTrace();
                    produtosLiveData.postValue(null); // Caso haja erro
                }
            }
        }).start();
    }
}

