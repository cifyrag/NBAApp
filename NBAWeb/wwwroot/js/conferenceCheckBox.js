function updateCheckboxStatus(checkboxId) {
    const checkbox = document.getElementById(checkboxId);
    localStorage.setItem(checkboxId, checkbox.checked);
}


function loadCheckboxStatus(checkboxId) {
    const checkbox = document.getElementById(checkboxId);
    const status = localStorage.getItem(checkboxId);

    if (status !== null) {
        checkbox.checked = status === 'true'; 
    }
}

window.onload = function () {
    loadCheckboxStatus('btncheck1');
    loadCheckboxStatus('btncheck2');
};


document.getElementById('btncheck1').addEventListener('change', function () {
    updateCheckboxStatus('btncheck1');
});

document.getElementById('btncheck2').addEventListener('change', function () {
    updateCheckboxStatus('btncheck2');
});