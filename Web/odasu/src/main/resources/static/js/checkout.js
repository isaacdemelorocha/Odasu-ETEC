document.addEventListener("DOMContentLoaded", function () {
    // Função para atualizar o tempo de entrega conforme a seleção
    function updateDeliveryTime() {
        const deliverySelect = document.getElementById('delivery-time');
        const selectedOption = deliverySelect.options[deliverySelect.selectedIndex].text;
        const totalSpan = document.getElementById('total');

        let extraCost = 0;

        if (selectedOption.includes("SEDEX")) {
            extraCost = 10.00;
        } else if (selectedOption.includes("Motoboy")) {
            extraCost = 20.00;
        } else if (selectedOption.includes("Retirar")) {
            extraCost = 0;
        } else if (selectedOption.includes("JD Express")) {
            extraCost = 30;
        }

        // Atualiza o preço total baseado no tempo de entrega
        const subtotal = parseFloat(document.getElementById('subtotal').innerText); // Obtem o subtotal atual
        const total = (subtotal + extraCost).toFixed(2); // Calcula o total

        if (extraCost != 0) {
            totalSpan.innerHTML = total + "<br>Custo de Frete: R$" + extraCost + "<br>Subtotal: R$ " + subtotal.toFixed(2); // Exibe o total com frete
        } else {
            totalSpan.innerText = total; // Exibe o total sem frete
        }
    }

    // Função para mostrar/ocultar detalhes do pagamento (Cartão de Crédito)
    function togglePaymentDetails() {
        const paymentMethod = document.getElementById('payment-method').value;
        const cardDetails = document.getElementById('card-details');
        const pixQRCode = document.getElementById('pix-qrcode');

        // Mostra/oculta os campos de cartão e o QR Code do Pix
        if (paymentMethod === 'cartao') {
            cardDetails.style.display = 'block';
            pixQRCode.style.display = 'none';
        } else if (paymentMethod === 'pix') {
            cardDetails.style.display = 'none';
            pixQRCode.style.display = 'block';
        } else {
            cardDetails.style.display = 'none';
            pixQRCode.style.display = 'none';
        }
    }

    // Chama a função para exibir corretamente os elementos ao carregar a página
    togglePaymentDetails();  // Chama a função assim que a página carrega

    // Adiciona um ouvinte de evento para o select de tempo de entrega
    const deliverySelect = document.getElementById('delivery-time');
    deliverySelect.addEventListener('change', updateDeliveryTime);  // Chama a função de atualização do preço quando mudar a entrega

    // Função de validação básica ao submeter o formulário
    document.getElementById('checkout-form').onsubmit = function (event) {
        // Validação do campo de endereço
        const address = document.getElementById('address').value.trim();
        if (!address) {
            alert("Por favor, informe o endereço de entrega.");
            event.preventDefault();
            return;
        }

        // Validação do campo de pagamento
        const paymentMethod = document.getElementById('payment-method').value;
        if (paymentMethod === 'cartao') {
            const cardNumber = document.getElementById('card-number').value.trim();
            const cardExpiry = document.getElementById('card-expiry').value.trim();
            if (!cardNumber || !cardExpiry) {
                alert("Por favor, preencha os detalhes do cartão de crédito.");
                event.preventDefault();
                return;
            }
        }
    }

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
    const descProd = getQueryParam('descprod');
    const categoriaProd = getQueryParam('catProd');
    const localProduto = getQueryParam('locprod');
    const statusProduto = getQueryParam('statusProd');
    console.log('Nome do usuário:', nome, '\nCódigo de usuário:', codUsuario, '\nCódigo do Produto:', codProd, "\nDescrição do Produto:", descProd, "\nCategoria do Produto:", categoriaProd, "\nStatus do Produto:", statusProduto, "\nLocal do Produto:", localProduto);

    
    if (nome) {

      

        //So acessa o meus anuncios se o usuario estiver logado
        const contFazerPedidoContainer = document.querySelector(".contFazerPedido");
        contFazerPedidoContainer.innerHTML = `
            <a href="agradecimento.html"><button type="submit" class="btnFinalizarCompra btn btn-success">FAZER PEDIDO</button></a>
        `;


        // Substitua os elementos <img> e <a> por <h4> com o valor da variável
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

        const entrarContainerNome = document.querySelector(".nome");
        entrarContainerNome.innerHTML = `<strong>Nome do Pagador: </strong><span>${nome}</span>`;
        //-------------------------------------------------------------------------------------------------
        //CPF
        // Função para aplicar a máscara
        function aplicarMascaraCPF(cpf) {
            // Remove qualquer caractere que não seja número
            cpf = cpf.replace(/\D/g, '');

            // Aplica a máscara ###.###.###-##
            return cpf.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, '$1.$2.$3-$4');
        }

        // Obtendo o elemento onde o CPF será exibido
        const entrarContainerCpf = document.querySelector(".cpf");

        // Aplicando a máscara e inserindo no HTML
        entrarContainerCpf.innerHTML = `<strong>CPF: </strong><span>${aplicarMascaraCPF(cpf)}</span>`;
        //FIM CPF
        //-------------------------------------------------------------------------------------------------
        //EMAIL
        //Decodificando email para que % se torne @
        const emailDecodificado = decodeURIComponent(email);
        const entrarContainerEmail = document.querySelector(".email");
        entrarContainerEmail.innerHTML = `<strong>E-mail: </strong><span>${emailDecodificado}</span>`;
        //FIM EMAIL
        //-------------------------------------------------------------------------------------------------

    }

    const checkoutForm = document.querySelector("#checkout-form");
    checkoutForm.addEventListener("submit", async function (event) {
        event.preventDefault(); // Evita o envio do formulário

        // Capturando dados para a tabela tb_pedido
        const codProdPed = codProd;
        const codUsuarioPed = codUsuario;

        // Faz a requisição POST para o backend
        fetch("http://localhost:8080/comprar-produto", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                codProdutoPedido: codProdPed,
                codUsuarioPedido: codUsuarioPed
            })
        })
            .then(response => response.json().catch(() => {
                throw new Error("Resposta não é um JSON válido");
            }))
            .then(data => {
                console.log("Resposta do servidor:", data);
                if (data.success) {
                    console.log("Redirecionando para a página de agradecimento...");
                    window.location.href = `agradecimento.html?codProd=${codProdPed}&cod=${codUsuarioPed}&nome=${nome}&email=${email}&cpf=${cpf}`;
                } else {
                    const mensagemElement = document.getElementById("mensagem");
                    if (mensagemElement) {
                        mensagemElement.textContent = data.message || "Erro: resposta inesperada.";
                    }
                }
            })
            .catch(error => {
                console.error("Erro na requisição:", error);
                const mensagemElement = document.getElementById("mensagem");
                if (mensagemElement) {
                    mensagemElement.textContent = "Ocorreu um erro ao tentar processar a compra.";
                } else {
                    console.error("Elemento 'mensagem' não encontrado no DOM.");
                }
            });
    });



    // Função de logoff
    async function logoffUsuario() {
        try {

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

    // Adiciona o ouvinte de evento para o select de pagamento
    const paymentSelect = document.getElementById('payment-method');
    paymentSelect.addEventListener('change', togglePaymentDetails);  // Isso irá chamar a função quando o usuário mudar o método de pagamento


});
