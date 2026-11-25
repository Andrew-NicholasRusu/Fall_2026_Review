import sqlite3

def delete_task (conn, task_id):
    sql = 'DELETE FROM tasks WHERE id = ?'
    cur = conn.cursor()
    cur.execute(sql, (task_id,))
    conn.commit()
    print(cur.rowcount, 'task(s) deleted')

def delete_all_tasks(conn):
    cur = conn.execute('DELETE FROM tasks')
    conn.commit()
    print(cur.rowcount, 'task(s) deleted')

def count_tasks(conn):
    cur = conn.execute('SELECT COUNT(*) FROM tasks')
    print(cur.fetchone()[0], 'task(s) remaining')

def main():
    try:
        with sqlite3.connect('my.db') as conn:
            delete_task(conn, 1)
            # delete_all_tasks(conn)
    except sqlite3.Error as e:
        print(e)

if __name__ == '__main__':
    main()