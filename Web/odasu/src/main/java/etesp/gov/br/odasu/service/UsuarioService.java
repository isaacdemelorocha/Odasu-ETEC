package etesp.gov.br.odasu.service;

import etesp.gov.br.odasu.dto.Usuario;
import etesp.gov.br.odasu.entity.UsuarioEntity;

public interface UsuarioService {
	
	public UsuarioEntity cadastrarUsuario(UsuarioEntity usuario) throws IllegalArgumentException;;
	
	public Usuario loginUsuario(Usuario email);
	
	public Usuario logoffUsuario(Usuario usuario);
	
	public Usuario buscarUsuarioPorCod(Long cod);
	
	
}
