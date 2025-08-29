export async function receita() {
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
export async function receitaMes() {
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


