package etesp.gov.br.odasu.service.impl;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import etesp.gov.br.odasu.dto.Pedido;
import etesp.gov.br.odasu.entity.PedidoEntity;
import etesp.gov.br.odasu.entity.UsuarioEntity;
import etesp.gov.br.odasu.repository.PedidoRepository;
import etesp.gov.br.odasu.repository.UsuarioRepository;
import etesp.gov.br.odasu.service.PedidoService;

@Service
public class PedidoServiceImpl implements PedidoService {
	
	@Autowired
	private PedidoRepository pedidoRepository;
	
	@Autowired
	private UsuarioRepository usuarioRepository;

	@Override
	public List<Pedido> listarPedidosPorUsario(Long codUsuario) {
		
		List<PedidoEntity> pedidosEntity = pedidoRepository.findByCodUsuarioPedido(codUsuario);
        List<Pedido> pedidos = new ArrayList<>();

        for (PedidoEntity entity : pedidosEntity) {
            Pedido pedido = new Pedido();
            pedido.setNumPedido(entity.getNumPedido());
            pedido.setCodProdutoPedido(entity.getCodProdutoPedido());
            pedido.setCodUsuarioPedido(entity.getCodUsuarioPedido());

            // Buscar nome do usuário
            UsuarioEntity usuario = usuarioRepository.findByCod(entity.getCodUsuarioPedido());
            if (usuario != null) {
                pedido.setNomeUsuario(usuario.getNome());
            } else {
                pedido.setNomeUsuario("Usuário não encontrado");
            }

            pedidos.add(pedido);
        }

        return pedidos;


	}
	
	

}
