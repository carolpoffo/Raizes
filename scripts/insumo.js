async function contarInsumos() {
  const token = localStorage.getItem('token');

  try {
    const response = await fetch('https://localhost:7027/RawMaterialStock', {
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

    const insumos = dados.data || [];
    document.getElementById('insumos').textContent = insumos.length;

    let somaTotal = insumos.reduce((acumulador, insumos) => {

      const preco = insumos.precoTotal ?? 0;
      return acumulador + preco;
    }, 0);
    somaTotal = formatarParaBRL(somaTotal)
    document.getElementById('valorEstoque').textContent = somaTotal;

  } catch (error) {
    console.error('Erro ao verificar insumos no estoque:', error);
  }
}

async function listarInsumos() {
  try {
    const token = localStorage.getItem("token");

    // Estoque
    const respostaStock = await fetch('https://localhost:7027/RawMaterialStock', {
      headers: {
        "Authorization": `Bearer ${token}`,
        "Content-Type": "application/json"
      }
    });

    if (!respostaStock.ok) {
      throw new Error(`Erro estoque: ${respostaStock.status}`);
    }
    const estoqueData = await respostaStock.json();

    // Insumos
    const respostaInsumo = await fetch('https://localhost:7027/RawMaterial', {
      headers: {
        "Authorization": `Bearer ${token}`,
        "Content-Type": "application/json"
      }
    });

    if (!respostaInsumo.ok) {
      throw new Error(`Erro insumo: ${respostaInsumo.status}`);
    }
    const insumosData = await respostaInsumo.json();

    // Join estoque + insumo
    const estoque = estoqueData.data || [];
    const insumos = insumosData.data || [];

    const resultado = estoque.map(p => {
      const insumo = insumos.find(e => Number(e.id) === Number(p.insumoId));
      let validadeBR = '';
      if (insumo && insumo.dataDeValidade) {
        validadeBR = new Date(insumo.dataDeValidade).toLocaleDateString("pt-BR", {
          timeZone: "UTC"
        });
      }

      return {
        ...p,
        insumoNome: insumo ? insumo.nome : 'Insumo não encontrado',
        validade: validadeBR,
      };
});

    renderizarLista(resultado);

  } catch (error) {
    console.error("Erro ao carregar insumos:", error);
    const container = document.getElementById("conteudo-lista");
    if (container) {
      container.innerHTML = `<p class="text-red-500">Erro ao carregar insumos.</p>`;
    }
  }
}


function renderizarLista(itens) {
  const container = document.getElementById("conteudo-lista");
  container.innerHTML = ""; // limpa antes de renderizar

  itens.forEach(item => {
    const card = `
      <div class="bg-gradient-to-br from-white to-blue-50 rounded-2xl p-6 shadow-lg hover:shadow-xl transition-all duration-300 border-l-4 border-green-dark">
        <h3 class="font-bold text-gray-800 mb-3 text-lg">${item.insumoNome}</h3>
        <div class="space-y-3 text-sm text-gray-600">
          <div class="flex justify-between items-center">
            <span>Quantidade:</span>
            <span class="font-semibold text-gray-800">${item.quantidade}</span>
          </div>
          <div class="flex justify-between items-center">
            <span>Valor:</span>
            <span class="font-semibold text-green-600">R$ ${item.precoTotal}</span>
          </div>
          <div class="flex justify-between items-center">
            <span>Data Validade:</span>
            <span class="font-semibold text-gray-800">${item.validade}</span>
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
contarInsumos();


function abrirmodalInsumo() {
  const modal = document.getElementById('modalInsumo');
  modal.classList.remove('hidden');

  preencherSelect('selectPropriedade', 'https://localhost:7027/Property');
  preencherSelect('selectInsumo', 'https://localhost:7027/RawMaterial');

}

function fecharmodalInsumo() {
  document.getElementById('modalInsumo').classList.add('hidden');
  document.getElementById("quantidade").value = '';
  document.getElementById("precoUNInsumo").value = '';
  listarInsumos();
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

    console.log("Itens recebidos:", data);

  } catch (error) {
    console.error(`Erro ao carregar o select ${selectId}:`, error);
    selectElement.innerHTML = '<option value="">Erro ao carregar dados</option>';
  }
}

async function salvarInsumo() {
  const token = localStorage.getItem('token');

  try {

    const propriedade = document.getElementById("selectPropriedade").value;
    const insumoId = document.getElementById("selectInsumo").value;
    const quantidade = parseFloat(document.getElementById("quantidade").value)||0;
    const precounitario = parseFloat(document.getElementById("precoUNInsumo").value.replace(",","."));

    // calcula automaticamente o total
    const precoTotal = Number(quantidade) * Number(precounitario);

    // data formatada para SQL
    const datamov = new Date().toISOString();
    

    const body = {
      propriedadeId: Number(propriedade),
      insumoId: Number(insumoId),
      quantidade: Number(quantidade),
      precoUnitario: Number(precounitario),
      precoTotal: precoTotal,
      dataMovimentacao: datamov
    };

    console.log("Enviando body:", body);

    const response = await fetch("https://localhost:7027/RawMaterialStock", {
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
    console.log("Insumo criado:", result);


    fecharmodalInsumo();

  } catch (error) {
    console.error("Erro ao criar Insumo:", error);
    alert("Erro ao criar Insumo");
  }
}