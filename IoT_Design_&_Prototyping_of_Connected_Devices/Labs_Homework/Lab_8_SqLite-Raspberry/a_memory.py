import sqlite3

def create_sqlite_in_memory():
    """Create a connection to a database that lives in RAM."""
    conn = None
    try:
        conn = sqlite3.connect(':memory:')
        print(sqlite3.sqlite_version)
    except sqlite3.Error as e:
        print(e)
    finally:
        if conn:
            conn.close()

if __name__ == '__main__':
    create_sqlite_in_memory()