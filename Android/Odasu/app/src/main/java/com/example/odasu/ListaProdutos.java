package com.example.odasu;

import android.os.Bundle;
import android.util.Log;
import android.widget.ArrayAdapter;
import android.widget.Spinner;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.lifecycle.ViewModelProvider;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import java.sql.SQLException;

public class ListaProdutos extends AppCompatActivity {

    // Instância da classe Acessa
    Acessa objA = new Acessa();

    // Spinners
    Spinner spnFiltrarCategoria, spnFiltrarZona;

    // Spinner de categorias
    private static final String[] categorias =
            {"Categorias", "Móveis", "Eletroeletrônico", "Perfumaria", "Acessórios"};
    ArrayAdapter<String> categoriasFiltrarAdaptado;

    // Spinner de zona
    private static final String[] zonas =
            {"Localização", "Zona Norte", "Zona Sul", "Zona Leste", "Zona Oeste"};
    ArrayAdapter<String> zonaFiltrarAdaptado;

    // RecyclerView para exibir os produtos
    RecyclerView recyclerView;
    ProdutoAdapter produtoAdapter;
    int codUsuario;

    // ViewModel
    private ProdutoViewModel produtoViewModel;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_lista_produtos);

        // Recuperar codUsuario do Intent
        codUsuario = getIntent().getIntExtra("codUsuario", -1); // Valor padrão é -1

        // Inicializa os componentes da UI
        spnFiltrarCategoria = findViewById(R.id.spnFiltrarCategoria);
        spnFiltrarZona = findViewById(R.id.spnFiltrarZona);

        // Configuração do Spinner de categorias
        categoriasFiltrarAdaptado = new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, categorias);
        spnFiltrarCategoria.setAdapter(categoriasFiltrarAdaptado);

        // Configuração do Spinner de zonas
        zonaFiltrarAdaptado = new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, zonas);
        spnFiltrarZona.setAdapter(zonaFiltrarAdaptado);

        // Configura o RecyclerView
        recyclerView = findViewById(R.id.recListaProdutos);
        recyclerView.setLayoutManager(new LinearLayoutManager(this));

        // Inicializa o ViewModel
        produtoViewModel = new ViewModelProvider(this).get(ProdutoViewModel.class);

        // Observa os produtos no ViewModel
        produtoViewModel.getProdutos().observe(this, produtos -> {
            if (produtos != null && !produtos.isEmpty()) {
                // Carregar produtos no RecyclerView
                if (produtoAdapter == null) {
                    produtoAdapter = new ProdutoAdapter(this, produtos);
                    recyclerView.setAdapter(produtoAdapter);
                } else {
                    produtoAdapter.atualizarProdutos(produtos);
                }
            }
        });


        // Carregar os produtos do banco de dados
        produtoViewModel.carregarProdutos(this);

        // Atualizar o status do usuário
        atualizarStatus("ONLINE");
    }

    // Método para atualizar o status do usuário no banco de dados
    public void atualizarStatus(String status) {
        objA.entBanco(this);

        if (codUsuario != -1) {
            try {
                objA.stmt.executeUpdate("UPDATE tb_usuario SET status_usuario='" + status + "' WHERE cod_usuario='" + codUsuario + "' ");
            } catch (SQLException e) {
                Toast.makeText(getApplicationContext(), "Erro ao atualizar o status: " + e.getMessage(), Toast.LENGTH_SHORT).show();
            }
        }
    }
}
