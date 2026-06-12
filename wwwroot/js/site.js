// Modal helpers
function showModal(id) {
    const modal = document.getElementById(id);
    if (modal) modal.classList.add('show');
}

function hideModal(id) {
    const modal = document.getElementById(id);
    if (modal) modal.classList.remove('show');
}

// Cerrar modal al hacer clic fuera
document.addEventListener('click', function(e) {
    if (e.target.classList.contains('modal-overlay')) {
        e.target.classList.remove('show');
    }
});

document.addEventListener('DOMContentLoaded', function() {
    const path = window.location.pathname.toLowerCase();
    document.querySelectorAll('.nav-item').forEach(item => {
        const href = item.getAttribute('href')?.toLowerCase() || '';
        if (href && path.startsWith(href) && href !== '/') {
            item.classList.add('active');
        }
    });
});
