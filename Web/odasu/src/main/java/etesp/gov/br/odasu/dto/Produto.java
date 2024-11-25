package etesp.gov.br.odasu.dto;

import java.math.BigDecimal;

import etesp.gov.br.odasu.entity.CategoriaEntity;

public class Produto {

	private Long codProduto;
	private Long codUsuarioProduto;
	private CategoriaEntity codCategoriaProduto;
	private String nomeProduto;
	private String descricaoProduto;
	private BigDecimal precoProduto;
	private String imagem1; // Agora é uma String Base64
	private String imagem2;
	private String imagem3;
	private String imagem4;
	private String statusProduto;
	private String localProduto;

	public Produto() {
	}

	public Produto(Long codProduto, Long codUsuarioProduto, CategoriaEntity codCategoriaProduto, String nomeProduto,
			String descricaoProduto, BigDecimal precoProduto, String imagem1, String imagem2, String imagem3,
			String imagem4, String statusProduto, String localProduto) {
		super();
		this.codProduto = codProduto;
		this.codUsuarioProduto = codUsuarioProduto;
		this.codCategoriaProduto = codCategoriaProduto;
		this.nomeProduto = nomeProduto;
		this.descricaoProduto = descricaoProduto;
		this.precoProduto = precoProduto;
		this.imagem1 = imagem1;
		this.imagem2 = imagem2;
		this.imagem3 = imagem3;
		this.imagem4 = imagem4;
		this.statusProduto = statusProduto;
		this.localProduto = localProduto;
	}

	public Long getCodProduto() {
		return codProduto;
	}

	public void setCodProduto(Long codProduto) {
		this.codProduto = codProduto;
	}

	public Long getCodUsuarioProduto() {
		return codUsuarioProduto;
	}

	public void setCodUsuarioProduto(Long codUsuarioProduto) {
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

	public BigDecimal getPrecoProduto() {
		return precoProduto;
	}

	public void setPrecoProduto(BigDecimal precoProduto) {
		this.precoProduto = precoProduto;
	}

	public String getImagem1() {
		return imagem1;
	}

	public void setImagem1(String imagem1) {
		this.imagem1 = imagem1;
	}

	public String getImagem2() {
		return imagem2;
	}

	public void setImagem2(String imagem2) {
		this.imagem2 = imagem2;
	}

	public String getImagem3() {
		return imagem3;
	}

	public void setImagem3(String imagem3) {
		this.imagem3 = imagem3;
	}

	public String getImagem4() {
		return imagem4;
	}

	public void setImagem4(String imagem4) {
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

	@Override
	public String toString() {
		return "Produto [codProduto=" + codProduto + ", codUsuarioProduto=" + codUsuarioProduto + ", nomeProduto="
				+ nomeProduto + ", precoProduto=" + precoProduto + ", imagem1=" + imagem1 + "]";
	}

}
