

async function listarVendas() {
    try {
        const token = localStorage.getItem("token");

        // Vendas
        const respostaVenda = await fetch('https://localhost:7027/Sale', {
            headers: {
                "Authorization": `Bearer ${token}`,
                "Content-Type": "application/json"
            }
        });
        if (!respostaVenda.ok) {
            throw new Error(`Erro vendas: ${respostaVenda.status}`);
        }
        const vendaData = await respostaVenda.json();
        const vendas = vendaData.data || [];

        // Unidades de Medida
        const respostaUnidadeMed = await fetch('https://localhost:7027/MeasureUnit', {
            headers: {
                "Authorization": `Bearer ${token}`,
                "Content-Type": "application/json"
            }
        });
        if (!respostaUnidadeMed.ok) {
            throw new Error(`Erro unidade Medida: ${respostaUnidadeMed.status}`);
        }
        const unidadeData = await respostaUnidadeMed.json();
        const unidades = unidadeData.data || [];

        // Plantios
        const respostaPlantio = await fetch('https://localhost:7027/Planting', {
            headers: {
                "Authorization": `Bearer ${token}`,
                "Content-Type": "application/json"
            }
        });
        if (!respostaPlantio.ok) {
            throw new Error(`Erro Plantio: ${respostaPlantio.status}`);
        }
        const plantioData = await respostaPlantio.json();
        const plantios = plantioData.data || [];

        // Colheitas
        const respostaColheita = await fetch('https://localhost:7027/Harvest', {
            headers: {
                "Authorization": `Bearer ${token}`,
                "Content-Type": "application/json"
            }
        });
        if (!respostaColheita.ok) {
            throw new Error(`Erro Colheita: ${respostaColheita.status}`);
        }
        const colheitaData = await respostaColheita.json();
        const colheitas = colheitaData.data || [];

        // Espécies
        const respostaEspecie = await fetch('https://localhost:7027/Species', {
            headers: {
                "Authorization": `Bearer ${token}`,
                "Content-Type": "application/json"
            }
        });
        if (!respostaEspecie.ok) {
            throw new Error(`Erro Espécie: ${respostaEspecie.status}`);
        }
        const especieData = await respostaEspecie.json();
        const especies = especieData.data || [];

        // 🔗 Fazendo os joins
        const resultado = vendas.map(venda => {
            const colheita = colheitas.find(c => c.id === venda.colheitaId);
            const plantio = colheita ? plantios.find(p => p.id === colheita.plantioId) : null;
            const especie = plantio ? especies.find(e => e.id === plantio.especieId) : null;

            const unidadeVenda = unidades.find(u => u.id === venda.unidadeMedidaId);
            const unidadeColheita = colheita ? unidades.find(u => u.id === colheita.unidadeMedidaId) : null;
            const unidadePlantio = plantio ? unidades.find(u => u.id === plantio.unidadeMedidaId) : null;

            return {
                ...venda,
                comprador: venda.comprador,
                precoUnitario: venda.precoUnitario,
                precoTotal: venda.precoTotal,
                quantidade: venda.quantidade,
                dataVenda: new Date(venda.dataVenda).toLocaleDateString("pt-BR"),

                // associações
                colheitaData: colheita ? new Date(colheita.dataColheita).toLocaleDateString("pt-BR") : "-",
                plantioId: plantio ? plantio.id : null,

                // nomes das unidades de medida
                unidadeVendaNome: unidadeVenda ? unidadeVenda.sigla : "-",
                unidadeColheitaNome: unidadeColheita ? unidadeColheita.sigla : "-",
                unidadePlantioNome: unidadePlantio ? unidadePlantio.sigla : "-",

                // dados da espécie
                especieNome: especie ? especie.nomeComum : "-",
                especieCientifico: especie ? especie.nomeCientifico : "",
                especieVariedade: especie ? especie.variedade : ""
            };
        });

        console.log("Resultado vendas:", resultado);

        const resultadoInvertido = resultado.reverse();

        renderizarListaVendas(resultadoInvertido);

    } catch (error) {
        console.error("Erro ao carregar vendas:", error);
        const container = document.getElementById("conteudo-lista");
        if (container) {
            container.innerHTML = `<p class="text-red-500">Erro ao carregar vendas.</p>`;
        }
    }
}
function renderizarListaVendas(itens) {
    const container = document.getElementById("vendas");
    container.innerHTML = ""; // limpa antes de renderizar

    itens.forEach(item => {
        const card = `
      <tr class="table-row">
                    <td class="py-4 px-6 text-center">
                      <span
                        class="bg-gradient-to-r from-green-100 to-green-200  text-green-700 px-3 py-1.5 rounded-full text-sm font-medium">
                        ${item.especieNome}
                      </span>
                    </td>
                    <td class="py-4 px-6 text-center text-gray-600">${item.quantidade}</td>
                    <td class="py-4 px-6 text-center text-gray-600">${item.unidadeVendaNome}</td>
                    <td class="py-4 px-6 text-center text-green-600 font-bold">+ R$ ${item.precoTotal}</td>
                    <td class="py-4 px-6 text-center text-gray-600">${item.comprador}</td>
                    <td class="py-4 px-6 text-center text-gray-600">${item.dataVenda}</td>
                  </tr>
    `;
        container.innerHTML += card;
    });
}


