-- insert-data.sql (zadanie 3 - dane testowe)
-- minimum po 5 rekordow do kazdej tabeli
-- najpierw odpal table-schema.sql na pustych tabelach,
-- wtedy id leca po kolei 1-5 i klucze obce pasuja
-- odpalenie: psql -U postgres -d taskmanager -f database/insert-data.sql

-- USERS (id beda 1-5)
-- haslo do wszystkich kont testowych: admin123
-- hashe sa z BCrypt, wiec backend moze na nie zalogowac
INSERT INTO users (username, email, password_hash) VALUES
  ('admin', 'admin@example.com', '$2a$11$yAqDelmc04abf7X3HFfEz.d0/YxSOytkiJp1daJfoO94mWKz6t56.'),
  ('jan_kowalski', 'jan@example.com', '$2a$11$jaodm7A18R5GlSPzJh7lUOKOZzzspbyIADWOjm9XPMLNjSMOfuDt2'),
  ('anna_nowak', 'anna@example.com', '$2a$11$goaq/z5kLEHeJB8NoK.Dhukd2tLhFln7frXgY0dRGGxUqZ0RLE6Sa'),
  ('piotr_wisniewski', 'piotr@example.com', '$2a$11$Wr9g8q6fqjCOYhUjR96nk.jMPpuXge7zYxhc98716FqeJeaWxXUUm'),
  ('kasia_zielinska', 'kasia@example.com', '$2a$11$oMTtlPfmxELfvRPsMzw1feI.g3qEyHBfT3BO36KSQZ3XT7JBPHJF.');

-- sprawdzam: SELECT * FROM users; -> admin ma id 1, jan id 2

-- TASKS (user_id tylko takie co istnieja w users)
INSERT INTO tasks (user_id, title, description, status) VALUES
  (2, 'Przygotować makietę', 'Ekran listy i formularza', 'done'),
  (1, 'Zainstalować PostgreSQL', 'Wersja 18, hasło postgres', 'done'),
  (3, 'Narysować ERD', 'Tabele USERS, TASKS, COMMENT', 'in_progress'),
  (4, 'Napisać skrypt SQL', 'Plik table-schema.sql', 'in_progress'),
  (5, 'Dodać dane testowe', 'Po 5 rekordów do tabeli', 'todo');

-- COMMENT (task_id i user_id tylko takie co istnieja, sprawdzone wyzej)
-- w zadaniu 2 tabela nazywa sie comment, wiec tu tez comment
INSERT INTO comment (content, task_id, user_id) VALUES
  ('Makieta listy gotowa', 1, 2),
  ('Baza zainstalowana', 2, 1),
  ('ERD prawie skończone', 3, 3),
  ('Skrypt działa w playground', 4, 4),
  ('Dopisuję piąty komentarz', 5, 5);

-- sprawdzenie:
-- SELECT * FROM users;
-- SELECT * FROM tasks;
-- SELECT * FROM comment;
