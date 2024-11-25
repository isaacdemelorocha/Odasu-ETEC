package etesp.gov.br.odasu.controller;

import java.util.HashMap;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import etesp.gov.br.odasu.dto.Usuario;
import etesp.gov.br.odasu.entity.UsuarioEntity;
import etesp.gov.br.odasu.service.UsuarioService;

@RestController
@CrossOrigin("*")
public class UsuarioController {

	@Autowired
	UsuarioService serviceUsuario;

	@PostMapping("/cadastrar-usuario")
	public ResponseEntity<?> cadastrarUsuario(@RequestBody UsuarioEntity usuario) {
		try {
			UsuarioEntity novoUsuario = serviceUsuario.cadastrarUsuario(usuario);
			return ResponseEntity.status(HttpStatus.CREATED).body(novoUsuario);
		} catch (IllegalArgumentException e) {
			return ResponseEntity.badRequest().body(e.getMessage());
		}
	}

	@PostMapping("/login-usuario")
	public ResponseEntity<?> loginUsuario(@RequestBody Usuario usuario) {
		Usuario usuarioLogado = serviceUsuario.loginUsuario(usuario);

		Map<String, Object> response = new HashMap<>();
		if (usuarioLogado != null) {
			response.put("success", true);
			response.put("nome", usuarioLogado.getNome());
			response.put("codUsuario", usuarioLogado.getCod());
			response.put("email", usuarioLogado.getEmail());
			response.put("cpf", usuarioLogado.getCpf());
		} else {
			response.put("success", false);
		}
		return ResponseEntity.ok(response);
	}

	@PostMapping("/logoff-usuario")
	public ResponseEntity<?> logoffUsuario(@RequestBody Usuario usuario) {
		try {
			Usuario usuarioDesonline = serviceUsuario.logoffUsuario(usuario);

			Map<String, Object> response = new HashMap<>();
			response.put("success", true);
			response.put("user", usuarioDesonline);
			return ResponseEntity.ok(response);

		} catch (RuntimeException e) {
			Map<String, Object> response = new HashMap<>();
			response.put("success", true);
			response.put("message", e.getMessage());
			return ResponseEntity.status(HttpStatus.UNAUTHORIZED).body(response);
		}
	}

}