function abrirModalVenda() {
    document.getElementById('modalVenda').classList.remove('hidden');
    preencherItem('selectColheita', 'https://localhost:7027/Harvest');
    preencherUnidade('unidadeMedidaVenda', 'https://localhost:7027/MeasureUnit');
}
function fecharModalVenda() {
    document.getElementById('selectColheita').value = "";
    document.getElementById('quantidadeVendida').value = "";
    document.getElementById('unidadeMedidaVenda').value = "";
    document.getElementById('unidadeMedidaVenda').value = "";
    document.getElementById('precoUnitario').value = "";
    document.getElementById('comprador').value = "";

    document.getElementById('modalVenda').classList.add('hidden');
}

async function registrarVenda() {
    try {
        const token = localStorage.getItem('token');

        // Pega os valores do modal
        const colheitaId = document.getElementById('selectColheita').value;
        const quantidade = parseFloat(document.getElementById('quantidadeVendida').value.replace(',', '.')) || 0;
        const unidadeMedidaId = document.getElementById('unidadeMedidaVenda').value;
        const precoUnitario = parseFloat(document.getElementById('precoUnitario').value.replace(',', '.')) || 0;
        const comprador = document.getElementById('comprador').value.trim();

        const precoTotal = quantidade * precoUnitario;
        const dataVenda = new Date().toISOString();

        const body = {
            colheitaId: Number(colheitaId),
            quantidade: quantidade,
            unidadeMedidaId: Number(unidadeMedidaId),
            precoUnitario: precoUnitario,
            precoTotal: precoTotal,
            comprador: comprador,
            dataVenda: dataVenda
        };

        console.log("Enviando venda:", body);

        const response = await fetch('https://localhost:7027/Sale', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': token ? `Bearer ${token}` : ''
            },
            body: JSON.stringify(body)
        });

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(`Erro ao registrar venda: ${errorText}`);
        }

        const result = await response.json();
        console.log("Venda registrada:", result);

        fecharModalVenda();
        listarVendas(); 
        receita();
        receitaMes();
    } catch (error) {
        console.error("Erro ao registrar venda:", error);
        alert(`Erro ao registrar venda: ${error.message}`);
    }
}

async function preencherUnidade(selectId, apiUrl) {
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
    }
}

