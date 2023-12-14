function darkLightMode() {
    const body = document.querySelector('body');
    const checkbox = document.getElementById('flexSwitchCheckDefault');

    const currentTheme = body.dataset.bsTheme || localStorage.getItem('theme');
    const newTheme = currentTheme === 'light' ? 'dark' : 'light';

    body.dataset.bsTheme = newTheme;
    localStorage.setItem('theme', newTheme);

    // Update the checkbox status
    checkbox.checked = newTheme === 'dark';
}

// Set the initial theme and checkbox status on page load
document.addEventListener('DOMContentLoaded', () => {
    const body = document.querySelector('body');
    const checkbox = document.getElementById('flexSwitchCheckDefault');
    const storedTheme = localStorage.getItem('theme');

    if (storedTheme) {
        body.dataset.bsTheme = storedTheme;
        checkbox.checked = storedTheme === 'dark';
    }
});
