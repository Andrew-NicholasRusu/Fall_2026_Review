drop database if exists SchoolDB ;
CREATE DATABASE SchoolDB;
USE SchoolDB;

-- Create Students table
CREATE TABLE Students (
    student_id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(50),
    major VARCHAR(50),
    gpa DECIMAL(3,2)
);

-- Create Courses table
CREATE TABLE Courses (
    course_id INT PRIMARY KEY AUTO_INCREMENT,
    course_name VARCHAR(50),
    credits INT
);

-- Create Enrollments table
CREATE TABLE Enrollments (
    enrollment_id INT PRIMARY KEY AUTO_INCREMENT,
    student_id INT,
    course_id INT,
    grade DECIMAL(4,1),
    FOREIGN KEY (student_id) REFERENCES Students(student_id),
    FOREIGN KEY (course_id) REFERENCES Courses(course_id)
);
INSERT INTO Students (name, major, gpa) VALUES
('Alice', 'Computer Science', 3.8),
('Bob', 'Engineering', 3.2),
('Charlie', 'Computer Science', 3.6),
('Diana', 'Mathematics', 3.9),
('Evan', 'Engineering', 2.8);

INSERT INTO Courses (course_name, credits) VALUES
('Database Systems', 3),
('Programming I', 4),
('Calculus', 3),
('Electronics', 3),
('AI Fundamentals', 4);

INSERT INTO Enrollments (student_id, course_id, grade) VALUES
(1, 1, 90.0),
(1, 2, 88.5),
(2, 2, 72.0),
(2, 4, 85.0),
(3, 1, 78.5),
(3, 5, 81.0),
(4, 3, 95.0),
(4, 5, 89.0),
(5, 4, 68.0);