async function preencherItem(selectId, apiUrl) {
    const selectElement = document.getElementById(selectId);
    const token = localStorage.getItem('token');

    try {
        // 1. Buscar colheitas
        const respostaColheita = await fetch(apiUrl, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': token ? `Bearer ${token}` : ''
            }
        });
        if (!respostaColheita.ok) {
            throw new Error(`Erro Colheita: ${respostaColheita.status}`);
        }
        const colheitaData = await respostaColheita.json();
        const colheitas = colheitaData.data || [];

        // 2. Buscar plantios
        const respostaPlantio = await fetch('https://localhost:7027/Planting', {
            headers: {
                "Authorization": `Bearer ${token}`,
                "Content-Type": "application/json"
            }
        });
        if (!respostaPlantio.ok) {
            throw new Error(`Erro Plantio: ${respostaPlantio.status}`);
        }
        const plantioData = await respostaPlantio.json();
        const plantios = plantioData.data || [];

        // 3. Buscar espécies
        const respostaEspecie = await fetch('https://localhost:7027/Species', {
            headers: {
                "Authorization": `Bearer ${token}`,
                "Content-Type": "application/json"
            }
        });
        if (!respostaEspecie.ok) {
            throw new Error(`Erro Espécie: ${respostaEspecie.status}`);
        }
        const especieData = await respostaEspecie.json();
        const especies = especieData.data || [];

        // 4. Montar os options com o NomeComum da espécie
        selectElement.innerHTML = `<option value="">Selecione uma espécie</option>`; // reset

        colheitas.forEach(col => {
            const plantio = plantios.find(p => p.id === col.plantioId);
            const especie = plantio ? especies.find(e => e.id === plantio.especieId) : null;

            if (especie) {
                const option = document.createElement('option');
                option.value = col.id; // id da colheita ainda é o value
                option.textContent = especie.nomeComum; // mostra apenas o NomeComum
                selectElement.appendChild(option);
            }
        });

    } catch (error) {
        console.error(`Erro ao carregar o select ${selectId}:`, error);
    }
}
 async function receita() {
    const token = localStorage.getItem('token');

    try {
        const response = await fetch('https://localhost:7027/Sale', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': token ? `Bearer ${token}` : ''
            }
        });

        if (!response.ok) {
            throw new Error(`Erro ${response.status}: ${response.statusText}`);
        }

        const resposta = await response.json();
        const vendas = resposta.data || [];

        // Soma o PrecoTotal de todas as vendas
        const totalReceita = vendas.reduce((acc, venda) => acc + parseFloat(venda.precoTotal || 0), 0);

        // Se quiser mostrar na página, pode usar algo assim:
        document.getElementById('receita').textContent = `R$ ${totalReceita.toLocaleString('pt-BR', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}`;


    } catch (error) {
        console.error('Erro ao carregar vendas:', error);
    }
}
 async function receitaMes() {
    const token = localStorage.getItem('token');

    try {
        const response = await fetch('https://localhost:7027/Sale', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': token ? `Bearer ${token}` : ''
            }
        });

        if (!response.ok) {
            throw new Error(`Erro ${response.status}: ${response.statusText}`);
        }

        const resposta = await response.json();
        const vendas = resposta.data || [];

        const hoje = new Date();
        const dataAlvo = new Date();
        dataAlvo.setDate(hoje.getDate() - 30); // 30 dias atrás

        // Filtrar vendas do último mês
        const vendasUltimoMes = vendas.filter(v => {
            const dataVenda = new Date(v.dataVenda);
            return dataVenda >= dataAlvo && dataVenda <= hoje;
        });

        // Soma o PrecoTotal das vendas filtradas
        const totalReceita = vendasUltimoMes.reduce((acc, venda) => acc + parseFloat(venda.precoTotal || 0), 0);
        console.log(totalReceita);

        // Exibir na página
        document.getElementById('receitaMes').textContent = `R$ ${totalReceita.toLocaleString('pt-BR', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}`;

    } catch (error) {
        console.error('Erro ao carregar vendas do último mês:', error);
    }
}

receita();
receitaMes();

listarVendas();
