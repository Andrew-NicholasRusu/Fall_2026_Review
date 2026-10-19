#!/usr/bin/env python3
"""
vscode_remote_ssh.py - a toolkit for VS Code "Remote Development using SSH".
 
Built from the official doc (https://code.visualstudio.com/docs/remote/ssh).
Standard library only. Works on Windows (PowerShell), macOS and Linux.
 
Quick start
-----------
    python vscode_remote_ssh.py doctor                     # check your local setup
    python vscode_remote_ssh.py install-client --pack      # install Remote-SSH (+ pack)
    python vscode_remote_ssh.py keygen --name id_ed25519_remote
    python vscode_remote_ssh.py add-host dev --hostname 10.0.0.5 --user me \
        --identity ~/.ssh/id_ed25519_remote --local-forward 3000 --local-forward 27017
    python vscode_remote_ssh.py copy-key dev -i ~/.ssh/id_ed25519_remote
    python vscode_remote_ssh.py test dev
    python vscode_remote_ssh.py probe dev                  # remote prerequisites
    python vscode_remote_ssh.py net-check --remote dev     # port 443 reachability
    python vscode_remote_ssh.py open dev /home/me/project  # launch VS Code on the host
    python vscode_remote_ssh.py learn                      # study notes from the doc
    python vscode_remote_ssh.py ps-cheatsheet              # PowerShell equivalents
 
Add --dry-run (before the sub-command) to print commands without running them.
"""
from __future__ import annotations

import argparse
import json
import os
import re
import shlex
import shutil
import socket
import ssl
import subprocess
import sys
import textwrap
import time
from dataclasses import dataclass
from pathlib import Path

def _c(code: str, text: str) -> str:
    return f"\033[{code}m{text}\033[0m" if sys.stdout.isatty() and not IS_WINDOWS or os.environ.get("WT_SESSION") else text

def ok (msg: str) -> None:
    print(f"{_c('32', '[ OK ]')} {msg}")

def warn (msg: str) -> None:
    print(f"{_c('33', '[WARN]')} {msg}")

def fail(msg: str) -> None:
    print(f"{_c('31', '[FAIL]')} {msg}")

def info(msg: str) -> None:
    print(f"{_c('36', '[INFO]')} {msg}")

def fmt_cmd(cmd: list[str]) -> str:
    return subprocess.list2cmdline(cmd if IS_WINDOWS else shlex. join(cmd))

def run(cmd: list[str], *, input_text: str | None = None, capture: bool = True,
        timeout: float | None = None) -> subprocess.CompletedProcess:
    "Run a command; never raises for missing binaries / timeouts."
    

