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
