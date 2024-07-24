document.addEventListener('DOMContentLoaded', function () {
    const loader = document.querySelector('.loader');

    function removeLoader() {
        setTimeout(() => {
            loader.style.display = 'none';
        }, 1500);
    }

    removeLoader();
});
