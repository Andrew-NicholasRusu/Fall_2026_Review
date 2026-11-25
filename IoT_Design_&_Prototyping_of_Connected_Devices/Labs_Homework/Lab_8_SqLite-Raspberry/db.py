import sqlite3
from pathlib import Path

# absolute path: works no matter where the script is started from 
DB_PATH = Path(__file__).resolve().parent / 'my.db'

def get_connection(path=DB_PATH):
     
     conn = sqlite3.connect(path, timeout=5.0)    # wait up to 5 s for a lock 
     conn.row_factory = sqlite3.Row               # rows by column name 
     conn.execute('PRAGMA journal_mode = WAL')    # readers don't block writer 
     conn.execute('PRAGMA synchronous = NORMAL')  # fewer SD-card writes 
     conn.execute('PRAGMA foreign_keys = ON')     # enforce FOREIGN KEYs 
     return conn 