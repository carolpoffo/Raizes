async function somarQuantidadeDisponivel() {
  const token = localStorage.getItem('token');

  try {
    const response = await fetch('https://localhost:7027/HarvestStorage', {
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
    const armazenamentos = dados.data || [];
debugger
    // Filtra só os que estão Disponivel
    const disponiveis = armazenamentos.filter(item => item.status == 0);
    // Soma a quantidade disponível
    const totalDisponivel = disponiveis.reduce((acc, item) => acc + (parseFloat(item.quantidadeDisponivel) || 0), 0);
    // Exibe no elemento com id 'totalDisponivel' (crie esse elemento no seu HTML)
    document.getElementById('totalItensArmazenados').innerHTML = totalDisponivel;

  } catch (error) {
    console.error('Erro ao somar quantidade disponível:', error);
  }
}

somarQuantidadeDisponivel();
