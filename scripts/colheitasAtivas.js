async function somarQuantidadeColheitas() {
  const token = localStorage.getItem('token');

  try {
    const response = await fetch('https://localhost:7027/Harvest', {
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
    const colheitas = dados.data || [];

    const totalQuantidade = colheitas.reduce((acc, item) => {return acc + (parseFloat(item.quantidade) ? 1 : 0);}, 0);
    document.getElementById('Colheitas').innerHTML = totalQuantidade;

  } catch (error) {
    console.error('Erro ao somar quantidades das colheitas:', error);
  }
}

document.addEventListener('DOMContentLoaded', () => {
  somarQuantidadeColheitas();
});
