// Modal Evento
function abrirModal() {
    document.getElementById('modalEvento').classList.remove('hidden');
}
function fecharModal() {
    document.getElementById('modalEvento').classList.add('hidden');
}

// Salvar Evento
function salvarEvento() {
    const token = localStorage.getItem('token');
    // Caso queira pegar usuário do localStorage, mas está fixo para 1
    const userId = Number(localStorage.getItem('userId'));

    const eventoItem = {
        usuarioId: 1,
        titulo: document.getElementById('titulo').value || '',
        local: document.getElementById('local').value || '',
        dataInicio: new Date(document.getElementById('dataInicio').value).toISOString(),
        dataFim: new Date(document.getElementById('dataFim').value).toISOString(),
        descricao: document.getElementById('descricao').value || ''
    };

    console.log('Evento enviado:', JSON.stringify(eventoItem, null, 2));

    fetch('https://localhost:7027/Event', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token ? `Bearer ${token}` : ''
        },
        body: JSON.stringify(eventoItem)
    })
    .then(response => {
        if (!response.ok) throw new Error('Erro ao salvar evento');
        return response.json();
    })
    .then(data => {
        fecharModal();
        carregarEventos(); // Atualiza lista após salvar
    })
    .catch(error => {
        console.error('Erro:', error);
        const messageEl = document.getElementById('messageEvento');
        messageEl.textContent = 'Falha ao salvar o evento.';
    });
}

// Função para excluir evento pelo ID
async function excluirEvento(id) {
    const token = localStorage.getItem('token');
    try {
        const response = await fetch(`https://localhost:7027/Event/${id}`, {
            method: 'DELETE',
            headers: {
                'Authorization': token ? `Bearer ${token}` : ''
            }
        });
        if (!response.ok) {
            throw new Error(`Erro ao excluir evento: ${response.status}`);
        }
        // Atualiza a lista após exclusão
        carregarEventos();
    } catch (error) {
        console.error(error);
        alert('Erro ao excluir evento.');
    }
}

// Carregar eventos da API
async function carregarEventos() {
    const token = localStorage.getItem('token');

    try {
        const response = await fetch('https://localhost:7027/Event', {
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
        const eventos = resposta.data || [];

        // Ordena eventos pela data de início
        eventos.sort((a, b) => new Date(a.dataInicio) - new Date(b.dataInicio));

        const container = document.getElementById('event-container');
        container.innerHTML = '';

        eventos.forEach(evento => {
            const div = document.createElement('div');
            div.className = "flex items-center justify-between p-3 bg-gray-50 rounded-lg hover:bg-green-raizes-dark transition-colors duration-300 group";

            div.innerHTML = `
                <div class="flex items-center space-x-4 flex-1">
                    <div class="w-12 h-12 bg-green-light rounded-lg flex items-center justify-center">
                        <span class="text-white font-bold">${new Date(evento.dataInicio).getDate()}</span>
                    </div>
                    <div>
                        <h3 class="font-medium">${evento.titulo}</h3>
                        <p class="text-sm">${evento.local}</p>
                        <div class="flex items-center text-xs mt-1 opacity-70 group-hover:opacity-100 transition-opacity duration-300 ">
                            <svg class="w-3 h-3 mr-1" fill="currentColor" viewBox="0 0 20 20">
                                <path fill-rule="evenodd" d="M6 2a1 1 0 00-1 1v1H4a2 2 0 00-2 2v10a2 2 0 002 2h12a2 2 0 002-2V6a2 2 0 00-2-2h-1V3a1 1 0 10-2 0v1H7V3a1 1 0 00-1-1zm0 5a1 1 0 000 2h8a1 1 0 100-2H6z" clip-rule="evenodd"/>
                            </svg>
                            ${formatarData(evento.dataInicio)} - ${formatarData(evento.dataFim)}
                        </div>
                    </div>
                </div>

                <button
                    class="ml-4 px-3 py-1 text-sm font-medium rounded bg-green-medium text-white opacity-0 group-hover:opacity-100 transition-opacity duration-300"
                    type="button"
                    data-id="${evento.id}"
                >
                    Concluir
                </button>
            `;

            container.appendChild(div);
        });

        // Adiciona listener para excluir evento ao clicar no botão Concluir
        const botoesConcluir = container.querySelectorAll('button[data-id]');
        botoesConcluir.forEach(botao => {
            botao.addEventListener('click', () => {
                const idEvento = botao.getAttribute('data-id');
                if (confirm('Deseja realmente concluir (excluir) este evento?')) {
                    excluirEvento(idEvento);
                }
            });
        });

    } catch (error) {
        console.error('Erro ao carregar eventos:', error);
    }
}

// Função auxiliar para formatar datas (pt-BR)
function formatarData(dataString) {
    const data = new Date(dataString);
    return data.toLocaleDateString('pt-BR');
}

// Inicializa carregando eventos
carregarEventos();
