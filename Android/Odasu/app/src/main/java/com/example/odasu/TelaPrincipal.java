package com.example.odasu;

import android.content.Intent;
import android.os.Bundle;
import android.view.MenuItem;
import android.view.View;
import android.widget.Toast;


import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.google.android.material.bottomnavigation.BottomNavigationView;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class TelaPrincipal extends AppCompatActivity {

    //FrameLayout frameLayout;
    BottomNavigationView btnNav;
    RecyclerView rcvTelaPrincipal;
    List<String> titulos;
    List<Integer> imagens;
    AdapterTelaPrincipal adapterTelaPrincipal;

    Acessa objA = new Acessa();
    int codUsuario;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_tela_principal);

        //Recuperar codUsuario do Intent
        codUsuario = getIntent().getIntExtra("codUsuario", -1);//Valor padrão é -1

        //frameLayout = findViewById(R.id.frameLayout);
        btnNav = findViewById(R.id.btnMenu);
        rcvTelaPrincipal = findViewById(R.id.rcvTelaPrincipal);

        // Definindo a Home como selecionada por padrão
        btnNav.setSelectedItemId(R.id.navHome);


        btnNav.setOnItemSelectedListener(new BottomNavigationView.OnItemSelectedListener() {
            @Override
            public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                Intent intent = null;

                // Usando um mapa para relacionar IDs a Intents
                Map<Integer, Class<?>> activityMap = new HashMap<>();
                activityMap.put(R.id.navHome, TelaPrincipal.class);
                activityMap.put(R.id.navBusca, ListaProdutos.class);

                // Verifica se o usuário está logado
                if (codUsuario != -1) {
                    activityMap.put(R.id.navAnunciar, CadastrarProdutos.class);
                    activityMap.put(R.id.navConta, OpcoesConta.class);
                } else {
                    activityMap.put(R.id.navAnunciar, Login.class);
                    activityMap.put(R.id.navConta, Login.class);
                }

                // Obter a classe correspondente ao item selecionado
                Class<?> activityClass = activityMap.get(item.getItemId());
                if (activityClass != null) {
                    intent = new Intent(getApplicationContext(), activityClass);
                    // Passar codUsuario se o usuário estiver logado
                    if (codUsuario != -1) {
                        intent.putExtra("codUsuario", codUsuario);
                    }
                    startActivity(intent);
                    overridePendingTransition(0, 0); // Remove animação de transição
                    return true;
                }

                return false;
            }
        });



        //card tela principal
        titulos = new ArrayList<>();
        imagens = new ArrayList<Integer>();

        titulos.add("Destaques");
        titulos.add("Mais Procurados");
        titulos.add("Moda Feminina");
        titulos.add("Moda Masculina");
        titulos.add("Salão");
        titulos.add("Decoração");


        imagens.add(R.drawable.ic_destaques_24);
        imagens.add(R.drawable.ic_mais_procurados_24);
        imagens.add(R.drawable.ic_moda_feminina_24);
        imagens.add(R.drawable.ic_moda_masculina_24);
        imagens.add(R.drawable.ic_salao_24);
        imagens.add(R.drawable.ic_decoracao_24);


        adapterTelaPrincipal = new AdapterTelaPrincipal(this, titulos, imagens);

        GridLayoutManager gridLayoutManager = new GridLayoutManager(this, 2,GridLayoutManager.VERTICAL, false);
        rcvTelaPrincipal.setLayoutManager(gridLayoutManager);
        rcvTelaPrincipal.setAdapter(adapterTelaPrincipal);


        atualizarStatus("ONLINE");

    }

    public void atualizarStatus(String status)
    {
        objA.entBanco(this);

        if(codUsuario != -1) {
            try {
                objA.stmt.executeUpdate("UPDATE tb_usuario SET status_usuario='"+status+"' WHERE cod_usuario='" + codUsuario + "' ");
            } catch (SQLException e) {
                Toast.makeText(getApplicationContext(), "Erro ao atualizar o status: " + e.getMessage(), Toast.LENGTH_SHORT).show();
            }
        }
    }

    public void irListaProdutos(View v)
    {
        Intent intent = new Intent(this, ListaProdutos.class);
        intent.putExtra("codUsuario", codUsuario);//Passa o cod_usuario para próxima atividade
        startActivity(intent);
        finish();
    }

}