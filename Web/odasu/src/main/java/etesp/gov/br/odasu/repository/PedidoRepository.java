package etesp.gov.br.odasu.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import etesp.gov.br.odasu.entity.PedidoEntity;

@Repository
public interface PedidoRepository extends JpaRepository<PedidoEntity, Long> {
	List<PedidoEntity> findByCodUsuarioPedido(Long cod);
}
