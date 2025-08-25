async function somarFornecedores() {
  const token = localStorage.getItem('token');

  try {
    const response = await fetch('https://localhost:7027/Supplier', {
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

    const fornecedores = dados.data || [];
    document.getElementById('fornecedores').textContent = fornecedores.length;

  } catch (error) {
    console.error('Erro ao verificar fornecedores:', error);
  }
}

function abrirModalFornecedor() {
    document.getElementById('modalFornecedor').classList.remove('hidden');
}
function fecharModal() {
    document.getElementById('nomeFornecedor').value = "";
    document.getElementById('cnpjFornecedor').value= "";
    document.getElementById('telefoneFornecedor').value= "";
    document.getElementById('emailFornecedor').value= "";
    document.getElementById('modalFornecedor').classList.add('hidden');
}

function salvarFornecedor() {

  const fornecedorItem = {
    Nome : document.getElementById('nomeFornecedor').value.trim(),
    CNPJ: document.getElementById('cnpjFornecedor').value.trim(),
    Telefone: document.getElementById('telefoneFornecedor').value.trim(),
    Email: document.getElementById('emailFornecedor').value.trim()
  };

  fetch('https://localhost:7027/Supplier', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      // CORREÇÃO: template string com crase
      'Authorization': `Bearer ${localStorage.getItem('token')}`
    },
    body: JSON.stringify(fornecedorItem)
  })
  .then(response => {
    if (!response.ok) {
      return response.text().then(text => {
        // CORREÇÃO: string com crase para interpolar
        mensagemEl.textContent = `Erro da API: ${text}`;
        throw new Error("Erro ao cadastrar Fornecedor");
      });
    }
    return response.json();
  })
  .then(data => {
    
    somarFornecedores();
    fecharModal();
  })
  .catch(error => {
    mensagemEl.textContent = `Erro: ${error.message}`;
  });
}


somarFornecedores();
