package etesp.gov.br.odasu.service;

import etesp.gov.br.odasu.dto.Pedido;
import etesp.gov.br.odasu.dto.Produto;
import etesp.gov.br.odasu.entity.ProdutoEntity;

import java.util.List;

public interface ProdutoService {
    List<Produto> getProdutos();
    
    public Produto procurarProduto(Long cod);
    
    public Produto comprarProduto(Pedido pedido);
    
    public Produto editarProduto(Produto produto);
    
    public List<ProdutoEntity> listarProdutosPorUsuario(Long codUsuario);
    
    public void deletarProdutoPorCod(Long cod);
    
}

