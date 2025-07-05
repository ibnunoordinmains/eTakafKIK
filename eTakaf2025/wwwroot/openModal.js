function openModal(modalId) {
    const modalElement = document.getElementById(modalId);
    if (!modalElement) return;

    const modal = bootstrap.Modal.getOrCreateInstance(modalElement);
    modal.show();
}
