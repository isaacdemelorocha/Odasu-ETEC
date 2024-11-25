package com.example.odasu;

import android.content.Intent;
import android.os.Bundle;
import android.text.TextWatcher;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import java.sql.SQLException;

public class CadastrarUsuario extends AppCompatActivity {

    //Instancias
    Acessa objA = new Acessa();

    //Inputs
    EditText cadNome, cadSobrenome, cadSenha, cadEmail, cadCpf, cadCelular, cadNascimento;

    String statusON = "OFFLINE";
    String tipoConta = "CLIENT";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cadastrar_usuario);


        //INPUTS
        cadNome = findViewById(R.id.editNomeCadastro);
        cadSobrenome = findViewById(R.id.editSobrenomeCadastro);
        cadSenha = findViewById(R.id.editSenhaCadastro);
        cadEmail = findViewById(R.id.editEmailCadastro);
        cadCpf = findViewById(R.id.editCPFCadastro);
        cadCelular = findViewById(R.id.editCelularCadastro);
        cadNascimento = findViewById(R.id.editDataNasc);

        //Inicio Mascara

        /* Data de Nascimento
           Cria mascara */
        TextWatcher criarMascara = Mascara.aplicarMascara(cadNascimento, "##/##/####");
        //Adiciona mascara ao objeto
        cadNascimento.addTextChangedListener(criarMascara);
        //mascara na dica
        cadNascimento.setHint("00/00/0000");

        //CPF
        criarMascara = Mascara.aplicarMascara(cadCpf, "###.###.###-##");
        cadCpf.addTextChangedListener(criarMascara);
        cadCpf.setHint("000.000.000-00");

        //Celular
        criarMascara = Mascara.aplicarMascara(cadCelular, "(##) #####-####");
        cadCelular.addTextChangedListener(criarMascara);
        cadCelular.setHint("(00) 00000-0000");

        //Fim Mascara


    }

    public void irLogin(View login)
    {
        Intent intent = new Intent(CadastrarUsuario.this, Login.class);
        startActivity(intent);
        finish();
    }



    public void cadastrarUsuario(View v) {


        String nome = cadNome.getText().toString();
        String sobrenome = cadSobrenome.getText().toString();
        String cpf = cadCpf.getText().toString();
        String nascimento = cadNascimento.getText().toString();
        String celular = cadCelular.getText().toString();
        String email = cadEmail.getText().toString();
        String senha = cadSenha.getText().toString();

        objA.entBanco(this);


        try {

            objA.RS = objA.stmt.executeQuery("SELECT * FROM tb_usuario WHERE email_usuario = '" + email + "' OR cpf_usuario='" + cpf + "' OR cel_usuario='" + celular + "' ");

            //Se houver um registro, significa que o email, cpf ou celular já existe
            if (objA.RS.next()) {
                Toast.makeText(getApplicationContext(), "Já existe um usuário com estas credenciais", Toast.LENGTH_SHORT).show();
                cadEmail.setText("");
                cadCpf.setText("");
            } else {

                //Removendo mascara para inserir no banco de dados
                //obs: Se remover a mascara antes do insert não da delay no app
                String rmvMaskCPF = Mascara.removerMascara(cpf);
                String rmvMaskCelular = Mascara.removerMascara(celular);

                int res = objA.stmt.executeUpdate("INSERT INTO tb_usuario(nome_usuario,sobrenome_usuario,cpf_usuario,nasc_usuario,cel_usuario,email_usuario,senha_usuario,status_usuario,tipo_conta) VALUES ('" + nome + "', '" + sobrenome + "', '" + rmvMaskCPF + "', '" + nascimento + "', '" + rmvMaskCelular + "', '" + email + "', '" + senha + "', '"+statusON+"', '"+tipoConta+"') ");
                if (res != 0) {
                    //Toast.makeText(getApplicationContext(), "Cadastrado", Toast.LENGTH_SHORT).show();

                    cadNome.setText("");
                    cadSobrenome.setText("");
                    cadCpf.setText("");
                    cadNascimento.setText("");
                    cadCelular.setText("");
                    cadEmail.setText("");
                    cadSenha.setText("");

                    Intent intent = new Intent(CadastrarUsuario.this, Login.class);
                    startActivity(intent);
                    finish();
                }//FIM IF
                else {
                    Toast.makeText(getApplicationContext(), "Falha ao Cadastrar", Toast.LENGTH_SHORT).show();
                }//FIM ELSE


            }//FIM ELSE
        }//FIM TRY
        catch (SQLException ex) {
            Toast.makeText(getApplicationContext(), "Erro SQL" + ex, Toast.LENGTH_SHORT).show();
        }
    }

}