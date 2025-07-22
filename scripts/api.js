function apiHandShake() {
    const token = localStorage.getItem('token');
    
    if (!token) {
        window.location.href = "index.html";
    } else {
        fetch("https://localhost:7027/User/HandShake", {
            method: "GET",
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            }
        }).then((result) => {
            return result.json();
        }).then((data) => {
        })
            .catch((error) => {
                localStorage.clear();
                window.location.href = "index.html";
            })
    }
}

async function apiGet(route) {
    const response = await fetch(`https://localhost:7027/${route}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${localStorage.getItem('token')}`
        }
    })
    if (!response.ok) {
        throw new Error('Erro ao buscar da api');
    }
    return await response.json();
}

async function apiPost(route, body) {
    const response = await fetch(`https://localhost:7027/${route}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${localStorage.getItem('token')}`
        },
        body: JSON.stringify(body)
    })
    if (!response.ok) {
        throw new Error('Erro ao buscar da api');
    }
    return await response.json();
}