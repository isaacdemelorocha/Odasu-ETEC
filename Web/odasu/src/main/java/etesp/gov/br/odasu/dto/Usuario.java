package etesp.gov.br.odasu.dto;

import java.time.LocalDate;

import com.fasterxml.jackson.annotation.JsonFormat;

public class Usuario {
	
	private Long cod;
	private String nome;
	private String sobrenome;
	private String cpf;
	@JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "yyyy-MM-dd")
	private LocalDate nascimento;
	private String email;
	private String senha;
	private String celular;
	private String status;
	private String tipoConta;
	
	public Usuario()
	{}

	public Usuario(Long cod, String nome, String sobrenome, String cpf, LocalDate nascimento, String email, String senha, String celular, String status, String tipoConta) 
	{ 
		this.cod = cod;
		this.nome = nome; 
		this.sobrenome = sobrenome;
		this.cpf = cpf;
		this.nascimento = nascimento;
		this.email = email; 
		this.senha = senha;
		this.celular = celular;
		this.status = status;
		this.tipoConta = tipoConta;
	}
	
	

	public Long getCod() {
		return cod;
	}



	public void setCod(Long cod) {
		this.cod = cod;
	}



	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
	}

	public String getTipoConta() {
		return tipoConta;
	}

	public void setTipoConta(String tipoConta) {
		this.tipoConta = tipoConta;
	}

	public String getNome() {
		return nome;
	}
	public void setNome(String nome) {
		this.nome = nome;
	}
	public String getSobrenome() {
		return sobrenome;
	}
	public void setSobrenome(String sobrenome) {
		this.sobrenome = sobrenome;
	}
	public String getCpf() {
		return cpf;
	}
	public void setCpf(String cpf) {
		this.cpf = cpf;
	}
	public LocalDate getNascimento() {
		return nascimento;
	}
	public void setNascimento(LocalDate nascimento) {
		this.nascimento = nascimento;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public String getSenha() {
		return senha;
	}
	public void setSenha(String senha) {
		this.senha = senha;
	}
	public String getCelular() {
		return celular;
	}
	public void setCelular(String celular) {
		this.celular = celular;
	}
	
	@Override
	public String toString() {
		return "Usuario [nome=" + nome + ", sobrenome=" + sobrenome + ", cpf=" + cpf + ", nascimento=" + nascimento
				+ ", email=" + email + ", senha=" + senha + ", celular=" + celular + "]";
	}
	
	

}
