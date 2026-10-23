// Tablica zadan - prototyp.
// Dane wczytuje z pliku data/tasks.json, wiec trzeba odpalic przez Live Server.
const DATA_URL = 'data/tasks.json';

let tasks = [];
let editingId = null;
let nextId = 1;

const statusLabel = { todo: 'Do zrobienia', in_progress: 'W trakcie', done: 'Wykonane' };

const listTodo = document.getElementById('list-todo');
const listProgress = document.getElementById('list-in_progress');
const listDone = document.getElementById('list-done');

const emptyTodo = document.getElementById('empty-todo');
const emptyProgress = document.getElementById('empty-in_progress');
const emptyDone = document.getElementById('empty-done');

const countTodo = document.getElementById('count-todo');
const countProgress = document.getElementById('count-in_progress');
const countDone = document.getElementById('count-done');

const formSection = document.getElementById('formSection');
const form = document.getElementById('taskForm');
const searchInput = document.getElementById('search');

async function loadTasks() {
  try {
    const response = await fetch(DATA_URL);

    if (!response.ok) {
      throw new Error('Nie udało się wczytać danych (' + response.status + ').');
    }

    tasks = await response.json();
    policzNextId();
    render();

    console.log('Zadania wczytane:', tasks);
  } catch (error) {
    const box = document.getElementById('pageError');

    if (error.message === 'Failed to fetch') {
      box.textContent = 'Nie udało się wczytać danych. Uruchom stronę przez Live Server, a nie z pliku.';
    } else {
      box.textContent = error.message;
    }

    box.classList.remove('hidden');
  }
}

function policzNextId() {
  let max = 0;

  for (let i = 0; i < tasks.length; i++) {
    if (tasks[i].id > max) {
      max = tasks[i].id;
    }
  }

  nextId = max + 1;
}

function render() {
  const q = searchInput.value.toLowerCase().trim();

  listTodo.textContent = '';
  listProgress.textContent = '';
  listDone.textContent = '';

  const licznik = { todo: 0, in_progress: 0, done: 0 };

  tasks.forEach(function (t) {
    const tytul = t.title.toLowerCase();
    const opis = (t.description || '').toLowerCase();

    if (q !== '' && tytul.indexOf(q) === -1 && opis.indexOf(q) === -1) {
      return;
    }

    const card = createCard(t);

    if (t.status === 'todo') {
      listTodo.appendChild(card);
      licznik.todo++;
    } else if (t.status === 'in_progress') {
      listProgress.appendChild(card);
      licznik.in_progress++;
    } else {
      listDone.appendChild(card);
      licznik.done++;
    }
  });

  countTodo.textContent = licznik.todo;
  countProgress.textContent = licznik.in_progress;
  countDone.textContent = licznik.done;

  emptyTodo.classList.toggle('hidden', licznik.todo > 0);
  emptyProgress.classList.toggle('hidden', licznik.in_progress > 0);
  emptyDone.classList.toggle('hidden', licznik.done > 0);
}

function createCard(t) {
  const li = document.createElement('li');
  li.className = 'card task';

  const title = document.createElement('h3');
  title.textContent = t.title;

  const desc = document.createElement('p');
  desc.textContent = t.description ? t.description : 'brak opisu';

  const badge = document.createElement('span');
  badge.className = 'badge ' + t.status;
  badge.textContent = statusLabel[t.status] || t.status;

  const row = document.createElement('div');
  row.className = 'row';

  const editBtn = document.createElement('button');
  editBtn.type = 'button';
  editBtn.className = 'btn btn-ghost';
  editBtn.appendChild(ikonka('assets/edit.svg'));
  editBtn.appendChild(document.createTextNode('Edytuj'));
  editBtn.addEventListener('click', function () {
    startEdit(t.id);
  });

  const delBtn = document.createElement('button');
  delBtn.type = 'button';
  delBtn.className = 'btn btn-ghost';
  delBtn.appendChild(ikonka('assets/delete.svg'));
  delBtn.appendChild(document.createTextNode('Usuń'));
  delBtn.addEventListener('click', function () {
    removeTask(t.id);
  });

  row.appendChild(editBtn);
  row.appendChild(delBtn);

  li.appendChild(title);
  li.appendChild(desc);
  li.appendChild(badge);
  li.appendChild(row);

  return li;
}

function ikonka(src) {
  const img = document.createElement('img');
  img.src = src;
  img.alt = '';
  img.className = 'icon';
  return img;
}

function startEdit(id) {
  const t = tasks.find(function (x) { return x.id === id; });

  if (!t) {
    return;
  }

  editingId = id;
  document.getElementById('formTitle').textContent = 'Edytuj zadanie';
  document.getElementById('saveBtn').textContent = 'Zapisz zmiany';
  document.getElementById('title').value = t.title;
  document.getElementById('description').value = t.description || '';
  document.getElementById('status').value = t.status;
  document.getElementById('formError').classList.add('hidden');
  formSection.classList.remove('hidden');
}

function removeTask(id) {
  if (!confirm('Usunąć zadanie?')) {
    return;
  }

  tasks = tasks.filter(function (t) { return t.id !== id; });

  if (editingId === id) {
    editingId = null;
    formSection.classList.add('hidden');
  }

  render();
}

document.getElementById('addBtn').addEventListener('click', function () {
  editingId = null;
  document.getElementById('formTitle').textContent = 'Dodaj zadanie';
  document.getElementById('saveBtn').textContent = 'Dodaj zadanie';
  document.getElementById('formError').classList.add('hidden');
  form.reset();
  formSection.classList.remove('hidden');
});

document.getElementById('cancelBtn').addEventListener('click', function () {
  editingId = null;
  formSection.classList.add('hidden');
});

form.addEventListener('submit', function (e) {
  e.preventDefault();

  const title = document.getElementById('title').value.trim();
  const description = document.getElementById('description').value.trim();
  const status = document.getElementById('status').value;
  const err = document.getElementById('formError');

  if (title === '') {
    err.classList.remove('hidden');
    return;
  }

  err.classList.add('hidden');

  if (editingId !== null) {
    const t = tasks.find(function (x) { return x.id === editingId; });

    if (t) {
      t.title = title;
      t.description = description;
      t.status = status;
    }
  } else {
    // TODO: jak bedzie backend to zapisywac na serwerze
    tasks.push({
      id: nextId,
      title: title,
      description: description,
      status: status
    });
    nextId++;
  }

  editingId = null;
  formSection.classList.add('hidden');
  render();
});

searchInput.addEventListener('input', render);

document.getElementById('loginForm').addEventListener('submit', function (e) {
  e.preventDefault();
  // Prototyp: zawsze pokazujemy blad, bo nie ma backendu.
  document.getElementById('loginError').classList.remove('hidden');
});

document.getElementById('logoutBtn').addEventListener('click', function () {
  alert('Prototyp: wylogowanie bez backendu.');
});

loadTasks();
