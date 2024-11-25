package etesp.gov.br.odasu.entity;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;

@Entity(name = "tb_pedido")
public class PedidoEntity {

	@Id
	@Column(name = "num_pedido")
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Long numPedido;
	@Column(name = "cod_produto_pedido")
	private Long codProdutoPedido;
	@Column(name = "cod_usuario_pedido")
	private Long codUsuarioPedido;

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

	@Override
	public String toString() {
		return "PedidoEntity [numPedido=" + numPedido + ", codProdutoPedido=" + codProdutoPedido + ", codUsuarioPedido="
				+ codUsuarioPedido + "]";
	}
	
	

}
