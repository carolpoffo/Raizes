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



sidebar();