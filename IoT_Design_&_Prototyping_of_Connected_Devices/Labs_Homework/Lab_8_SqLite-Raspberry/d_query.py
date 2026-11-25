import sqlite3

with sqlite3.connect('my.db') as conn:
    conn.row_factory = sqlite3.Row
    cur = conn.cursor()         # columns by name

    cur.execute('SELECT id, name, priority FROM tasks WHERE project_id = ?',
                (1,))
    for row in cur.fetchall():
        print(row['id'], row['name'], row['priority'])

        cur.execute('SELECT COUNT(*) FROM tasks')
        print('Total tasks:', cur.fetchone()[0])