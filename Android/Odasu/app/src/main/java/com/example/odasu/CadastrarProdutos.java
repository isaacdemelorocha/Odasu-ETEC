package com.example.odasu;

import android.content.Intent;
import android.graphics.Bitmap;
import android.net.Uri;
import android.os.Bundle;
import android.provider.MediaStore;
import android.text.TextWatcher;
import android.util.Log;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import androidx.activity.result.ActivityResultLauncher;
import androidx.activity.result.contract.ActivityResultContracts;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.sql.PreparedStatement;
import java.sql.SQLException;


public class CadastrarProdutos extends AppCompatActivity {

    // Declaração da variável codigoImagem
    private int codigoImagem;

    private ActivityResultLauncher<Intent> mGetContent;

    Acessa objA = new Acessa();

    EditText edtTitulo, edtDescricao, edtValor;

    TextView txtMensagemErro;

    Spinner spnCategoria, spnZona;

    //Spinner de categorias
    private static final String[] categorias =
            {"Categorias",
                    "Móveis", "Eletroeletrônico","Perfumaria",
                    "Acessórios"};
    ArrayAdapter<String> categoriasAdaptado;


    //Spinner de zona
    private static final String[] zonas =
            {"Localização",
                    "Zona Norte", "Zona Sul","Zona Leste",
                    "Zona Oeste"};
    ArrayAdapter<String> zonaAdaptado;

    private Uri mSelectedUri;
    ImageView img1, img2, img3, img4;

    byte[] i1, i2, i3, i4;

