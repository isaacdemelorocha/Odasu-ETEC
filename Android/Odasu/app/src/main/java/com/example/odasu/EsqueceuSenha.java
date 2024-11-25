package com.example.odasu;

import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import java.sql.SQLException;


public class EsqueceuSenha extends AppCompatActivity {

    TextView txtMensagem;

    EditText edtcpfouemail;

    String senha;

    Acessa objA = new Acessa();

    int codUsuario;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_esqueceu_senha);

        //Recuperar codUsuario do Intent
        codUsuario = getIntent().getIntExtra("codUsuario", -1);//Valor padrão é -1

        txtMensagem = findViewById(R.id.txtMensagemSenha);
        edtcpfouemail = findViewById(R.id.edtCPFouEmail);

    }

    public void esqueceuSenha(View v)
    {
        objA.entBanco(this);
        String cpfouemail = edtcpfouemail.getText().toString();

        if(!cpfouemail.isEmpty()) {
            try {
                objA.RS = objA.stmt.executeQuery("SELECT senha_usuario FROM tb_usuario WHERE cpf_usuario='"+cpfouemail+"' OR email_usuario = '"+cpfouemail+"' ");

                if (objA.RS.next()) {
                    senha = objA.RS.getString("senha_usuario");
                    txtMensagem.setText(senha);
                    txtMensagem.setTextColor(Color.WHITE);
                    txtMensagem.setBackgroundColor(Color.GREEN);
                    edtcpfouemail.setText("");
                } else {
                    txtMensagem.setText("Este usuário não está cadastrado no nosso sistema.");
                    edtcpfouemail.setText("");
                }
            } catch(SQLException ex){
                Toast.makeText(getApplicationContext(),"SQL erro", Toast.LENGTH_SHORT).show();
            }
        }else{
            txtMensagem.setText("Credenciais inválidas, preencha o campo requisitado.");
            txtMensagem.setTextColor(Color.WHITE);
            txtMensagem.setBackgroundColor(Color.RED);
        }

    }

    public void voltarInicio(View v)
    {
        Intent intent = new Intent(EsqueceuSenha.this, TelaPrincipal.class);
        startActivity(intent);
        finish();
    }
}