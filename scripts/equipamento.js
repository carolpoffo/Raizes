async function contarEquipamentos() {
  const token = localStorage.getItem('token');
  let somaTotal = 0;
  try {
    const response = await fetch('https://localhost:7027/Equipment', {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
        'Authorization': token ? `Bearer ${token}` : ''
      }
    });

    if (!response.ok) {
      throw new Error(`Erro ${response.status}: ${response.statusText}`);
    }

    const dados = await response.json();

    const equipamentos = dados.data || [];
    document.getElementById('totalEquipamento').textContent = equipamentos.length;
    console.log(equipamentos)
    // Calcula a soma total dos preços usando .reduce()
    let somaTotal = equipamentos.reduce((acumulador, equipamento) => {
      // Usa o operador de encadeamento opcional (?.) e o operador de coalescência nula (??)
      // para garantir que 'precoUnitario' seja tratado como 0 se for nulo ou ausente
      const preco = equipamento.precoUnitario ?? 0;
      return acumulador + preco;
    }, 0); // O 0 é o valor inicial do acumulador
    somaTotal = formatarParaBRL(somaTotal)
    document.getElementById('valorEquipamentos').textContent = somaTotal;

  } catch (error) {
    console.error('Erro ao verificar equipamentos:', error);
  }
}
const formatarParaBRL = (valor) => {
  return new Intl.NumberFormat('pt-BR', {
    style: 'currency',
    currency: 'BRL',
  }).format(valor);
};

contarEquipamentos();

async function listarEquipamentos() {
  try {
    const token = localStorage.getItem("token");

    // Busca equipamentos
    const respostaEq = await fetch('https://localhost:7027/Equipment', {
      headers: {
        "Authorization": `Bearer ${token}`,
        "Content-Type": "application/json"
      }
    });
    if (!respostaEq.ok) {
      throw new Error(`Erro equipamentos: ${respostaEq.status}`);
    }
    const equipamentosData = await respostaEq.json();

    // Busca fornecedores
    const respostaForn = await fetch('https://localhost:7027/Supplier', {
      headers: {
        "Authorization": `Bearer ${token}`,
        "Content-Type": "application/json"
      }
    });
    if (!respostaForn.ok) {
      throw new Error(`Erro fornecedores: ${respostaForn.status}`);
    }
    const fornecedoresData = await respostaForn.json();

    const equipamentos = (equipamentosData.data || []);
    const fornecedores = (fornecedoresData.data || []);

    const resultado = equipamentos.map(eq => {
      const fornecedor = fornecedores.find(f => f.id === eq.fornecedorId);

      // Formata data de compra do equipamento
      let dataCompraBR = '';
      if (eq.dataCompra) {
        dataCompraBR = new Date(eq.dataCompra).toLocaleDateString("pt-BR", {
          timeZone: "UTC"
        });
      }

      return {
        ...eq,
        dataCompra: dataCompraBR, // <-- vem do equipamento
        fornecedorNome: fornecedor ? fornecedor.nome : 'Fornecedor não informado',
        fornecedorCnpj: fornecedor ? fornecedor.cnpj : '',
        fornecedorTelefone: fornecedor ? fornecedor.telefone : '',
        fornecedorEmail: fornecedor ? fornecedor.email : ''
      };
    });

    renderizarListaEquipamento(resultado);

  } catch (error) {
    console.error("Erro ao carregar equipamentos:", error);
    const container = document.getElementById("conteudo-lista");
    if (container) {
      container.innerHTML = `<p class="text-red-500">Erro ao carregar equipamentos.</p>`;
    }
  }
}


function renderizarListaEquipamento(itens) {
  const container = document.getElementById("conteudo-lista");
  container.innerHTML = ""; // limpa antes de renderizar

  itens.forEach(item => {
    const card = `
      <div class="bg-gradient-to-br from-white to-blue-50 rounded-2xl p-6 shadow-lg hover:shadow-xl transition-all duration-300 border-l-4 border-green-dark">
        
        <h3 class="font-bold text-gray-800 mb-3 text-lg">${item.nome}</h3>
        <div class="space-y-3 text-sm text-gray-600">
          <div class="flex justify-between items-center">
            <span>Fornecedor:</span>
            <span class="font-semibold text-gray-800">${item.fornecedorNome}</span>
          </div>
          <div class="flex justify-between items-center">
            <span>Valor:</span>
            <span class="font-semibold text-green-600">R$ ${item.precoUnitario}</span>
          </div>
          <div class="flex justify-between items-center">
            <span>Compra:</span>
            <span class="font-semibold text-gray-800">${item.dataCompra}</span>
          </div>
        </div>
        <div class="mt-6 pt-4 border-t border-gray-200">
          <div class="flex gap-3">
          </div>
        </div>
      </div>
    `;
    container.innerHTML += card;
  });
}


function abrirmodalEquipamento() {
    const modal = document.getElementById('modalEquipamento');
    modal.classList.remove('hidden');

    preencherSelect('selectFornecedor', 'https://localhost:7027/Supplier');

}

function fecharmodalEquipamento() {
    document.getElementById('modalEquipamento').classList.add('hidden');
    const mensagemEl = document.getElementById('messageEquipamento');
    mensagemEl.textContent = ''; 
    document.getElementById("nome").value = '';
    document.getElementById("dataCompra").value = '';
    document.getElementById("descricao").value = '';
    document.getElementById("tipo").value = '';
    document.getElementById("precoEquipamento").value = '';
    listarEquipamentos();
}

async function preencherSelect(selectId, apiUrl) {
    const selectElement = document.getElementById(selectId);
    const token = localStorage.getItem('token');

    try {
        const response = await fetch(apiUrl, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': token ? `Bearer ${token}` : ''
            }
        });

        if (!response.ok) {
            throw new Error(`Erro ${response.status}: ${response.statusText}`);
        }

        const data = await response.json();
        const items = data.data || [];
        items.forEach(item => {
            const option = document.createElement('option');
            option.value = item.id;
            option.textContent = item.nome
            selectElement.appendChild(option);
        });



    } catch (error) {
        console.error(`Erro ao carregar o select ${selectId}:`, error);
        selectElement.innerHTML = '<option value="">Erro ao carregar dados</option>';
    }
}

async function salvarEquipamento() {
    const token = localStorage.getItem('token');
    const mensagemEl = document.getElementById("mensagemPlantio");

    try {
    
      const descricao = document.getElementById("descricao").value;
      const dataCompra = document.getElementById("dataCompra").value;
      const nome = document.getElementById("nome").value;
      const fornecedor = document.getElementById("selectFornecedor").value;
      const preco = document.getElementById("precoEquipamento").value;
      const tipo = document.getElementById("tipo").value;


        // Converte date -> datetime ISO
        const compraISO = new Date(dataCompra).toISOString();


        const body = {
            nome: nome,
            tipo: tipo,
            descricao: descricao,
            precoUnitario:preco,
            fornecedorId: Number(fornecedor),
            dataInicio: compraISO
        };

        console.log("Enviando body:", body);

        const response = await fetch("https://localhost:7027/Equipment", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": token ? `Bearer ${token}` : ""
            },
            body: JSON.stringify(body)
        });

        if (!response.ok) {
            const msg = `Erro ${response.status}: ${response.statusText}`;
            return;
        }

        const result = await response.json();
        console.log("Equipamento criado:", result);

        
        fecharmodalEquipamento();

    } catch (error) {
        console.error("Erro ao criar Equipamento:", error);
        alert("Erro ao criar Equipamento");
    }
}