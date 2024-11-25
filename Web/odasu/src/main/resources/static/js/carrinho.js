document.addEventListener('DOMContentLoaded', function () {
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
    console.log('Nome do usuário:', nome, '\nCódigo de usuário:', codUsuario);

    // Verifique se a variável nome não está vazia
    if (nome) {
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

     

        const LogoContainer = document.querySelector(".logoEmpresa");
        LogoContainer.innerHTML = `
            <a href="index.html?cod=${codUsuario}&nome=${nome}&email=${email}&cpf=${cpf}"><img class="logo" src="../static/img/logo1.png" alt="Logo da Empresa" /></a>
        `;

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

    }

    async function fetchProdutosPorUsuario() {
        try {
            const response = await fetch(`http://localhost:8080/pedidos/meus-anuncios/${codUsuario}`);
            if (response.ok) {
                const produtos = await response.json();
                exibirProdutos(produtos);
            } else {
                document.getElementById('produtos-container').innerHTML = '<div class="container text-center text-danger"><h3>Nenhum produto encontrado.</h3></div>';
            }
        } catch (error) {
            console.error('Erro ao buscar produtos:', error);
            document.getElementById('produtos-container').innerHTML = '<div class="container text-center text-danger"><h3>Nenhum produto encontrado.</h3><p>Utilize o nosso APP Android para anunciar.</p><a href="#"><img width="300px" height="300px" class="img-fluid" src="../static/img/Android.png"></a></div>';
        }
    }
    
    function exibirProdutos(produtos) {
        const container = document.getElementById('produtos-container');
        container.innerHTML = ''; // Limpa qualquer conteúdo existente
    
        produtos.forEach((produto, index) => {
            const produtoElement = document.createElement('div');
            const modalId = `myModal-${index}`; // ID único para cada modal
            const formId = `editarProdutoForm-${index}`; // ID único para cada formulário
    
            produtoElement.innerHTML = `
                <div class="container mb-3 mt-3 p-3">
                    <ul class="w3-ul w3-card-4">
                        <li class="w3-bar">
                            <img src="data:image/jpeg;base64,${produto.imagem1}" class="w3-bar-item w3-circle w3-hide-small img-fluid my-3" style="width:100px; mix-blend-mode: darken;">
                                <div class="w3-bar-item">
                                    <ul class="list-group list-group-horizontal list-group-item-success">
                                        <li style="width:200px;" class="list-group-item"><strong>Título do anúncio:</strong><br>${produto.nomeProduto}</li>
                                        <li style="width:200px;" class="list-group-item"><strong>Descrição:</strong><br> ${produto.descricaoProduto}</li>
                                        <li style="width:200px;" class="list-group-item"><strong>Preço:</strong><br> R$ ${produto.preco.toFixed(2)}</li>
                                        <li style="width:200px;" class="list-group-item"><strong>Status:</strong><br> ${produto.statusProduto}</li>
                                        <li style="width:200px;" class="list-group-item"><strong>Local:</strong><br> ${produto.localProduto}</li>
                                        <li style="width:100px;" ><button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#${modalId}">Editar</button></li>    
                                    </ul>
    
                                    <!-- The Modal -->
                                    <div class="modal fade" id="${modalId}">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <!-- Modal Header -->
                                                <div class="modal-header">
                                                    <h4 class="modal-title">Editar Produto</h4>
                                                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                                                </div>
    
                                                <!-- Modal body -->
                                                <div class="modal-body container">
                                                    <div class="editar-produto-container">
                                                        <form id="${formId}">
                                                            <input type="hidden" id="codProduto-${index}" name="codProduto" value="${produto.codProduto}">
                                                            <div>
                                                                <label class="form-label fw-bold" for="nomeProduto-${index}">Nome do Produto:</label>
                                                                <input class="form-control" type="text" id="nomeProduto-${index}" name="nomeProduto" value="${produto.nomeProduto}" required>
                                                            </div>
                                                            <br>
                                                            <div>
                                                                <label class="form-label fw-bold" for="descricaoProduto-${index}">Descrição do Produto:</label>
                                                                <textarea class="form-control" id="descricaoProduto-${index}" name="descricaoProduto" required>${produto.descricaoProduto}</textarea>
                                                            </div><br>
                                                            <div>
                                                                <label class="form-label fw-bold" for="precoProduto-${index}">Preço do Produto:</label>
                                                                <input class="form-control" type="number" id="precoProduto-${index}" name="precoProduto" value="${produto.preco.toFixed(2)}" required>
                                                            </div><br>
                                                            <div>
                                                                <label class="form-label fw-bold" for="statusProduto-${index}">Status do Produto:</label>
                                                                <select class="form-select"  id="statusProduto-${index}" name="statusProduto">
                                                                    <option value="ATIVO" ${produto.statusProduto === 'ATIVO' ? 'selected' : ''}>Ativo</option>
                                                                    <option value="INATIVO" ${produto.statusProduto === 'INATIVO' ? 'selected' : ''}>Inativo</option>
                                                                </select>
                                                            </div><br>
                                                            <div>
                                                                <label class="form-label fw-bold" for="localProduto-${index}">Local do Produto:</label>
                                                                 <select class="form-select" id="localProduto-${index}" name="localProduto">
                                                                    <option value="ZONA NORTE" ${produto.localProduto === 'ZONA NORTE' ? 'selected' : ''}>Zona Norte</option>
                                                                    <option value="ZONA SUL" ${produto.localProduto === 'ZONA SUL' ? 'selected' : ''}>Zona Sul</option>
                                                                    <option value="ZONA OESTE" ${produto.localProduto === 'ZONA OESTE' ? 'selected' : ''}>Zona Oeste</option>
                                                                    <option value="ZONA LESTE" ${produto.localProduto === 'ZONA LESTE' ? 'selected' : ''}>Zona Leste</option>
                                                                </select>
                                                            </div><br>
                                                            <div>
                                                                <label class="form-label fw-bold" for="imagem1-${index}">Imagem 1:</label>
                                                                <input class="form-control" type="file" id="imagem1-${index}" name="imagem1">

                                                                <label class="form-label fw-bold" for="imagem1-${index}">Imagem 2:</label>
                                                                <input class="form-control" type="file" id="imagem2-${index}" name="imagem2">
                                                            
                                                                <label class="form-label fw-bold" for="imagem1-${index}">Imagem 3:</label>
                                                                <input class="form-control" type="file" id="imagem3-${index}" name="imagem3">

                                                                <label class="form-label fw-bold" for="imagem1-${index}">Imagem 4:</label>
                                                                <input class="form-control" type="file" id="imagem4-${index}" name="imagem4">
                                                            </div><br>
                                                            <!-- Adicione campos para Imagem2, Imagem3, Imagem4 se necessário -->
                                                            <button class="btn btn-success" type="submit">Salvar Alterações</button>
                                                        </form>
                                                    </div>
                                                </div>
    
                                                <!-- Modal footer -->
                                                <div class="modal-footer">
                                                    
                                                    <button type="button" class="btn btn-warning" data-bs-dismiss="modal">Close</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                        </li>            
                    </ul>
                </div>
            `;
            container.appendChild(produtoElement);
    
            // Adiciona o event listener para cada formulário de edição
            const editarProdutoForm = document.getElementById(formId);
            editarProdutoForm.addEventListener('submit', async function (event) {
                event.preventDefault();
    
                const formData = new FormData(editarProdutoForm);
                const produto = {
                    codProduto: formData.get('codProduto'),
                    codUsuarioProduto: localStorage.getItem('codUsuario'), // Assume que o usuário está logado e o ID está armazenado no localStorage
                    nomeProduto: formData.get('nomeProduto'),
                    descricaoProduto: formData.get('descricaoProduto'),
                    precoProduto: formData.get('precoProduto'),
                    statusProduto: formData.get('statusProduto'),
                    localProduto: formData.get('localProduto'),
                    imagem1: formData.get('imagem1').size > 0 ? await toBase64(formData.get('imagem1')) : null,
                    imagem2: formData.get('imagem2').size > 0 ? await toBase64(formData.get('imagem2')) : null,
                    imagem3: formData.get('imagem3').size > 0 ? await toBase64(formData.get('imagem3')) : null,
                    imagem4: formData.get('imagem4').size > 0 ? await toBase64(formData.get('imagem4')) : null,
                    // Adicione a lógica para Imagem2, Imagem3, Imagem4 se necessário
                };
    
                fetch('http://localhost:8080/pedidos/editar/produto', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(produto)
                })
                .then(response => response.json())
                .then(data => {
                    console.log('Produto editado com sucesso:', data);
                    // Redirecionar ou atualizar a página conforme necessário
                    location.reload();
                })
                .catch(error => {
                    console.error('Erro ao editar produto:', error); Swal.fire({ title: 'Erro!', text: 'Erro ao editar produto.', icon: 'error', confirmButtonText: 'OK' });
                });
            });
        });
    }

    function toBase64(file) {
        return new Promise((resolve, reject) => {
            const reader = new FileReader();
            reader.readAsDataURL(file);
            reader.onload = () => resolve(reader.result.split(',')[1]); // Remove o prefixo "data:image/jpeg;base64,"
            reader.onerror = error => reject(error);
        });
    }
    
    
    // Chama a função ao carregar a página
    fetchProdutosPorUsuario();
    



   /* const pedidosContainer = document.querySelector('.lista-pedidos-container');

    function carregarPedidos() {
        fetch(`http://localhost:8080/pedidos/usuario/${codUsuario}`)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Erro ao carregar pedidos');
                }
                return response.json();
            })
            .then(pedidos => {
                pedidosContainer.innerHTML = '';

                pedidos.forEach(pedido => {
                    const pedidoDiv = document.createElement('div');
                    pedidoDiv.innerHTML = `
                    <div class="container mt-3">
                        <table class="table table-hover table-striped table-success text-center">
                            <thead class="table-dark">
                                <tr>
                                    <th>Número do Pedido</th>
                                    <th>Código do Produto</th>
                                    <th>Titulo do Produto</th>
                                    <th>Nome do Vendedor</th>
                                    <th>Status do Vendedor</th>
                                    <th>Data da compra</th>
                                    <th>Data de entrega</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>${pedido.numPedido}</td>
                                    <td>${pedido.codProdutoPedido}</td>
                                    <td></td>
                                    <td>${pedido.nomeUsuario}</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                            </tbody> 
                        </table>
                    </div>                 
                    `;
                    pedidosContainer.appendChild(pedidoDiv);
                });
            })
            .catch(error => {
                console.error('Erro ao carregar pedidos:', error);
                pedidosContainer.innerHTML = '<p>Erro ao carregar pedidos.</p>';
            });
    }


    carregarPedidos();*/


    

});
