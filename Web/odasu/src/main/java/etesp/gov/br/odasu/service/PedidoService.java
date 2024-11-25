package etesp.gov.br.odasu.service;

import java.util.List;

import etesp.gov.br.odasu.dto.Pedido;

public interface PedidoService {
	
	List<Pedido> listarPedidosPorUsario(Long codUsuario);
}
