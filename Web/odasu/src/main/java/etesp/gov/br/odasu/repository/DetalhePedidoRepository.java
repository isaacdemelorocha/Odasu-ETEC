package etesp.gov.br.odasu.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import etesp.gov.br.odasu.entity.DetalhePedidoEntity;

@Repository
public interface DetalhePedidoRepository extends JpaRepository<DetalhePedidoEntity, Long>{

}
