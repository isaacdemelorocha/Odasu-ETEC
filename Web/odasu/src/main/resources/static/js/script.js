document.addEventListener("DOMContentLoaded", function () {
    const produtosContainer = document.getElementById("produtos-container");

    // URL da API
    const apiUrl = 'http://localhost:8080/produtos';

    // Função para buscar produtos
    async function fetchProdutos() {
        try {
            const response = await fetch(apiUrl);
            if (!response.ok) {
                throw new Error('Erro ao buscar produtos');
            }
            const produtos = await response.json();
            renderizarProdutos(produtos);
        } catch (error) {
            console.error(error);
            produtosContainer.innerHTML = '<p>Erro ao carregar produtos.</p>';
        }
    }

    // Função para renderizar produtos no HTML
    function renderizarProdutos(produtos) {
        const nome = localStorage.getItem('nomeUsuario'); // Obtém o nome do usuário do localStorage
        produtos.forEach(produto => {
            const produtoDiv = document.createElement('div');
            produtoDiv.classList.add('produto');
            console.log('String base64 do produto:', produto.imagem1);
            produtoDiv.innerHTML = `
                <a href="detalhes.html?codprod=${produto.codProduto}&nomeprod=${produto.nomeProduto}&precoprod=${produto.precoProduto}&descprod=${produto.descricaoProduto}&catProd=${produto.codCategoriaProduto}&locProd=${produto.localProduto}&statusProd=${produto.statusProduto}"> <!-- Envia o id do produto e nome do usuário pela URL -->
                    <img class="img-fluid" style="mix-blend-mode: darken;" width="70%" height="50%" src="data:image/jpeg;base64,${produto.imagem1}" alt="${produto.nomeProduto}">
                </a>
                <h5>${produto.nomeProduto}</h5>
                <h4>R$ ${produto.precoProduto}</h4>
            `;
            produtosContainer.appendChild(produtoDiv);
        });
    }

    // Função para obter parâmetros da URL
    function getQueryParam(name) {
        const urlParams = new URLSearchParams(window.location.search);
        return urlParams.get(name);
    }

    // Pegando o nome da URL
    const nome = getQueryParam('nome');
    const codUsuario = getQueryParam('cod');
    const email = getQueryParam('email');
    const cpf = getQueryParam('cpf');
    console.log('Código do usuário:', codUsuario, '\nNome do usuário:', nome, '\nE-mail do usuário:', email, '\nCPF do usuário:', cpf);

    // Verifique se a variável nome não está vazia
    if (nome) {
        // Armazena no localStorage
        localStorage.setItem('nomeUsuario', nome);
        localStorage.setItem('codUsuario', codUsuario);
        localStorage.setItem('emailUsuario', email);
        localStorage.setItem('cpfUsuario', cpf);

        // Substitua os elementos <img> e <a> por <p> com o valor da variável
        const entrarContainer = document.querySelector(".entrar");
        entrarContainer.innerHTML = `
        
            <div class="btn-group">
                <button type="button" class="btn btn-success dropdown-toggle" data-bs-toggle="dropdown">${nome}</button>
                <div class="dropdown-menu">
                    
                    <a id="logout-btn" class="dropdown-item text-dark " href="#">Logout</a>
                </div>
            </div>
        
        `;

        //So acessa o carrinho se o usuario estiver logado
        const carrinhoContainer = document.querySelector(".carrinho");
        carrinhoContainer.innerHTML = `
              <img class="carrinhoIco" src="../static/img/carrinho.png" alt="Carrinho">
              <a class="btn btn-success" href="Carrinho.html">Meus Anuncios</a>
          `;


        const LogoContainer = document.querySelector(".logoEmpresa");
        LogoContainer.innerHTML = `
                  <a href="index.html?cod=${codUsuario}&nome=${nome}&email=${email}&cpf=${cpf}"><img class="logo" src="../static/img/logo1.png" alt="Logo da Empresa" /></a>
              `;




    }

    // Função de logoff
    async function logoffUsuario() {
        try {
            const codUsuario = localStorage.getItem('codUsuario');

            // Verifica se o código do usuário existe no localStorage
            if (!codUsuario) {
                console.error('Usuário não encontrado para logoff');
                return;
            }

            // Faz a requisição POST
            const response = await fetch('http://localhost:8080/logoff-usuario', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ cod: codUsuario }) // Envia apenas o código do usuário
            });

            const result = await response.json();

            if (response.ok) {
                //alert('Logoff realizado com sucesso.');
                // Limpa os dados do localStorage e redireciona para a página de login
                localStorage.clear();
                window.location.href = 'login.html'; // Redirecione para a página de login ou inicial
            } else {
                alert('Erro ao realizar logoff: ' + result.message);
            }
        } catch (error) {
            console.error('Erro ao enviar a solicitação de logoff:', error);
            alert('Erro ao realizar logoff.');
        }
    }

    // Adiciona o evento de clique ao botão de logout
    const logoutBtn = document.getElementById('logout-btn');
    if (logoutBtn) {
        logoutBtn.addEventListener('click', function (event) {
            event.preventDefault(); // Evita o redirecionamento padrão do link
            logoffUsuario(); // Chama a função de logoff
        });
    }

    // Chama a função para buscar produtos
    fetchProdutos();


    var cont = 1;
    document.getElementById('radio1').checked = true;

    // Função que troca a imagem a cada 3 segundos
    setInterval(() => {
        proximaImg();
    }, 3000);

    function proximaImg() {
        cont++;


        if (cont > 4) {
            cont = 1;
        }

        // Define o radio button correspondente como checked
        document.getElementById('radio' + cont).checked = true;
    }
});
