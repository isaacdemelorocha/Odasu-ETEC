package etesp.gov.br.odasu.dto;

public class DetalhePedido {

	private Long codDetalheped;
	private Long codPedidoDetalheped;
	private Long codProdutoDetalheped;
	
	public DetalhePedido() {}

	public DetalhePedido(Long codDetalheped, Long codPedidoDetalheped, Long codProdutoDetalheped) {
		this.codDetalheped = codDetalheped;
		this.codPedidoDetalheped = codPedidoDetalheped;
		this.codProdutoDetalheped = codProdutoDetalheped;
	}

	public Long getCodDetalheped() {
		return codDetalheped;
	}

	public void setCodDetalheped(Long codDetalheped) {
		this.codDetalheped = codDetalheped;
	}

	public Long getCodPedidoDetalheped() {
		return codPedidoDetalheped;
	}

	public void setCodPedidoDetalheped(Long codPedidoDetalheped) {
		this.codPedidoDetalheped = codPedidoDetalheped;
	}

	public Long getCodProdutoDetalheped() {
		return codProdutoDetalheped;
	}

	public void setCodProdutoDetalheped(Long codProdutoDetalheped) {
		this.codProdutoDetalheped = codProdutoDetalheped;
	}

	@Override
	public String toString() {
		return "DetalhePedido [codDetalheped=" + codDetalheped + ", codPedidoDetalheped=" + codPedidoDetalheped
				+ ", codProdutoDetalheped=" + codProdutoDetalheped + "]";
	}

}
