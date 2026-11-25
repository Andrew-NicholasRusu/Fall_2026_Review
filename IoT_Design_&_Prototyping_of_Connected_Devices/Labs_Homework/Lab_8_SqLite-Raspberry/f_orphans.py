import sqlite3

with sqlite3.connect('my.db') as conn: 
      # Restore the backup, then repeat F2 with this line right after connecting:
      conn.execute('PRAGMA foreign_keys = ON') 
      conn.execute('DELETE FROM projects WHERE id = ?', (1,)) 
      conn.commit() 

       