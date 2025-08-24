function abrirmodalPlantio() {
    const modal = document.getElementById('modalPlantio');
    modal.classList.remove('hidden');

    preencherSelect('selectEspecie', 'https://localhost:7027/Species');
    preencherSelect('selectPropriedade', 'https://localhost:7027/Property');
    preencherSelect('selectUnidadeMedida', 'https://localhost:7027/MeasureUnit');
}
function fecharmodalPlantio() {
    document.getElementById('modalPlantio').classList.add('hidden');
    const mensagemEl = document.getElementById('mensagemPlantio');
    mensagemEl.textContent = ''; 
    document.getElementById("selectEspecie").value = '';
    document.getElementById("selectPropriedade").value = '';
    document.getElementById("inputDataInicio").value = '';
    document.getElementById("inputDataFim").value = '';
    document.getElementById("inputAreaPlantada").value = '';
    document.getElementById("inputMudas").value = '';
    document.getElementById("inputDescricao").value = '';
    document.getElementById("selectUnidadeMedida").value = '';
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
            if (selectId == 'selectPropriedade'){
                option.textContent = item.nome
            }else if(selectId =='selectUnidadeMedida'){
                option.textContent = item.sigla
            }else{
                option.textContent = item.nomeComum
            };
            selectElement.appendChild(option);
        });



    } catch (error) {
        console.error(`Erro ao carregar o select ${selectId}:`, error);
        selectElement.innerHTML = '<option value="">Erro ao carregar dados</option>';
    }
}

async function salvarPlantio() {
    const token = localStorage.getItem('token');
    const mensagemEl = document.getElementById("mensagemPlantio");

    try {
    
        const especieId = document.getElementById("selectEspecie").value;
        const propriedadeId = document.getElementById("selectPropriedade").value;
        const dataInicio = document.getElementById("inputDataInicio").value;
        const dataFim = document.getElementById("inputDataFim").value;
        const areaPlantada = document.getElementById("inputAreaPlantada").value;
        const mudas = document.getElementById("inputMudas").value;
        const descricao = document.getElementById("inputDescricao").value;
        const unidadeMedidaId = document.getElementById("selectUnidadeMedida").value;

        // Converte date -> datetime ISO
        const inicioISO = new Date(dataInicio).toISOString();
        const fimISO = new Date(dataFim).toISOString();

        const body = {
            especieId: Number(especieId),
            propriedadeId: Number(propriedadeId),
            dataInicio: inicioISO,
            dataFim: fimISO,
            areaPlantada: Number(areaPlantada),
            mudas: Number(mudas),
            descricao,
            unidadeMedidaId: Number(unidadeMedidaId)
        };

        console.log("Enviando body:", body);

        const response = await fetch("https://localhost:7027/Planting", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": token ? `Bearer ${token}` : ""
            },
            body: JSON.stringify(body)
        });

        if (!response.ok) {
            const msg = `Erro ${response.status}: ${response.statusText}`;
            mensagemEl.textContent = msg;
            mensagemEl.className = "py-2 text-red-600 font-bold";
            return;
        }

        const result = await response.json();
        console.log("Plantio criado:", result);

        mensagemEl.textContent = "Plantio criado com sucesso!";
        mensagemEl.className = "py-2 text-green-600 font-bold";
        fecharmodalPlantio();

    } catch (error) {
        console.error("Erro ao criar plantio:", error);
        alert("Erro ao criar plantio");
    }
}

async function ProxColheitas() {
  const url = "https://localhost:7027/Harvest";
  const token = localStorage.getItem('token');
  try {
    const response = await fetch(url, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': token ? `Bearer ${token}` : ''
            }
        });

    if (!response.ok) {
      throw new Error(`Erro na requisição: ${response.status}`);
    }

    const data = await response.json();

    // Data alvo = hoje + 30 dias
    const hoje = new Date();
    const dataAlvo = new Date();
    dataAlvo.setDate(hoje.getDate() + 30);

    // Filtrar colheitas que batem com a data alvo
    // Filtrar colheitas com data até 30 dias à frente
    const proxColheitas = data.data.filter(item => {
    const dataColheita = new Date(item.dataColheita);
    return dataColheita >= hoje && dataColheita <= dataAlvo;
    });


    // Estrutura final
    const resultado = {
      proxColheitas: proxColheitas
    };
  
    document.getElementById("proxColheitas").textContent = proxColheitas.length;
    console.log(resultado);
    console.log(proxColheitas.length);
    return resultado;

  } catch (error) {
    console.error("Erro ao buscar colheitas:", error);
  }
}

async function calcularTamanhoDisponivel() {
  const token = localStorage.getItem('token');

  try {
    // Pegar propriedades
    const propResponse = await fetch("https://localhost:7027/Property", {
      headers: {
        "Content-Type": "application/json",
        "Authorization": token ? `Bearer ${token}` : ""
      }
    });
    const propData = await propResponse.json();

    // Pegar plantios
    const plantResponse = await fetch("https://localhost:7027/Planting", {
      headers: {
        "Content-Type": "application/json",
        "Authorization": token ? `Bearer ${token}` : ""
      }
    });
    const plantData = await plantResponse.json();

    // Calcular a quantidade disponível para cada propriedade
    const quantidadesDisponiveis = propData.data.map(propriedade => {
      const totalPlantada = plantData.data
        .filter(p => p.propriedadeId === propriedade.id)
        .reduce((sum, p) => sum + p.areaPlantada, 0);

      return propriedade.tamanho - totalPlantada; // apenas a quantidade
    });

    document.getElementById("areaDisponivel").textContent = quantidadesDisponiveis
   

  } catch (error) {
    console.error("Erro ao calcular tamanho disponível:", error);
  }
}


