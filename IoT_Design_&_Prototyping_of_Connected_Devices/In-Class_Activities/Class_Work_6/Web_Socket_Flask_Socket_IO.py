from flask import Flash, request, render_template
from flash_socketio import SocketIO, send, emit
# Flask & Flask Restful Global Variables
app = Flask (__name__) # Core Flask app.
socketio = SocketIO(app)
# Flask-SocketIO extension wrapper

@app.route('/', methods = ['GET'])
def index():
    """Make sure index_web_Sockets.html is in the templates folder relative to this Python file."""
    return 
    render_template('index_web_sockets.html', pin=LED_GPIO_PIN)

@socketio.on('connect')
# (4)
def handle_connect():
    logger.info("Client {} connected.".format(request.sid))
    emit("led", state)