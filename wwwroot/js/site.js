// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const sb = document.getElementById('sb');
const ov = document.getElementById('ov');
const isMob = () => window.innerWidth <= 680;
let col = false;

function tgSidebar() {
    if (isMob()) {
        const open = sb.classList.toggle('mob');
        ov.classList.toggle('show', open);
    } else {
        col = !col;
        sb.classList.toggle('col', col);
        if (col) {
            document.querySelectorAll('.sm').forEach(m => m.classList.remove('open'));
            document.querySelectorAll('.ni[id]').forEach(i => i.classList.remove('open', 'active'));
        }
    }
}

function closeMob() {
    sb.classList.remove('mob');
    ov.classList.remove('show');
}

window.addEventListener('resize', () => {
    if (!isMob()) { sb.classList.remove('mob'); ov.classList.remove('show'); }
    else { if (col) { sb.classList.remove('col'); col = false; } }
});

function tog(el, menuId) {
    if (col) { col = false; sb.classList.remove('col'); setTimeout(() => _open(el, menuId), 50); return; }
    _open(el, menuId);
}
function _open(el, menuId) {
    const menu = document.getElementById(menuId);
    const isOpen = el.classList.contains('open');
    document.querySelectorAll('.ni[id]').forEach(i => i.classList.remove('open', 'active'));
    document.querySelectorAll('.sm').forEach(m => m.classList.remove('open'));
    if (!isOpen) { el.classList.add('open', 'active'); menu.classList.add('open'); }
}

function pg(title, icon, desc) {
    document.getElementById('hv').style.display = 'none';
    document.getElementById('ph').classList.add('show');
    document.getElementById('ph-i').textContent = icon;
    document.getElementById('ph-t').textContent = title;
    document.getElementById('ph-s').textContent = desc;
    document.getElementById('ptitle').innerHTML = `${icon} <em>/ ${title}</em>`;
    if (isMob()) closeMob();
}

function goHome() {
    document.getElementById('hv').style.display = '';
    document.getElementById('ph').classList.remove('show');
    document.getElementById('ptitle').innerHTML = '🏠 Início <em>/ Dashboard</em>';
    document.querySelectorAll('.ni[id]').forEach(i => i.classList.remove('open', 'active'));
    document.querySelectorAll('.sm').forEach(m => m.classList.remove('open'));
    document.querySelectorAll('.si').forEach(s => s.classList.remove('active'));
}

function tgTheme() {
    const dark = document.documentElement.getAttribute('data-theme') === 'dark';
    document.documentElement.setAttribute('data-theme', dark ? 'light' : 'dark');
    document.getElementById('tp').classList.toggle('on', !dark);
}



