package etesp.gov.br.odasu.entity;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;

@Entity(name = "tb_detalhe_pedido")
public class DetalhePedidoEntity {

	@Id
	@Column(name = "cod_detalheped")
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Long codDetalheped;
	@Column(name = "cod_pedido_detalheped")
	private Long codPedidoDetalheped;
	@Column(name = "cod_produto_detalheped")
	private Long codProdutoDetalheped;
	
	public DetalhePedidoEntity() {}

	public DetalhePedidoEntity(Long codDetalheped, Long codPedidoDetalheped, Long codProdutoDetalheped) {
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
		return "DetalhePedidoEntity [codDetalheped=" + codDetalheped + ", codPedidoDetalheped=" + codPedidoDetalheped
				+ ", codProdutoDetalheped=" + codProdutoDetalheped + "]";
	}
	
	

}
