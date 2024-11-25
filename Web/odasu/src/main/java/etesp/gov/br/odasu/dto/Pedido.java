package etesp.gov.br.odasu.dto;

public class Pedido {
	
	private Long numPedido;
	private Long codProdutoPedido;
	private Long codUsuarioPedido;
	private String nomeUsuario;
	
	public Pedido() {}
	
	public Pedido(Long numPedido, Long codProdutoPedido, Long codUsuarioPedido) {
		this.numPedido = numPedido;
		this.codProdutoPedido = codProdutoPedido;
		this.codUsuarioPedido = codUsuarioPedido;
	}

	public Long getNumPedido() {
		return numPedido;
	}

	public void setNumPedido(Long numPedido) {
		this.numPedido = numPedido;
	}

	public Long getCodProdutoPedido() {
		return codProdutoPedido;
	}

	public void setCodProdutoPedido(Long codProdutoPedido) {
		this.codProdutoPedido = codProdutoPedido;
	}

	public Long getCodUsuarioPedido() {
		return codUsuarioPedido;
	}

	public void setCodUsuarioPedido(Long codUsuarioPedido) {
		this.codUsuarioPedido = codUsuarioPedido;
	}

	public String getNomeUsuario() {
		return nomeUsuario;
	}

	public void setNomeUsuario(String nomeUsuario) {
		this.nomeUsuario = nomeUsuario;
	}

	@Override
	public String toString() {
		return "Pedido [numPedido=" + numPedido + ", codProdutoPedido=" + codProdutoPedido + ", codUsuarioPedido="
				+ codUsuarioPedido + ", nomeUsuario=" + nomeUsuario + "]";
	}

	
	
	
	
	
}
