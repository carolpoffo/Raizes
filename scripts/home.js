function sidebar(){
    fetch('sidebar.html')
    .then(response => response.text())
    .then(data => {
      document.getElementById('sidebar-container').innerHTML = data;

      // Depois que a sidebar foi carregada, adiciona o listener do botão logout
      const logoutBtn = document.getElementById('logout');
      if (logoutBtn) {
        logoutBtn.addEventListener('click', function () {
          localStorage.removeItem('token');
          localStorage.removeItem('user');
          window.location.href = "index.html";
        });
      }
       //lterar o estilo do elemento da navbar
      const navbar = document.querySelector('#home'); 
      if (navbar) {
        navbar.classList.add('bg-white/20');
      }
    });

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
receita();

sidebar();