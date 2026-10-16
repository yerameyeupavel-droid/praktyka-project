-- select-training.sql (zadanie 4 - select training)
-- odpalenie: psql -U postgres -d taskmanager -f database/select-training.sql
-- w playground wkleic calosc i Run queries

-- 1. login i email wszystkich, alfabetycznie po loginie
-- (u nas kolumna nazywa sie username, wyswietlam ja jako login)
SELECT username AS login, email
FROM users
ORDER BY username;

-- 2. tytuły i statusy zadan zakonczonych
SELECT title, status
FROM tasks
WHERE status = 'done';

-- 3. ile zadan w kazdym statusie, od najwiekszej liczby
SELECT status, COUNT(*) AS liczba
FROM tasks
GROUP BY status
ORDER BY liczba DESC;

-- 4. tytul zadania + login autora
-- (w podpowiedzi jest t.users_id, ale u nas kolumna nazywa sie user_id)
SELECT t.title, u.username AS login
FROM tasks t
JOIN users u ON u.id = t.user_id
ORDER BY t.id;
