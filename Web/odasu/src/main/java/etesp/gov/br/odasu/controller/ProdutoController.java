package etesp.gov.br.odasu.controller;

import etesp.gov.br.odasu.dto.Pedido;
import etesp.gov.br.odasu.dto.Produto;
import etesp.gov.br.odasu.service.ProdutoService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

@RestController
@CrossOrigin("*")
public class ProdutoController {

    @Autowired
    ProdutoService produtoService;

    @GetMapping("/produtos")
    public ResponseEntity<List<Produto>> getProdutos() {
        // Chama o serviço que retorna uma lista de Produto (DTO)
        List<Produto> produtos = produtoService.getProdutos();
        return ResponseEntity.ok(produtos);  // Retorna os produtos no formato correto
    }
    
    @PostMapping("/comprar-produto")
    public ResponseEntity<Map<String, Object>> comprarProduto(@RequestBody Pedido pedido) {
        try {
            Produto produtoComprado = produtoService.comprarProduto(pedido);
            Map<String, Object> response = new HashMap<>();
            response.put("success", true);
            response.put("produto", produtoComprado);
            return ResponseEntity.ok(response);
        } catch (Exception e) {
            Map<String, Object> errorResponse = new HashMap<>();
            errorResponse.put("success", false);
            errorResponse.put("message", e.getMessage());
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body(errorResponse);
        }
    }
    
    
    
    
}