    int codUsuario;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cadastrar_produtos);

        // Inicializa o ActivityResultLauncher
        mGetContent = registerForActivityResult(
                new ActivityResultContracts.StartActivityForResult(),
                result -> {
                    if (result.getResultCode() == RESULT_OK && result.getData() != null) {
                        Uri mSelectedUri = result.getData().getData();
                        if (mSelectedUri != null) {
                            // Chama o método para tratar a imagem selecionada
                            handleImageSelection(mSelectedUri);
                        }
                    }
                });

        //Recuperar codUsuario do Intent
        codUsuario = getIntent().getIntExtra("codUsuario", -1);//Valor padrão é -1

        img1 = findViewById(R.id.imgVFoto1);
        img2 = findViewById(R.id.imgVFoto2);
        img3 = findViewById(R.id.imgVFoto3);
        img4 = findViewById(R.id.imgVFoto4);

        edtDescricao = findViewById(R.id.editDescricaoProduto);
        edtTitulo = findViewById(R.id.editTituloProduto);
        edtValor = findViewById(R.id.editValorProduto);

        spnCategoria = findViewById(R.id.spnCategoria);
        spnZona = findViewById(R.id.spnLocalZona);

        txtMensagemErro = findViewById(R.id.txtMensagemErro);

        //Spinner categoria
        categoriasAdaptado = new ArrayAdapter<String>
                (this, android.R.layout.simple_spinner_dropdown_item,
                        categorias);
        spnCategoria.setAdapter(categoriasAdaptado);

        //Spinner zona
        zonaAdaptado = new ArrayAdapter<String>
                (this, android.R.layout.simple_spinner_dropdown_item,
                        zonas);
        spnZona.setAdapter(zonaAdaptado);

        // Adicionar o botão de voltar na Toolbar
        if (getSupportActionBar() != null) {
            getSupportActionBar().setDisplayHomeAsUpEnabled(true);
            getSupportActionBar().setDisplayShowHomeEnabled(true);
        }

        atualizarStatus("ONLINE");

    }

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

    private void handleImageSelection(Uri mSelectedUri) {
        try {
            // Abre o InputStream para a URI selecionada
            InputStream inputStream = getContentResolver().openInputStream(mSelectedUri);
            // Lê os bytes da imagem
            byte[] imageBytes = new byte[inputStream.available()];
            inputStream.read(imageBytes);
            inputStream.close();

            // Verifica qual imagem foi selecionada e a atribui ao array correspondente
            if (mSelectedUri != null) {
                if (codigoImagem == 1) {
                    img1.setImageURI(mSelectedUri);
                    i1 = imageBytes;
                } else if (codigoImagem == 2) {
                    img2.setImageURI(mSelectedUri);
                    i2 = imageBytes;
                } else if (codigoImagem == 3) {
                    img3.setImageURI(mSelectedUri);
                    i3 = imageBytes;
                } else if (codigoImagem == 4) {
                    img4.setImageURI(mSelectedUri);
                    i4 = imageBytes;
                }
            }
        } catch (Exception e) {
            Log.e("ImageSelection", "Error setting image", e);
            Toast.makeText(this, "Ocorreu um erro ao definir a imagem.", Toast.LENGTH_SHORT).show();
        }
    }

    public void selecionarFoto(int codigoImagem) {
        this.codigoImagem = codigoImagem;
        Intent intentImg = new Intent(Intent.ACTION_GET_CONTENT);
        // Filtrar imagens .jpg .jpeg .png ...
        intentImg.setType("image/*");
        // Lança a atividade de seleção de imagem usando a nova API
        mGetContent.launch(intentImg);
    }

    public void selecionarImg1(View v) {
        selecionarFoto(1);
    }

    public void selecionarImg2(View v) {
        selecionarFoto(2);
    }

    public void selecionarImg3(View v) {
        selecionarFoto(3);
    }

    public void selecionarImg4(View v) {
        selecionarFoto(4);
    }

    private int categoriaId(String categoria) {
        switch (categoria) {
            case "Móveis":
                return 1;
            case "Eletroeletrônico":
                return 2;
            case "Perfumaria":
                return 3;
            case "Acessórios":
                return 4;
            default:
                return 0;
        }
    }

    public void cadastrarProduto(View v) {
        String nomeProduto = edtTitulo.getText().toString();
        String valor = edtValor.getText().toString();
        String descricao = edtDescricao.getText().toString();

        String statusProduto = "ATIVO";
        String localProduto = spnZona.getSelectedItem().toString().toUpperCase();

        int categoriaProduto = categoriaId(spnCategoria.getSelectedItem().toString());

        if (nomeProduto.isEmpty() || valor.isEmpty() || descricao.isEmpty() || localProduto.isEmpty() || categoriaProduto == 0) {
            txtMensagemErro.setText("Falha ao anunciar certifique-se que todos os campos estão preenchidos");
            return;
        }

        objA.entBanco(this);

        try {
            PreparedStatement pstmt = objA.con.prepareStatement("INSERT INTO tb_produto(nome_produto, descricao_produto, preco_produto, imagem1_produto, imagem2_produto, imagem3_produto, imagem4_produto, status_produto, local_produto,cod_categoria_produto, cod_usuario_produto) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?,?, ?)");
            pstmt.setString(1, nomeProduto);
            pstmt.setString(2, descricao);
            pstmt.setString(3, valor);
            pstmt.setBytes(4, i1);
            pstmt.setBytes(5, i2);
            pstmt.setBytes(6, i3);
            pstmt.setBytes(7, i4);
            pstmt.setString(8, statusProduto);
            pstmt.setString(9, localProduto);
            pstmt.setInt(10, categoriaProduto);
            pstmt.setInt(11, codUsuario);

            int res = pstmt.executeUpdate();

            if (res != 0) {
                Toast.makeText(getApplicationContext(), "Produto anunciado.", Toast.LENGTH_SHORT).show();
                Intent intent = new Intent(this, ListaProdutos.class);
                startActivity(intent);
                finish();
            } else {
                txtMensagemErro.setText("Erro ao anunciar");
            }//FIM ELSE

        } catch (SQLException ex) {
            txtMensagemErro.setText("Erro SQL" + ex.getMessage());
        }
    }
}
