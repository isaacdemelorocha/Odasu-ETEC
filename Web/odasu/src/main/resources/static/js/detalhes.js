document.addEventListener("DOMContentLoaded", function () {
    // Função para obter parâmetros da URL
    function getQueryParam(name) {
        const urlParams = new URLSearchParams(window.location.search);
        return urlParams.get(name);
    }

    // Pegando o nome do localStorage
    const nome = localStorage.getItem('nomeUsuario');
    const email = localStorage.getItem('emailUsuario');
    const cpf = localStorage.getItem('cpfUsuario');
    const codUsuario = localStorage.getItem('codUsuario');
    const codProd = getQueryParam('codprod');
    const nomeProd = getQueryParam('nomeprod');
    const precoProd = getQueryParam('precoprod');
    const descProd = getQueryParam('descprod');
    const categoriaProd = getQueryParam('catProd');
    const localProduto = getQueryParam('locProd');
    const statusProduto = getQueryParam('statusProd');


    console.log('Nome do usuário:', nome, '\nCódigo de usuário:', codUsuario, '\nCódigo do Produto:', codProd, '\nNome do Produto:', nomeProd, '\nPreço do Produto:', precoProd);


    if (codProd) {

        // Substitua os elementos <img> e <a> por <h4> com o valor da variável
        if (nome) {
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

            //So acessa o meus anuncios se o usuario estiver logado
            const carrinhoContainer = document.querySelector(".carrinho");
            carrinhoContainer.innerHTML = `
                <img class="carrinhoIco" src="../static/img/carrinho.png" alt="Carrinho">
                <a class="btn btn-success" href="Carrinho.html">Meus Anuncios</a>
            `;

            const LogoContainer = document.querySelector(".logoEmpresa");
            LogoContainer.innerHTML = `
                <a href="index.html?cod=${codUsuario}&nome=${nome}&email=${email}&cpf=${cpf}"><img class="logo" src="../static/img/logo1.png" alt="Logo da Empresa" /></a>
            `;


            // Função para redirecionar para o checkout com parâmetros na URL
            const buyButton = document.querySelector(".contBtnComprar");
            buyButton.addEventListener("click", function (event) {
                // Evitar o comportamento padrão de redirecionamento
                event.preventDefault();

                // Construir a URL com os parâmetros
                let checkoutUrl = "checkout.html?";
                checkoutUrl += `codprod=${encodeURIComponent(codProd)}&codUser=${encodeURIComponent(codUsuario)}&nomeUsuario=${encodeURIComponent(nome)}&emailUsuario=${encodeURIComponent(email)}&cpfUsuario=${encodeURIComponent(cpf)}&descprod=${encodeURIComponent(descProd)}&locprod=${encodeURIComponent(localProduto)}&statusProd=${encodeURIComponent(statusProduto)}&catProd=${encodeURIComponent(categoriaProd)}`;

                // Redirecionar para a URL do checkout com os parâmetros
                window.location.href = checkoutUrl;
            });
        }



        const nomeProdutoContainer = document.querySelector(".nomeProduto");
        nomeProdutoContainer.innerHTML = `<h1>${nomeProd}</h1>`;

        const descricaoProdutoContainer = document.querySelector(".descricaoProduto");
        descricaoProdutoContainer.innerHTML = `<p><strong>Descrição:</strong><br>${descProd}<p>`;

        const precoProdutoContainer = document.querySelector(".price");
        precoProdutoContainer.innerHTML =
            `
        <p>R$ ${precoProd}</p>                
        `;

        const localProdutoContainer = document.querySelector(".local");
        localProdutoContainer.innerHTML = `
            <figure style="width: 15%;" >
                <img class="img-fluid" src="../static/img/local.png">
            </figure>

            <span style="margin-left: 2%;">${localProduto}</span>
        `;

        //se o usuario não estiver logado vai para a tela de login e alimenta a variavel para logar e voltar para checkout
        const btnComprarDetalhesContainer = document.querySelector(".contBtnComprar");
        btnComprarDetalhesContainer.innerHTML = `
        <a href="Login.html?&codprod=${encodeURIComponent(codProd)}&descprod=${encodeURIComponent(descProd)}&locprod=${encodeURIComponent(localProduto)}&statusProd=${encodeURIComponent(statusProduto)}&catProd=${encodeURIComponent(categoriaProd)}"><button class="btn btn-success btnComprar">Comprar</button></a>
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




    async function carregarProduto(produtoId) {
        try {
            const response = await fetch(`http://127.0.0.1:8080/pedidos/produtos/${produtoId}`);
            if (!response.ok) {
                throw new Error(`Erro ao buscar produto: ${response.statusText}`);
            }
            const produto = await response.json();
    
            // Exibindo a imagem e outros detalhes do produto
            const imagemDiv = document.getElementById('prodimg1');
            imagemDiv.innerHTML = `<img src="data:image/png;base64,${produto.imagem1}" alt="${produto.nomeProduto}" />`;

            // Exibindo a imagem e outros detalhes do produto
            const imagemDiv2 = document.getElementById('prodimg2');
            imagemDiv2.innerHTML = `<img class="img-produto-detalhes img-fluid"  style="mix-blend-mode: darken; width: 90px;" src="data:image/png;base64,${produto.imagem2}" alt="${produto.nomeProduto}" />`;

            // Exibindo a imagem e outros detalhes do produto
            const imagemDiv3 = document.getElementById('prodimg3');
            imagemDiv3.innerHTML = `<img class="img-fluid" id="prodimg3" style="mix-blend-mode: darken; width: 90px;" src="data:image/png;base64,${produto.imagem3}" alt="${produto.nomeProduto}" />`;

            // Exibindo a imagem e outros detalhes do produto
            const imagemDiv4 = document.getElementById('prodimg4');
            imagemDiv4.innerHTML = `<img class="img-fluid" id="prodimg3" style="mix-blend-mode: darken; width: 90px;" src="data:image/png;base64,${produto.imagem4}" alt="${produto.nomeProduto}" />`;
    
        } catch (error) {
            console.error('Erro ao carregar o produto:', error);
        }
    }
    
    // Chamar a função com o ID correto
    carregarProduto(codProd); // Substitua 4 pelo ID correto
    
    

});
