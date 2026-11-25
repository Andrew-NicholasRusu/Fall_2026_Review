from contextlib import closing
from db import get_connection

with closing(get_connection()) as conn:
    with conn:
        for pragma in ('journal_mode', 'synchronous', 'foreign_keys'):
            value = conn.execute(f'PRAGMA {pragma}').fetchone()[0]
            print(pragma, '=', value)
            