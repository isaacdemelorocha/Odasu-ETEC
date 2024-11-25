package etesp.gov.br.odasu.repository;


import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import etesp.gov.br.odasu.entity.UsuarioEntity;

@Repository
public interface UsuarioRepository extends JpaRepository<UsuarioEntity, Long> {
	
    UsuarioEntity findByCod(Long cod);
    UsuarioEntity findByEmail(String email);
    UsuarioEntity findByCpf(String cpf);
    UsuarioEntity findByCelular(String celular);

}
