package etesp.gov.br.odasu.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import etesp.gov.br.odasu.dto.Pedido;
import etesp.gov.br.odasu.dto.Produto;
import etesp.gov.br.odasu.entity.ProdutoEntity;
import etesp.gov.br.odasu.service.PedidoService;
import etesp.gov.br.odasu.service.ProdutoService;

@RestController
@CrossOrigin("*")
@RequestMapping("/pedidos")
public class PedidoController {

	@Autowired
	private PedidoService pedidoService;

	@Autowired
	private ProdutoService produtoService;

	@DeleteMapping("/deletar/{cod}")
	public ResponseEntity<String> deletarProduto(@PathVariable Long id) {
		try {
			produtoService.deletarProdutoPorCod(id);
			return ResponseEntity.ok("Produto deletado com sucesso.");
		} catch (RuntimeException e) {
			return ResponseEntity.status(HttpStatus.NOT_FOUND).body(e.getMessage());
		}
	}

	@GetMapping("/produtos/{cod}")
	public ResponseEntity<Produto> getProdutoById(@PathVariable Long cod) {
		Produto produto = produtoService.procurarProduto(cod);
		return ResponseEntity.ok(produto);
	}

	@GetMapping("/usuario/{codUsuario}")
	public ResponseEntity<List<Pedido>> listarPedidosPorUsuario(@PathVariable Long codUsuario) {
		List<Pedido> pedidos = pedidoService.listarPedidosPorUsario(codUsuario);
		return ResponseEntity.ok(pedidos);
	}

	@PostMapping("/editar/produto")
	public ResponseEntity<Produto> editarProduto(@RequestBody Produto produto) {
		Produto produtoEditado = produtoService.editarProduto(produto);
		return ResponseEntity.ok(produtoEditado);
	}

	@GetMapping("/meus-anuncios/{codUsuario}")
	public ResponseEntity<List<ProdutoEntity>> getProdutosPorUsuario(@PathVariable Long codUsuario) {
		List<ProdutoEntity> produtos = produtoService.listarProdutosPorUsuario(codUsuario);
		if (produtos.isEmpty()) {
			return ResponseEntity.noContent().build();
		}
		return ResponseEntity.ok(produtos);
	}

}
