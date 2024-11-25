package etesp.gov.br.odasu.service.impl;

import etesp.gov.br.odasu.dto.Pedido;
import etesp.gov.br.odasu.dto.Produto;
import etesp.gov.br.odasu.entity.DetalhePedidoEntity;
import etesp.gov.br.odasu.entity.PedidoEntity;
import etesp.gov.br.odasu.entity.ProdutoEntity;
import etesp.gov.br.odasu.entity.UsuarioEntity;
import etesp.gov.br.odasu.repository.DetalhePedidoRepository;
import etesp.gov.br.odasu.repository.PedidoRepository;
import etesp.gov.br.odasu.repository.ProdutoRepository;
import etesp.gov.br.odasu.repository.UsuarioRepository;
import etesp.gov.br.odasu.service.ProdutoService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.Base64;
import java.util.List;
import java.util.NoSuchElementException;
import java.util.Optional;

@Service
public class ProdutoServiceImpl implements ProdutoService {

	@Autowired
	ProdutoRepository produtoRepository;

	@Autowired
	PedidoRepository pedidoRepository;

	@Autowired
	DetalhePedidoRepository detalhePedidoRepository;

	@Autowired
	UsuarioRepository usuarioRepository;

	@Override
	public List<Produto> getProdutos() {
		List<ProdutoEntity> produtosEntity = produtoRepository.findAll();
		List<Produto> produtos = new ArrayList<>();

		for (ProdutoEntity entity : produtosEntity) {
			Produto produto = new Produto();
			produto.setCodProduto(entity.getCodProduto());
			produto.setNomeProduto(entity.getNomeProduto());
			produto.setPrecoProduto(entity.getPreco());
			produto.setDescricaoProduto(entity.getDescricaoProduto());
			produto.setStatusProduto(entity.getStatusProduto());
			produto.setLocalProduto(entity.getLocalProduto());
			produto.setCodCategoriaProduto(entity.getCodCategoriaProduto());

			// Se a associação com UsuarioEntity estiver presente
			if (entity.getCodUsuarioProduto() != null) {
				produto.setCodUsuarioProduto(entity.getCodUsuarioProduto().getCod()); // Pega o ID do usuário
			}

			// Converte a imagem para Base64
			if (entity.getImagem1() != null) {
				String base64Image = Base64.getEncoder().encodeToString(entity.getImagem1());
				produto.setImagem1(base64Image);
			}

			produtos.add(produto);
		}

		return produtos;
	}

	@Override
	public Produto procurarProduto(Long cod) {
		ProdutoEntity produtoEntity = produtoRepository.findByCodProduto(cod);

	    if (produtoEntity != null) {
	        Produto produto = new Produto();
	        produto.setCodProduto(produtoEntity.getCodProduto());
	        produto.setNomeProduto(produtoEntity.getNomeProduto());
	        produto.setPrecoProduto(produtoEntity.getPreco());
	        produto.setDescricaoProduto(produtoEntity.getDescricaoProduto());

	        if (produtoEntity.getCodUsuarioProduto() != null) {
	            produto.setCodUsuarioProduto(produtoEntity.getCodUsuarioProduto().getCod());
	        }

	        if (produtoEntity.getImagem1() != null) {
	            String base64Image = Base64.getEncoder().encodeToString(produtoEntity.getImagem1());
	            produto.setImagem1(base64Image);
	        }
	        
	        if (produtoEntity.getImagem2() != null) {
	            String base64Image = Base64.getEncoder().encodeToString(produtoEntity.getImagem2());
	            produto.setImagem2(base64Image);
	        }
	        
	        if (produtoEntity.getImagem3() != null) {
	            String base64Image = Base64.getEncoder().encodeToString(produtoEntity.getImagem3());
	            produto.setImagem3(base64Image);
	        }
	        
	        if (produtoEntity.getImagem4() != null) {
	            String base64Image = Base64.getEncoder().encodeToString(produtoEntity.getImagem4());
	            produto.setImagem4(base64Image);
	        }

	        return produto;
	    } else {
	        throw new NoSuchElementException("Produto não encontrado com o ID: " + cod);
	    }

	}


