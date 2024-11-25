package etesp.gov.br.odasu.entity;

import java.time.LocalDate;

import etesp.gov.br.odasu.dto.Usuario;
import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;

@Entity(name = "tb_usuario")
public class UsuarioEntity {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "cod_usuario")
	private Long cod;
	@Column(name = "nome_usuario", length = 100)
	private String nome;
	@Column(name = "sobrenome_usuario", length = 100)
	private String sobrenome;
	@Column(name = "cpf_usuario", unique = true, length = 11)
	private String cpf;
	@Column(name = "nasc_usuario")
	private LocalDate nasc;
	@Column(name = "cel_usuario", length = 15)
	private String celular;
	@Column(name = "email_usuario",nullable = false, unique = true, length = 100)
	private String email;
	@Column(name = "senha_usuario", length = 255)
	private String senha;
	@Column(name = "status_usuario", length = 50)
	private String status;
	@Column(name = "tipo_conta", length = 50)
	private String tipo;
	
	public UsuarioEntity()
	{}
	public UsuarioEntity(Usuario usuario)
	{
		this.cod = usuario.getCod();
		this.nome = usuario.getNome();
		this.sobrenome = usuario.getSobrenome();
		this.cpf = usuario.getCpf();
		this.nasc = usuario.getNascimento();
		this.celular = usuario.getCelular();
		this.email = usuario.getEmail();
		this.senha = usuario.getSenha();
		this.status = usuario.getStatus();
		this.tipo = usuario.getTipoConta();
	}
	
	public Long getCod() {
		return cod;
	}
	public void setCod(Long cod) {
		this.cod = cod;
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
	public LocalDate getNasc() {
		return nasc;
	}
	public void setNasc(LocalDate nasc) {
		this.nasc = nasc;
	}
	public String getCelular() {
		return celular;
	}
	public void setCelular(String celular) {
		this.celular = celular;
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
	public String getStatus() {
		return status;
	}
	public void setStatus(String status) {
		this.status = status;
	}
	public String getTipo() {
		return tipo;
	}
	public void setTipo(String tipo) {
		this.tipo = tipo;
	}
	@Override
	public String toString() {
		return "UsuarioEntity [cod=" + cod + ", nome=" + nome + ", sobrenome=" + sobrenome + ", cpf=" + cpf + ", nasc="
				+ nasc + ", celular=" + celular + ", email=" + email + ", senha=" + senha + ", status=" + status
				+ ", tipo=" + tipo + "]";
	}
	
	
	
	
}
