apiHandShake();

const user = JSON.parse(localStorage.getItem('user'));
document.getElementById('nome-usuario').innerHTML = user.name;

// Estado da aplicação
let mecanicos = [];
let isLoading = false;

// Inicializar aplicação
document.addEventListener('DOMContentLoaded', function () {
    lucide.createIcons();
    carregarMecanicos();
    carregarClima(); // Função que busca o clima
});

// Método para buscar mecânicos do backend
async function buscarMecanicos() {
    try {
        setLoading(true);
        const data = await apiGet('Mecanico');
        mecanicos = data;
        renderizarTabela();
    } catch (error) {
        console.error('Erro ao buscar mecânicos:', error);
        showToast('Erro', 'Não foi possível carregar a lista de mecânicos.', 'error');
        renderizarTabela();
    } finally {
        setLoading(false);
    }
}

// Carregar mecânicos (usando mock por enquanto)
async function carregarMecanicos() {
    await buscarMecanicos();
    renderizarTabela();
    renderizarSelect();
}

// Carregar clima usando wttr.in e geolocalização
async function carregarClima() {
    if (!navigator.geolocation) {
        atualizarClimaDisplay('Geolocalização não suportada');
        return;
    }

    navigator.geolocation.getCurrentPosition(async (pos) => {
        try {
            const lat = pos.coords.latitude;
            const lon = pos.coords.longitude;

            const response = await fetch(`https://wttr.in/${lat},${lon}?format=j1`);
            const data = await response.json();

            const temp = data.current_condition[0].temp_C;
            const desc = data.current_condition[0].weatherDesc[0].value;

            atualizarClimaDisplay(`${temp}°C - ${desc}`);
        } catch (err) {
            console.error('Erro ao buscar clima:', err);
            atualizarClimaDisplay('Erro ao obter clima');
        }
    }, () => {
        atualizarClimaDisplay('Permissão negada para localização');
    });
}

// Atualiza o texto do clima na interface
function atualizarClimaDisplay(text) {
    const climaEl = document.getElementById('clima');
    if (climaEl) {
        climaEl.textContent = text;
    }
}

// Renderizar select de mecânicos
function renderizarSelect() {
    const mecanicosSelect = document.getElementById("mecanicos-select-area");    
    const options = mecanicos.data.map(mec => {
        return `<option value="${mec.id}">${mec.nome}</option>`;
    });

    mecanicosSelect.innerHTML = `
        <select id="mecanico-select">
            ${options.join('')}
        </select>
    `;    
}

// Renderizar tabela de mecânicos
function renderizarTabela() {
    const tbody = document.getElementById('mecanicos-tbody');
    const emptyState = document.getElementById('empty-state');
    const tableContainer = document.getElementById('table-container');

    if (mecanicos.length === 0) {
        tableContainer.classList.add('hidden');
        emptyState.classList.remove('hidden');
        return;
    }

    tableContainer.classList.remove('hidden');
    emptyState.classList.add('hidden');
    tbody.innerHTML = mecanicos.data.map(mecanico => `
                <tr class="hover:bg-gray-50">
                    <td class="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">
                        #${mecanico.id}
                    </td>
                    <td class="px-6 py-4 whitespace-nowrap">
                        <div class="flex items-center">
                            <div class="flex-shrink-0 h-8 w-8">
                                <div class="h-8 w-8 rounded-full bg-gray-200 flex items-center justify-center">
                                    <i data-lucide="user" class="h-4 w-4 text-gray-500"></i>
                                </div>
                            </div>
                            <div class="ml-3">
                                <div class="text-sm font-medium text-gray-900">${mecanico.nome}</div>
                            </div>
                        </div>
                    </td>                   
                    <td class="px-6 py-4 whitespace-nowrap text-right text-sm font-medium">
                        <button class="text-red-600 hover:text-red-900">Excluir</button>
                    </td>
                </tr>
            `).join('');

    // Recriar ícones do Lucide
    lucide.createIcons();
}

// Método para cadastrar novo mecânico
async function cadastrarMecanico() {
    const nomeInput = document.getElementById('nome-input');
    const nome = nomeInput.value.trim();

    if (!nome) {
        showToast('Erro', 'Por favor, informe o nome do mecânico.', 'error');
        return;
    }

    try {
        setLoading(true);
        const btn = document.getElementById('cadastrar-btn');
        btn.disabled = true;
        btn.textContent = 'Cadastrando...';

        const result = await apiPost("Mecanico", { nome: nome });
        
        carregarMecanicos();

        // Limpar formulário e fechar modal
        nomeInput.value = '';
        closeModal();

        showToast('Sucesso', result.message);
    } catch (error) {
        console.error('Erro ao cadastrar mecânico:', error);
        showToast('Erro', 'Não foi possível cadastrar o mecânico.', 'error');
    } finally {
        setLoading(false);
        const btn = document.getElementById('cadastrar-btn');
        btn.disabled = false;
        btn.textContent = 'Cadastrar';
    }
}

// Método para fazer logout
async function handleLogout() {
    localStorage.clear();
    window.location.href = "index.html";
    showToast('Logout', 'Você foi desconectado com sucesso.', 'success');
}

// Controle do modal
function openModal() {
    document.getElementById('modal').classList.remove('hidden');
    document.getElementById('nome-input').focus();
}

function closeModal() {
    document.getElementById('modal').classList.add('hidden');
    document.getElementById('nome-input').value = '';
}

// Handle Enter key no input
function handleEnterKey(event) {
    if (event.key === 'Enter') {
        cadastrarMecanico();
    }
}

// Controle de loading
function setLoading(loading) {
    isLoading = loading;
    const loadingEl = document.getElementById('loading');
    const tableContainer = document.getElementById('table-container');

    if (loading) {
        loadingEl.classList.remove('hidden');
        tableContainer.classList.add('hidden');
    } else {
        loadingEl.classList.add('hidden');
        if (mecanicos.length > 0) {
            tableContainer.classList.remove('hidden');
        }
    }
}

// Sistema de Toast
function showToast(title, message, type = 'info') {
    const toast = document.getElementById('toast');
    const toastIcon = document.getElementById('toast-icon');
    const toastTitle = document.getElementById('toast-title');
    const toastMessage = document.getElementById('toast-message');

    // Configurar ícone e cores baseado no tipo
    let iconName = 'info';
    let iconColor = 'text-blue-500';

    switch (type) {
        case 'success':
            iconName = 'check-circle';
            iconColor = 'text-green-500';
            break;
        case 'error':
            iconName = 'x-circle';
            iconColor = 'text-red-500';
            break;
        case 'warning':
            iconName = 'alert-triangle';
            iconColor = 'text-yellow-500';
            break;
    }

    toastIcon.setAttribute('data-lucide', iconName);
    toastIcon.className = `h-5 w-5 ${iconColor}`;
    toastTitle.textContent = title;
    toastMessage.textContent = message;

    toast.classList.remove('hidden');
    lucide.createIcons();

    // Auto-hide após 5 segundos
    setTimeout(() => {
        hideToast();
    }, 5000);
}

function hideToast() {
    document.getElementById('toast').classList.add('hidden');
}
