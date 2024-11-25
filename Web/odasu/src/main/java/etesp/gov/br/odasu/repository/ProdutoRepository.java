package etesp.gov.br.odasu.repository;

import etesp.gov.br.odasu.entity.ProdutoEntity;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ProdutoRepository extends JpaRepository<ProdutoEntity, Long> {
	ProdutoEntity findByCodProduto(Long codProduto);
	 List<ProdutoEntity> findByCodUsuarioProduto_Cod(Long codUsuario);
}
