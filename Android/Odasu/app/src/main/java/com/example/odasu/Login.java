package com.example.odasu;

import android.content.Intent;

import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import java.sql.SQLException;

public class Login extends AppCompatActivity {

    //Instancias
    Acessa objA = new Acessa();

    //INPUTS
    EditText loginEmail, loginSenha;

    TextView esqSenha, txtMensagem;

    int codUsuario = -1; //valor inicial indicando que não foi capturado ainda

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        //Recuperar codUsuario do Intent
        codUsuario = getIntent().getIntExtra("codUsuario", -1);//Valor padrão é -1

        //INPUTS
        loginEmail = findViewById(R.id.editLoginName);
        loginSenha = findViewById(R.id.editLoginPassword);

        //Text View mensagem "Credenciais inccoretas"
        txtMensagem = findViewById(R.id.txtMensagem);

        esqSenha = findViewById(R.id.txtEsqueceuSuaSenha);

    }

    public void irCadastro(View cadastro)
    {
        Intent intent = new Intent(Login.this, CadastrarUsuario.class);
        startActivity(intent);
        finish();
    }

    public void irEsqueceuSenha(View esqueceuSenha)
    {
        Intent intent = new Intent(Login.this, EsqueceuSenha.class);
        startActivity(intent);
        finish();
    }

    public void loginUsuario(View login)
    {

        objA.entBanco(this);

        String email = loginEmail.getText().toString();
        String senha = loginSenha.getText().toString();

        try
        {
            objA.RS = objA.stmt.executeQuery("SELECT * FROM tb_usuario WHERE email_usuario='"+email+"' AND senha_usuario='"+senha+"' ");

            if(objA.RS.next())
            {
                codUsuario = objA.RS.getInt("cod_usuario");

                Intent intent = new Intent(Login.this, TelaPrincipal.class);
                intent.putExtra("codUsuario", codUsuario);//Passa o cod_usuario para próxima atividade
                startActivity(intent);
                finish();
            }//FIM IF
            else
            {
                //Toast.makeText(getApplicationContext(),"Credenciais Invalidas, Verifique o e-mail e a senha", Toast.LENGTH_SHORT).show();
                txtMensagem.setText("Credenciais inválidas, verifique o e-mail e a senha");
                loginEmail.setText("");
                loginSenha.setText("");
            }
        }
        catch (SQLException ex)
        {
            Toast.makeText(getApplicationContext(), "SQL erro", Toast.LENGTH_SHORT).show();
        }//fim catch
    }
}