// Variável global para armazenar plantios ativos
let plantiosAtivos = [];

// Função para listar plantios ativos e espécies
async function listarPlantio() {
    const token = localStorage.getItem('token');

    try {
        // Buscar plantios
        const plantResponse = await fetch('https://localhost:7027/Planting', {
            headers: {
                'Content-Type': 'application/json',
                'Authorization': token ? `Bearer ${token}` : ''
            }
        });

        if (!plantResponse.ok) throw new Error('Erro ao carregar plantios');
        const plantData = await plantResponse.json();

        // Buscar espécies
        let especieData = { data: [] };
        try {
            const especieResponse = await fetch('https://localhost:7027/Species', {
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': token ? `Bearer ${token}` : ''
                }
            });

            if (!especieResponse.ok) throw new Error('Erro ao carregar espécies');
            especieData = await especieResponse.json();

        } catch (espError) {
            console.warn('Não foi possível carregar espécies. Usando nomes padrão.', espError);
        }
        console.log(especieData)
        // Filtrar plantios ativos e associar a espécie
        const plantiosAtivos = (plantData.data || [])
    .filter(p => p.ativa === true)
    .map(p => {
        const especie = especieData.data.find(e => e.Id === p.especieId);
        return {
            ...p,
            especieNome: especie ? especie.nomeComum : 'Espécie',
            especieVariedade: especieData ? especieData.variedade : ''
        };
    });
        console.log(plantiosAtivos);

        // Renderizar os plantios
        renderizarPlantio(plantiosAtivos);

    } catch (error) {
        console.error('Erro ao buscar plantios ou espécies:', error);
    }
}


// Função para renderizar os plantios no grid
function renderizarPlantio() {
    const container = document.querySelector('.grid');
    if (!container) return;

    container.innerHTML = ''; // limpa o grid antes de renderizar

    plantiosAtivos.forEach(plantio => {
        const dataInicio = new Date(plantio.DataInicio).toLocaleDateString('pt-BR');
        const dataFim = new Date(plantio.DataFim).toLocaleDateString('pt-BR');

        const card = document.createElement('div');
        card.id = "listarCultivos";

        card.innerHTML = `
            <div class="flex items-center justify-between mb-4">
              <span class="bg-green-100 text-green-800 px-3 py-1 rounded-full text-xs font-semibold">Ativo</span>
              <button class="text-gray-400 hover:text-gray-600 p-1 rounded-full hover:bg-gray-100 transition-colors">
                <svg class="w-5 h-5" fill="currentColor" viewBox="0 0 24 24">
                  <path d="M12 8c1.1 0 2-.9 2-2s-.9-2-2-2-2 .9-2 2 .9 2 2 2zm0 2c-1.1 0-2 .9-2 2s.9 2 2 2 2-.9 2-2-.9-2-2-2zm0 6c-1.1 0-2 .9-2 2s.9 2 2 2 2-.9 2-2-.9-2-2-2z"/>
                </svg>
              </button>
            </div>
            <h3 class="font-bold text-gray-800 mb-4 text-lg">${plantio.especieNome} - ${plantio.especieVariedade}</h3>
            <div class="space-y-3 text-sm">
              <div class="flex justify-between items-center">
                <span class="text-gray-600">Propriedade:</span>
                <span class="font-semibold text-gray-800">${plantio.PropriedadeId}</span>
              </div>
              <div class="flex justify-between items-center">
                <span class="text-gray-600">Área:</span>
                <span class="font-semibold text-gray-800">${plantio.AreaPlantada} ha</span>
              </div>
              <div class="flex justify-between items-center">
                <span class="text-gray-600">Mudas:</span>
                <span class="font-semibold text-gray-800">${plantio.Mudas}</span>
              </div>
              <div class="flex justify-between items-center">
                <span class="text-gray-600">Início:</span>
                <span class="font-semibold text-gray-800">${dataInicio}</span>
              </div>
              <div class="flex justify-between items-center">
                <span class="text-gray-600">Previsão:</span>
                <span class="font-semibold text-gray-800">${dataFim}</span>
              </div>
            </div>
            <div class="mt-5 pt-4 border-t border-gray-200">
              <div class="flex gap-2">
                <button class="flex-1 bg-green-dark text-white px-3 py-2 rounded-lg text-sm font-medium hover:bg-green-medium transition-all duration-200 shadow-sm hover:shadow-md">
                  Concluir
                </button>
                <button class="flex-1 bg-gray-100 text-gray-700 px-3 py-2 rounded-lg text-sm font-medium hover:bg-gray-200 transition-all duration-200">
                  Excluir
                </button>
              </div>
            </div>
        `;
        container.appendChild(card);
    });
}

// Executa ao carregar a página
document.addEventListener("DOMContentLoaded", () => {
    listarPlantio();
});



calcularTamanhoDisponivel()
ProxColheitas();
