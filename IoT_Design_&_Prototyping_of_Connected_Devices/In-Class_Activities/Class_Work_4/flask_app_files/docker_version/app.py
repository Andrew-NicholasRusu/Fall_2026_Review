from flask import Flask, request, jsonify

app = Flask(__name__)

# Simple in-memory list. It resets when the container restarts.
students = [
    {"id": 1, "name": "Ali", "course": "IoT"},
    {"id": 2, "name": "Sara", "course": "Python"},
]

@app.get("/students")
def get_students():
    """GET method: return all students as JSON."""
    return jsonify({"students": students})

@app.post("/students")
def add_student():
    """POST method: receive JSON and add a new student."""
    data = request.get_json()

    if not data or "name" not in data or "course" not in data:
        return jsonify({"error": "Please send JSON with name and course"}), 400

    new_student = {
        "id": len(students) + 1,
        "name": data["name"],
        "course": data["course"],
    }
    students.append(new_student)

    return jsonify({"message": "Student added", "student": new_student}), 201

if __name__ == "__main__":
    # Important for Docker: listen on 0.0.0.0, not only 127.0.0.1
    app.run(debug=True, host="0.0.0.0", port=5000)
