interface user {
    id: number;
    name: string;
    role: "admin" | "developer";
}

function greet(user: User): string{
    return `Hello, ${user.name}! You are logged in as ${user.role}.`;
}

const currentUser: User = {
    id: 1,
    name: "Alex",
    role: "developer"
};
console.log(greet(currentUser));