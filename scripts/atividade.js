// Variáveis globais
let tarefasAgendadas = [];
let maxVisiveis = 1;
let startIndex = 0;

const container = document.getElementById('listarTarefas');
const btnNext = document.getElementById('nextBtn');
const btnPrev = document.getElementById('prevBtn');

// Função para calcular quantos cards cabem no container
function atualizarMaxVisiveis() {
  const larguraContainer = container.offsetWidth;
  const larguraCard = 176; // Largura aproximada de cada card (w-40 em Tailwind = 160px + padding)
  maxVisiveis = Math.floor(larguraContainer / larguraCard);
  if (maxVisiveis < 1) maxVisiveis = 1;
}

function atualizarVisibilidadeBotoes() {
  const carousel = document.getElementById('listarTarefas');
  const btnPrev = document.getElementById('prevBtn');
  const btnNext = document.getElementById('nextBtn');

  const scrollLeft = carousel.scrollLeft;
  const scrollWidth = carousel.scrollWidth;
  const clientWidth = carousel.clientWidth;

  // Se está no início → esconde o botão prev
  if (scrollLeft <= 0) {
    btnPrev.classList.add('hidden');
  } else {
    btnPrev.classList.remove('hidden');
  }

  // Se está no fim → esconde o botão next
  if (scrollLeft + clientWidth >= scrollWidth - 1) {
    btnNext.classList.add('hidden');
  } else {
    btnNext.classList.remove('hidden');
  }
}

// Função para renderizar os cards das tarefas no container
function renderizarTarefas() {
  atualizarMaxVisiveis();

  container.classList.add('opacity-0');

  setTimeout(() => {
    container.innerHTML = '';

    if (tarefasAgendadas.length === 0) {
      const card = document.createElement('div');
      card.className = 'group relative bg-gray-300 h-60 w-40 rounded-3xl p-6 text-gray-700 shadow flex items-center justify-center text-center flex-shrink-0';
      card.innerHTML = `<p class="text-lg font-semibold">Nenhuma tarefa agendada</p>`;
      container.appendChild(card);
    } else {
      const endIndex = Math.min(startIndex + maxVisiveis, tarefasAgendadas.length);
      const tarefasParaMostrar = tarefasAgendadas.slice(startIndex, endIndex);

      tarefasParaMostrar.forEach(tarefa => {
        const card = document.createElement('div');
        card.className = "group bg-green-medium h-60 w-40 rounded-3xl p-4 text-white shadow transition-all duration-300 hover:bg-white hover:text-green-dark relative";

        card.innerHTML = `
          <h3 class="p-2 font-semibold mb-2">${tarefa.titulo}</h3>
          <p class="text-lg opacity-90 py-8 break-words">${tarefa.descricao}</p>
          <button 
            class="absolute bottom-4 left-1/2 transform -translate-x-1/2 bg-green-light text-green-dark font-semibold px-3 py-1 rounded-md text-sm opacity-0 group-hover:opacity-100 transition-opacity duration-300 shadow hover:bg-green-light hover:text-white"
            data-id="${tarefa.id}" 
            data-titulo="${tarefa.titulo}" 
            data-descricao="${tarefa.descricao}"
          >
            Concluir
          </button>
        `;

        container.appendChild(card);

        const btnConcluir = card.querySelector('button');
        btnConcluir.addEventListener('click', (e) => {
          const btn = e.currentTarget;
          const id = btn.getAttribute('data-id');
          const titulo = btn.getAttribute('data-titulo');
          const descricao = btn.getAttribute('data-descricao');
          concluirTarefa(id, titulo, descricao);
        });
      });

      btnPrev.disabled = startIndex === 0;
      btnNext.disabled = endIndex >= tarefasAgendadas.length;
    }

    // Fade-in com leve atraso para dar tempo da DOM mudar
    setTimeout(() => {
      container.classList.remove('opacity-0');
      container.classList.add('opacity-100');
    }, 50);
  }, 200);
}


// Buscar tarefas
function listarAtividades() {
  const token = localStorage.getItem('token');

  fetch('phtts://localhost:7027/Task', {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
      'Authorization': token ? `Bearer ${token}` : ''
    }
  })
    .then(response => {
      if (!response.ok) throw new Error('Erro ao carregar atividades');
      return response.json();
    })
    .then(data => {
      tarefasAgendadas = (data.data || []).filter(t => t.status === 0);
      startIndex = 0;
      renderizarTarefas();
    })
    .catch(error => {
      console.error('Erro ao buscar tarefas:', error);
    });
}

// Navegação entre os cards
btnNext.addEventListener('click', () => {
  if (startIndex + maxVisiveis < tarefasAgendadas.length) {
    startIndex++;
    renderizarTarefas();
  }
});

btnPrev.addEventListener('click', () => {
  if (startIndex > 0) {
    startIndex--;
    renderizarTarefas();
  }
});

// Responsividade: atualizar visualização ao redimensionar
window.addEventListener('resize', () => {
  atualizarMaxVisiveis();
  renderizarTarefas();
});

// Função para concluir a tarefa (alterar status para 1)
function concluirTarefa(id, titulo, descricao) {
  const token = localStorage.getItem('token');

  const tarefaAtualizada = {
    Id: id,
    UsuarioId: 1,  // Ajuste se necessário para pegar o ID correto do usuário
    Titulo: titulo,
    Descricao: descricao,
    Status: 1
  };

  fetch(`https://localhost:7027/Task/`, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
      'Authorization': token ? `Bearer ${token}` : ''
    },
    body: JSON.stringify(tarefaAtualizada)
  })
    .then(response => {
      if (!response.ok) {
        return response.text().then(text => {
          throw new Error(text);
        });
      }
      return response.json();
    })
    .then(() => {
      console.log('Tarefa concluída com sucesso');
      listarAtividades(); // Recarrega as tarefas após concluir
    })
    .catch(error => {
      console.error('Erro ao concluir tarefa:', error);
    });
}

// Inicializa a listagem assim que a página carregar
document.addEventListener('DOMContentLoaded', () => {
  listarAtividades();
});

function abrirModalAtividade() {
    document.getElementById('modalAtividade').classList.remove('hidden');
}
function fecharModalAtividade() {
    const mensagemEl = document.getElementById('mensagemAtividade');
    document.getElementById('modalAtividade').classList.add('hidden');
    mensagemEl.textContent = ''; 
}

function salvarAtividade() {

  const mensagemEl = document.getElementById('mensagemAtividade');

  const atividadeItem = {
    UsuarioId: 1,
    Titulo: document.getElementById('tituloAtividade').value.trim(),
    Descricao: document.getElementById('descricaoAtividade').value.trim(),
    Status: 0
  };

  fetch('https://localhost:7027/Task', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      // CORREÇÃO: template string com crase
      'Authorization': `Bearer ${localStorage.getItem('token')}`
    },
    body: JSON.stringify(atividadeItem)
  })
  .then(response => {
    if (!response.ok) {
      return response.text().then(text => {
        // CORREÇÃO: string com crase para interpolar
        mensagemEl.textContent = `Erro da API: ${text}`;
        throw new Error("Erro ao salvar atividade");
      });
    }
    return response.json();
  })
  .then(data => {
    fecharModalAtividade();
    listarAtividades();
  })
  .catch(error => {
    // CORREÇÃO: string com crase para interpolar
    mensagemEl.textContent = `Erro: ${error.message}`;
  });
}