	@Override
	public Produto comprarProduto(Pedido pedido) {
		try {
			// Verifica se o produto existe
			ProdutoEntity produto = produtoRepository.findByCodProduto(pedido.getCodProdutoPedido());
			if (produto == null) {
				throw new RuntimeException("Produto não encontrado");
			}

			// Verifica se o usuário existe
			UsuarioEntity usuario = usuarioRepository.findByCod(pedido.getCodUsuarioPedido());
			if (usuario == null) {
				throw new RuntimeException("Usuário não encontrado");
			}

			// Marcar o produto como comprado pelo usuário
			produto.setCodUsuarioProduto(usuario);
			// Atualiza status e salva
			produto.setStatusProduto("INATIVO".toUpperCase());
			produtoRepository.save(produto);

			// Cria um novo pedido e insere na tabela tb_pedido
			PedidoEntity pedidoEntity = new PedidoEntity();
			pedidoEntity.setCodProdutoPedido(produto.getCodProduto());
			pedidoEntity.setCodUsuarioPedido(usuario.getCod());
			// Salva o pedido no repositório
			pedidoRepository.save(pedidoEntity);

			// Cria um novo detalhe de pedido e insere na tabela tb_detalhe_pedido
			DetalhePedidoEntity detalhePedido = new DetalhePedidoEntity();
			detalhePedido.setCodPedidoDetalheped(pedidoEntity.getNumPedido());
			detalhePedido.setCodProdutoDetalheped(produto.getCodProduto());
			detalhePedidoRepository.save(detalhePedido);

			// Converter ProdutoEntity para Produto DTO para retornar
			Produto produtoDTO = new Produto();
			produtoDTO.setCodProduto(produto.getCodProduto());
			produtoDTO.setNomeProduto(produto.getNomeProduto());
			produtoDTO.setPrecoProduto(produto.getPreco());
			produtoDTO.setCodUsuarioProduto(usuario.getCod());

			return produtoDTO;
		} catch (Exception e) {
			// Log de erro pode ser adicionado aqui
			throw new RuntimeException("Erro ao processar a compra: " + e.getMessage());
		}
	}

	@Override
	public Produto editarProduto(Produto produto) {
		// Verifica se o produto existe
        ProdutoEntity produtoEntity = produtoRepository.findByCodProduto(produto.getCodProduto());
        if (produtoEntity == null) {
            throw new RuntimeException("Produto não encontrado");
        }

        // Verifica se o usuário é o proprietário do produto
        if (!produtoEntity.getCodUsuarioProduto().getCod().equals(produto.getCodUsuarioProduto())) {
            throw new RuntimeException("Usuário não autorizado a editar este produto");
        }

        // Atualiza os dados do produto
        produtoEntity.setNomeProduto(produto.getNomeProduto());
        produtoEntity.setDescricaoProduto(produto.getDescricaoProduto());
        produtoEntity.setPreco(produto.getPrecoProduto());
        produtoEntity.setStatusProduto(produto.getStatusProduto());
        produtoEntity.setLocalProduto(produto.getLocalProduto());

        // Atualiza imagens se fornecidas
        if (produto.getImagem1() != null) {
            produtoEntity.setImagem1(Base64.getDecoder().decode(produto.getImagem1()));
        }
        if (produto.getImagem2() != null) {
            produtoEntity.setImagem2(Base64.getDecoder().decode(produto.getImagem2()));
        }
        if (produto.getImagem3() != null) {
            produtoEntity.setImagem3(Base64.getDecoder().decode(produto.getImagem3()));
        }
        if (produto.getImagem4() != null) {
            produtoEntity.setImagem4(Base64.getDecoder().decode(produto.getImagem4()));
        }

        // Salva as alterações no banco de dados
        produtoRepository.save(produtoEntity);

        // Converter ProdutoEntity para Produto DTO para retornar
        Produto produtoDTO = new Produto();
        produtoDTO.setCodProduto(produtoEntity.getCodProduto());
        produtoDTO.setNomeProduto(produtoEntity.getNomeProduto());
        produtoDTO.setDescricaoProduto(produtoEntity.getDescricaoProduto());
        produtoDTO.setPrecoProduto(produtoEntity.getPreco());
        produtoDTO.setStatusProduto(produtoEntity.getStatusProduto());
        produtoDTO.setLocalProduto(produtoEntity.getLocalProduto());
        produtoDTO.setImagem1(produto.getImagem1());
        produtoDTO.setImagem2(produto.getImagem2());
        produtoDTO.setImagem3(produto.getImagem3());
        produtoDTO.setImagem4(produto.getImagem4());

        return produtoDTO;


	}

	@Override
	public List<ProdutoEntity> listarProdutosPorUsuario(Long codUsuario) {
		return produtoRepository.findByCodUsuarioProduto_Cod(codUsuario);
	}

	@Override
	public void deletarProdutoPorCod(Long codProduto) {
	    Optional<ProdutoEntity> produto = produtoRepository.findById(codProduto);
	    if (produto.isPresent()) {
	        produtoRepository.deleteById(codProduto);
	        System.out.println("Produto com código " + codProduto + " foi deletado com sucesso.");
	    } else {
	        throw new RuntimeException("Produto com código " + codProduto + " não encontrado.");
	    }
	}

	

}
