package etesp.gov.br.odasu.service.impl;

import java.util.NoSuchElementException;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import etesp.gov.br.odasu.dto.Usuario;
import etesp.gov.br.odasu.entity.UsuarioEntity;
import etesp.gov.br.odasu.repository.UsuarioRepository;
import etesp.gov.br.odasu.service.UsuarioService;

@Service
public class UsuarioServiceImpl implements UsuarioService {

	@Autowired
	UsuarioRepository repository;

	@Override
	public UsuarioEntity cadastrarUsuario(UsuarioEntity usuario) throws IllegalArgumentException {
	    // Validações básicas
	    if (usuario.getNome() == null || usuario.getNome().isEmpty()) {
	        throw new IllegalArgumentException("O nome do usuário é obrigatório.");
	    }
	    if (usuario.getEmail() == null || usuario.getEmail().isEmpty()) {
	        throw new IllegalArgumentException("O e-mail do usuário é obrigatório.");
	    }
	    if (usuario.getCpf() == null || usuario.getCpf().length() != 11) {
	        throw new IllegalArgumentException("O CPF deve conter 11 dígitos.");
	    }

	    // Define o status padrão
	    usuario.setStatus("OFFLINE");
	    usuario.setTipo("CLIENT"); // Definir tipo padrão, se necessário
	    
	    usuario.setSenha(usuario.getSenha());
	    
	    // Salva o usuário no banco de dados
	    return repository.save(usuario);
	}


	@Override
	public Usuario loginUsuario(Usuario usuario) {

		// Encontra o usuário pelo email
		UsuarioEntity user = repository.findByEmail(usuario.getEmail());

		// Verifica se o usuário existe e se a senha está correta
		if (user != null && usuario.getSenha().equals(user.getSenha())) {

			user.setStatus("ONLINE"); // Atualiza o status
			repository.save(user); // Salva o usuario com novo status

			return new Usuario(user.getCod(), user.getNome(), user.getSobrenome(), user.getCpf(), user.getNasc(),
					user.getEmail(), user.getSenha(), user.getCelular(), user.getStatus(), user.getTipo()); // Login
																											// bem-sucedido
		}

		return null; // Credenciais inválidas
	}

	@Override
	public Usuario logoffUsuario(Usuario usuario) {

		try {
			UsuarioEntity user = repository.findByCod(usuario.getCod());

			if (user != null) {

				user.setStatus("OFFLINE"); // Atualiza o status
				repository.save(user); // Salva o usuario com novo status

				return new Usuario(user.getCod(), user.getNome(), user.getSobrenome(), user.getCpf(), user.getNasc(),
						user.getEmail(), user.getSenha(), user.getCelular(), user.getStatus(), user.getTipo()); // Login
																												// bem-sucedido
			} else {
				throw new RuntimeException("Usuario não encontrado");
			}
		} catch (Exception e) {
			throw new RuntimeException("Erro ao realizar logoff: " + e.getMessage());
		}
	}

	@Override
	public Usuario buscarUsuarioPorCod(Long cod) {
		UsuarioEntity usuarioEntity = repository.findByCod(cod);
		if (usuarioEntity == null) {
			throw new NoSuchElementException("Usuário não encontrado com o ID: " + cod);
		}

		Usuario usuario = new Usuario();
		usuario.setCod(usuarioEntity.getCod());
		usuario.setNome(usuarioEntity.getNome());
		usuario.setSobrenome(usuarioEntity.getSobrenome());
		usuario.setCelular(usuarioEntity.getCelular());
		usuario.setStatus(usuarioEntity.getStatus());

		return usuario;

	}

}
