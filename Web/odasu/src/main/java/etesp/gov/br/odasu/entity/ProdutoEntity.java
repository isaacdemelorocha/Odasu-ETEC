package etesp.gov.br.odasu.entity;

import java.math.BigDecimal;

import jakarta.persistence.*;

@Entity(name = "tb_produto")
public class ProdutoEntity {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "cod_produto")
	private Long codProduto;
	@ManyToOne
	@JoinColumn(name = "cod_usuario_produto")
	private UsuarioEntity codUsuarioProduto; // É um tipo de entidade e não um Long
	@ManyToOne
	@JoinColumn(name = "cod_categoria_produto")
	private CategoriaEntity codCategoriaProduto;
	@Column(name = "nome_produto", length = 80)
	private String nomeProduto;
	@Column(name = "descricao_produto", length = 200)
	private String descricaoProduto;
	@Column(name = "preco_produto", precision = 10, scale = 2)
	private BigDecimal preco;
	@Column(name = "imagem1_produto", columnDefinition = "VARBINARY(MAX)")
	private byte[] imagem1;
	@Column(name = "imagem2_produto", columnDefinition = "VARBINARY(MAX)")
	private byte[] imagem2;
	@Column(name = "imagem3_produto", columnDefinition = "VARBINARY(MAX)")
	private byte[] imagem3;
	@Column(name = "imagem4_produto", columnDefinition = "VARBINARY(MAX)")
	private byte[] imagem4;
	@Column(name = "status_produto", length = 10)
	private String statusProduto;
	@Column(name = "local_produto", length = 20)
	private String localProduto;

	public Long getCodProduto() {
		return codProduto;
	}

	public void setCodProduto(Long codProduto) {
		this.codProduto = codProduto;
	}

	public UsuarioEntity getCodUsuarioProduto() {
		return codUsuarioProduto;
	}

	public void setCodUsuarioProduto(UsuarioEntity codUsuarioProduto) {
		this.codUsuarioProduto = codUsuarioProduto;
	}

	public CategoriaEntity getCodCategoriaProduto() {
		return codCategoriaProduto;
	}

	public void setCodCategoriaProduto(CategoriaEntity codCategoriaProduto) {
		this.codCategoriaProduto = codCategoriaProduto;
	}

	public String getNomeProduto() {
		return nomeProduto;
	}

	public void setNomeProduto(String nomeProduto) {
		this.nomeProduto = nomeProduto;
	}

	public String getDescricaoProduto() {
		return descricaoProduto;
	}

	public void setDescricaoProduto(String descricaoProduto) {
		this.descricaoProduto = descricaoProduto;
	}
	public BigDecimal getPreco() {
		return preco;
	}

	public void setPreco(BigDecimal preco) {
		this.preco = preco;
	}

	public byte[] getImagem1() {
		return imagem1;
	}

	public void setImagem1(byte[] imagem1) {
		this.imagem1 = imagem1;
	}

	public byte[] getImagem2() {
		return imagem2;
	}

	public void setImagem2(byte[] imagem2) {
		this.imagem2 = imagem2;
	}

	public byte[] getImagem3() {
		return imagem3;
	}

	public void setImagem3(byte[] imagem3) {
		this.imagem3 = imagem3;
	}

	public byte[] getImagem4() {
		return imagem4;
	}

	public void setImagem4(byte[] imagem4) {
		this.imagem4 = imagem4;
	}

	public String getStatusProduto() {
		return statusProduto;
	}

	public void setStatusProduto(String statusProduto) {
		this.statusProduto = statusProduto;
	}

	public String getLocalProduto() {
		return localProduto;
	}

	public void setLocalProduto(String localProduto) {
		this.localProduto = localProduto;
	}

}
