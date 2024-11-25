document.addEventListener("DOMContentLoaded", function(){
    const cadastroForm = document.querySelector("form");
    cadastroForm.addEventListener("submit", function(event){
        event.preventDefault(); // Evita o envio do formulário padrão (que seria uma requisição GET)

        // Captura os dados do formulário
        const nome = document.getElementById("nome").value;
        const sobrenome = document.getElementById("sobrenome").value;
        const cpf = document.getElementById("cpf").value;
        const celular = document.getElementById("celular").value;
        const nascimento = document.getElementById("nascimento").value;
        const email = document.getElementById("email").value;
        const senha = document.getElementById("senha").value;

        const status = "OFFLINE";
        const tipoConta = "CLIENT";

        // Remove a mascara
        const celularComMascara = document.getElementById("celular").value; 
        const celularSemMascara = celularComMascara.replace(/\D/g, "");

        const cpfComMascara = document.getElementById("cpf").value; 
        const cpfSemMascara = cpfComMascara.replace(/\D/g, "");

        // Log dos dados capturados
        console.log({
            nome,
            sobrenome,
            cpfSemMascara,
            nascimento,
            email,
            senha,
            celularSemMascara,
            status,
            tipoConta
        });

        // Faz a requisição POST para o backend
        fetch("http://localhost:8080/cadastrar-usuario", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                nome: nome,
                sobrenome: sobrenome,
                cpf: cpfSemMascara,   
                nascimento: nascimento, // enviada como string no formato "YYYY-MM-DD"
                email: email,
                senha: senha,
                celular: celularSemMascara
            })
        })
        .then(response => {
            console.log('Resposta da requisição:', response);
            if (!response.ok) {
                throw new Error('Falha na requisição');
            }
            return response.json();
        })
        .then(data => {
            console.log('Dados recebidos:', data);
            if (data.success) {
                // Redireciona o usuário para a página principal após o login
                window.location.href = "/src/main/resources/templates/Login.html";  // Ou qualquer página que você desejar
            } else {
                document.getElementById("mensagem").textContent = "Preencha todos os campos corretamente.";
            }
        })
        .catch(error => {
            console.error("Erro na requisição:", error);
            document.getElementById("mensagem").textContent = "Ocorreu um erro ao tentar fazer o cadastro. Tente novamente.";
        });
    });

    document.getElementById('cpf').addEventListener('input', function (e) {
        let value = e.target.value.replace(/\D/g, ''); // Remove caracteres não numéricos
        if (value.length > 3) value = value.replace(/(\d{3})(\d)/, '$1.$2');
        if (value.length > 7) value = value.replace(/(\d{3})\.(\d{3})(\d)/, '$1.$2.$3');
        if (value.length > 11) value = value.replace(/(\d{3})\.(\d{3})\.(\d{3})(\d)/, '$1.$2.$3-$4');
        e.target.value = value.slice(0, 14); // Limita o comprimento
    });

    document.getElementById('celular').addEventListener('input', function (e) {
        let value = e.target.value.replace(/\D/g, ''); // Remove caracteres não numéricos
        
        // Aplica a máscara (XX) XXXXX-XXXX
        if (value.length > 2) value = value.replace(/(\d{2})(\d)/, '($1) $2');
        if (value.length > 7) value = value.replace(/(\d{2})\s(\d)(\d{4})(\d)/, '($1) $2 $3-$4');
        
        e.target.value = value.slice(0, 14); // Limita o comprimento da entrada
    });
});
