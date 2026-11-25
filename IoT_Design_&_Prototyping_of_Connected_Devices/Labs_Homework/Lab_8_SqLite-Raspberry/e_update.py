import sqlite3

def run_update(sql, params):
    try:
        with sqlite3.connect('my.db') as conn:
            cursor = conn.cursor()
            cursor.execute(sql, params)
            conn.commit()
            print(cursor.rowcount, 'row(s) changed')
    except sqlite3.Error as e:
        print(e)

if __name__ == '__main__':
    # 1) one column of one row: task 1 gets priority 2 
    # run_update('UPDATE tasks SET priority = ? WHERE id = ?', (2, 1))

    # 2) several columns of one row: task 1 gets priority 3, status 2 
    # run_update('UPDATE tasks SET priority = ?, status_id = ? WHERE id = ?', (3, 2, 1)) 
   
    # 3) one column of EVERY row: no WHERE clause 
    run_update('UPDATE tasks SET end_date = ?', ('2015-02-03',))