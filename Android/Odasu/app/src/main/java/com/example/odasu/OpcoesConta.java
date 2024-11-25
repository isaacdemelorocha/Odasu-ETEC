package com.example.odasu;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.text.TextWatcher;
import android.view.View;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import java.sql.SQLException;


public class OpcoesConta extends AppCompatActivity {

    Acessa objA = new Acessa();

    ImageView imgVUsuario;

    int codUsuario;

    TextView txtId, txtCPF, txtNasc;
    EditText edtNome, edtSobrenome, edtEmail, edtCelular, edtSenhaAntiga, edtSenhaNova;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_opcoes_conta);

        //Recuperar codUsuario do Intent
        codUsuario = getIntent().getIntExtra("codUsuario", -1);//Valor padrão é -1

        imgVUsuario = findViewById(R.id.imgVUsuario);
        imgVUsuario.setImageResource(R.drawable.userphoto);

        txtId = findViewById(R.id.txtIdUsuario);
        txtCPF = findViewById(R.id.txtCPFUsuario);
        txtNasc = findViewById(R.id.txtDataNascUsuario);
        edtNome = findViewById(R.id.edtNomeUsuario);
        edtSobrenome = findViewById(R.id.edtSobrenomeUsuario);
        edtEmail = findViewById(R.id.edtEmailUsuario);
        edtCelular = findViewById(R.id.edtCelularUsuario);
        edtSenhaAntiga = findViewById(R.id.edtSenha1);
        edtSenhaNova = findViewById(R.id.edtSenha2);

        //Inicio Mascara
        //Celular
        TextWatcher criarMascara = Mascara.aplicarMascara(edtCelular, "(##) #####-####");
        edtCelular.addTextChangedListener(criarMascara);
        edtCelular.setHint("(00) 00000-0000");
        //Fim Mascara

        atualizarStatus("ONLINE");
        recuperarDados();

    }

    public void logout(View v) {
        // Atualiza o status do usuário
        atualizarStatus("OFFLINE");

        codUsuario = -1;

        // Inicia a atividade de login
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
        finish();
    }

    public void alterarSenha(View v)
    {
        objA.entBanco(this);

        String id = txtId.getText().toString();
        String senhaAntiga = edtSenhaAntiga.getText().toString();
        String senhaNova = edtSenhaNova.getText().toString();
        String senhaBD;

        if(senhaAntiga.isEmpty())
        {
            edtSenhaAntiga.requestFocus();
            Toast.makeText(getApplicationContext(),"Preencha o campo com a sua senha atual",Toast.LENGTH_SHORT).show();
            return;
        } else if (senhaNova.isEmpty()) {
            edtSenhaNova.requestFocus();
            Toast.makeText(getApplicationContext(),"Preencha o campo com a sua nova senha",Toast.LENGTH_SHORT).show();
            return;
        }


        try {

                objA.RS = objA.stmt.executeQuery("SELECT senha_usuario FROM tb_usuario WHERE cod_usuario='" + id + "' ");

                if(objA.RS.next()) {
                    senhaBD = objA.RS.getString("senha_usuario");

                    if (senhaAntiga.equals(senhaBD)) {
                        int res = objA.stmt.executeUpdate("UPDATE tb_usuario SET senha_usuario='" + senhaNova + "' WHERE cod_usuario='" + id + "' ");

                        if (res != 0) {
                            Toast.makeText(getApplicationContext(), "Senha alterada com sucesso!", Toast.LENGTH_SHORT).show();
                            edtSenhaAntiga.setText("");
                            edtSenhaNova.setText("");
                        }else {
                            Toast.makeText(getApplicationContext(), "Não foi possível alterar a senha.", Toast.LENGTH_SHORT).show();
                            edtSenhaAntiga.setText("");
                            edtSenhaNova.setText("");
                        }
                    }else {
                        Toast.makeText(getApplicationContext(), "Senha atual está incorreta.", Toast.LENGTH_SHORT).show();
                    }
                }else {
                    Toast.makeText(getApplicationContext(), "Usuário não encontrado.", Toast.LENGTH_SHORT).show();
                }


            } catch (SQLException ex) {
                Toast.makeText(getApplicationContext(), "Não foi possivel alterar a senha - " + ex, Toast.LENGTH_SHORT).show();
            }

    }

    public void alterar(View v){
        objA.entBanco(this);

        String id = txtId.getText().toString();
        String nome = edtNome.getText().toString();
        String sobrenome = edtSobrenome.getText().toString();
        String celular = Mascara.removerMascara( edtCelular.getText().toString());
        String email = edtEmail.getText().toString();

        //Validação
        if (id.isEmpty()) {
            txtId.requestFocus();
            Toast.makeText(getApplicationContext(),"Campo ID vazio realize Login", Toast.LENGTH_SHORT).show();
            return;//Interrompe a execução
        } else if (nome.isEmpty()) {
            edtNome.requestFocus();
            Toast.makeText(getApplicationContext(),"Preencha o campo Nome", Toast.LENGTH_SHORT).show();
            return;//Interrompe a execução
        } else if (sobrenome.isEmpty()) {
            edtSobrenome.requestFocus();
            Toast.makeText(getApplicationContext(),"Preencha o campo Sobrenome", Toast.LENGTH_SHORT).show();
            return;//Interrompe a execução
        } else if (celular.isEmpty()) {
            edtCelular.requestFocus();
            Toast.makeText(getApplicationContext(),"Preencha o campo Celular", Toast.LENGTH_SHORT).show();
            return;//Interrompe a execução
        }else if (email.isEmpty()) {
            edtEmail.requestFocus();
            Toast.makeText(getApplicationContext(),"Preencha o campo E-mail", Toast.LENGTH_SHORT).show();
            return;//Interrompe a execução
        }

        //Se todos os campos estiverem preenchidos, executa a atualização
        try{
            int res = objA.stmt.executeUpdate("UPDATE tb_usuario SET nome_usuario='"+nome+"', sobrenome_usuario='"+sobrenome+"', cel_usuario='"+celular+"', email_usuario='"+email+"' WHERE cod_usuario='"+id+"'  ");

            if(res != 0)
            {
                Toast.makeText(getApplicationContext(),"Dados atualizados com sucesso!", Toast.LENGTH_SHORT).show();
            }
            else{
                Toast.makeText(getApplicationContext(),"Nenhum dado foi atualizado.",Toast.LENGTH_SHORT).show();
            }

        }catch (SQLException ex)
        {
            Toast.makeText(getApplicationContext(),"Erro ao atualizar os dados cadastrais - " + ex, Toast.LENGTH_SHORT).show();
        }
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

    public void recuperarDados()
    {
        objA.entBanco(this);

        try {
            objA.RS = objA.stmt.executeQuery("SELECT * FROM tb_usuario WHERE cod_usuario="+codUsuario);

            if(objA.RS.next())
            {

                //Coletando os dados do banco e armazenando nas variaveis
                int id = objA.RS.getInt("cod_usuario");
                String cpf = objA.RS.getString("cpf_usuario");
                String nasc = objA.RS.getString("nasc_usuario");
                String nome = objA.RS.getString("nome_usuario");
                String sobrenome = objA.RS.getString("sobrenome_usuario");
                String email = objA.RS.getString("email_usuario");
                String celular = objA.RS.getString("cel_usuario");

                txtId.setText(String.valueOf(id));
                txtCPF.setText(cpf);
                txtNasc.setText(nasc);
                edtNome.setText(nome);
                edtSobrenome.setText(sobrenome);
                edtEmail.setText(email);
                edtCelular.setText(celular);

            }
            else
            {
                Toast.makeText(getApplicationContext(), "Nenhum usuário encontrado.", Toast.LENGTH_SHORT).show();
            }
        }catch (SQLException ex)
        {
            Toast.makeText(getApplicationContext(),"Erro na consulta: " + ex.getMessage(),Toast.LENGTH_SHORT).show();
        }

    }
}