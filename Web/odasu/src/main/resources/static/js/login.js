document.addEventListener("DOMContentLoaded", function() {

    
    function getQueryParam(name) {
        const urlParams = new URLSearchParams(window.location.search);
        return urlParams.get(name);
    }

    const codProd = getQueryParam('codprod');
    const descProd = getQueryParam('descprod');
    const locProd = getQueryParam('locprod');
    const statusProd = getQueryParam('statusProd');
    const catProd = getQueryParam('catProd');

    const loginForm = document.querySelector("form");
    loginForm.addEventListener("submit", function(event) {
        event.preventDefault();  // Evita o envio do formulário tradicional


        // Captura os dados do formulário
        const email = document.getElementById("username").value;
        const senha = document.getElementById("password").value;

        // Faz a requisição POST para o backend
        fetch("http://localhost:8080/login-usuario", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                email: email,
                senha: senha
            })
        })
        .then(response => {
            if (!response.ok) {
                throw new Error("Erro HTTP: " + response.status);
            }
            return response.json();
        })
        .then(data => {
            if (data.success) {
                // Codifica o nome e redireciona para a página index.html
                const encodedNome = encodeURIComponent(data.nome);
                const encodedCodUsuario = encodeURIComponent(data.codUsuario);
                const encodedEmail = encodeURIComponent(data.email);
                const encodedCpf = encodeURIComponent(data.cpf);
                
                
                if(codProd != null)
                {
                   localStorage.setItem('codUsuario', encodedCodUsuario);
                   localStorage.setItem('nomeUsuario', encodedNome);
                   localStorage.setItem('emailUsuario', encodedEmail);
                   localStorage.setItem('cpfUsuario', encodedCpf);

                   window.location.href = `/src/main/resources/templates/checkout.html?codUsuario=${encodedCodUsuario}&nomeUsuario=${encodedNome}&emailUsuario=${encodedEmail}&cpfUsuario=${encodedCpf}&codprod=${encodeURIComponent(codProd)}&descprod=${encodeURIComponent(descProd)}&locprod=${encodeURIComponent(locProd)}&statusProd=${encodeURIComponent(statusProd)}&catProd=${encodeURIComponent(catProd)}`;
                }else{     
                    window.location.href = `/src/main/resources/templates/index.html?cod=${encodedCodUsuario}&nome=${encodedNome}&email=${encodedEmail}&cpf=${encodedCpf}`;
                }

            } else {
                document.getElementById("mensagem").textContent = "Credenciais inválidas. Tente novamente.";
            }
        })
        .catch(error => {
            console.error("Erro na requisição:", error);
            document.getElementById("mensagem").textContent = "Ocorreu um erro ao tentar fazer login. Tente novamente.";
        });        
    });
});
